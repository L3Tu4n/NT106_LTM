package controller

import (
	"Login/auth"
	"Login/database"
	"Login/models"
	"database/sql"
	"log"
	"net/http"
	"time"

	//Tạo token JWT

	"github.com/gin-gonic/gin"
	"github.com/jmoiron/sqlx" //để sử dụng biến môi trường trong .env
	_ "github.com/mattn/go-sqlite3"
	"golang.org/x/crypto/bcrypt"
)

var db *sqlx.DB

func init() {
	var err error
	db, err = database.ConnectDB()
	if err != nil {
		log.Fatalln("Cannot connect to database:", err)
	}
}
func RegisterUser(c *gin.Context) {
	var newUser models.User
	if err := c.ShouldBindJSON(&newUser); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	//Kiểm tra xem người dùng đã tồn tại chưa
	var existingUser models.User
	err := db.Get(&existingUser, "SELECT * FROM Users WHERE EMAIL = ?", newUser.EMAIL)
	if err == nil {
		c.JSON(http.StatusConflict, gin.H{"error": "User already exists"})
		return
	} else if err != sql.ErrNoRows {
		log.Println("Error querying database:", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Database error 1"})
		return
	}
	if existingUser.ID != 0 {
		c.JSON(http.StatusConflict, gin.H{"error": "User already exists"})
		return
	}
	//Gửi mã xác nhận để xác nhận email
	// Câu lệnh SQL để tạo bảng verificationcode
	createTableSQL := `
			CREATE TABLE IF NOT EXISTS verificationcode (
				EMAIL TEXT NOT NULL,
				CODE TEXT NOT NULL,
				PASSWORD TEXT NOT NULL,
				PRIMARY KEY (EMAIL)
			);
		`
	// Hash mật khẩu trước khi lưu vào cơ sở dữ liệu
	if err := newUser.HashPassword(newUser.PASSWORD); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to hash password"})
		return
	}
	// Thực thi câu lệnh SQL để tạo bảng
	_, err = db.Exec(createTableSQL)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to create table verificationcode"})
		return
	}

	// Tạo mã xác minh mới và lưu vào cơ sở dữ liệu
	verificationCode, err := models.GenerateVerificationCode(6)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to generate verification code"})
		return
	}
	_, err = db.Exec("INSERT INTO verificationcode (EMAIL, CODE,PASSWORD) VALUES (?, ?,?)", newUser.EMAIL, verificationCode, newUser.PASSWORD)
	if err != nil {
		log.Println("Error hashing password:", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to save verification code to database"})
		return
	}

	// Gửi email chứa mã xác minh đến địa chỉ email của người dùng
	if err := models.SendVerificationEmail(newUser.EMAIL, verificationCode); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to send verification email"})
		return
	}

	c.JSON(http.StatusOK, gin.H{"message": "An email with verification code has been sent to your email address"})
	// Xóa mã xác minh sau 60 giây
	go func() {
		time.Sleep(60 * time.Second)
		db.Exec("DELETE FROM verificationcode WHERE EMAIL = ?", newUser.EMAIL)
	}()
}

func LoginUser(c *gin.Context) {
	var loginData struct {
		EMAIL    string `json:"EMAIL"`
		PASSWORD string `json:"PASSWORD"`
	}
	if err := c.ShouldBindJSON(&loginData); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	// Kiểm tra thông tin đăng nhập
	var user models.User
	err := db.Get(&user, "SELECT * FROM Users WHERE EMAIL = ?", loginData.EMAIL)
	if err != nil {
		if err == sql.ErrNoRows {
			c.JSON(http.StatusUnauthorized, gin.H{"error": "Invalid credentials"})
			return
		}
		log.Println("Error querying database:", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Database error"})
		return
	}
	// Kiểm tra mật khẩu
	if err := user.CheckPassword(loginData.PASSWORD); err != nil {
		c.JSON(http.StatusUnauthorized, gin.H{"error": "Invalid credentials"})
		return
	}

	// Tạo token JWT
	token, err := auth.GenerateJWT(user.EMAIL)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to generate token"})
		return
	}
	//Luu token vao cookie
	c.SetCookie("token", token, 86400, "/", "", true, true)
	//
	c.JSON(http.StatusOK, gin.H{"token": token, "user_id": user.ID})
}

func ForgotPassword(c *gin.Context) {
	var requestData struct {
		EMAIL string `json:"EMAIL"`
	}
	if err := c.ShouldBindJSON(&requestData); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	// Kiểm tra xem email tồn tại trong cơ sở dữ liệu
	var user models.User
	err := db.Get(&user, "SELECT * FROM Users WHERE EMAIL = ?", requestData.EMAIL)
	if err != nil {
		if err == sql.ErrNoRows {
			c.JSON(http.StatusNotFound, gin.H{"error": "Email not found"})
			return
		}
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Database error"})
		return
	}
	// Câu lệnh SQL để tạo bảng verificationcode
	createTableSQL := `
			CREATE TABLE IF NOT EXISTS verificationcode_forgot (
				EMAIL TEXT NOT NULL,
				CODE TEXT NOT NULL,
				PRIMARY KEY (EMAIL)
			);
		`

	// Thực thi câu lệnh SQL để tạo bảng
	_, err = db.Exec(createTableSQL)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to create table verificationcode_forgot"})
		return
	}

	// Tạo mã xác minh mới và lưu vào cơ sở dữ liệu
	verificationCode, err := models.GenerateVerificationCode(6)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to generate verification code"})
		return
	}
	_, err = db.Exec("INSERT INTO verificationcode_forgot (EMAIL, CODE) VALUES (?, ?)", requestData.EMAIL, verificationCode)
	if err != nil {
		log.Fatalf("Error loading .env file: %v", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to save verification code to database"})
		return
	}
	// Xóa mã xác minh sau 60 giây
	go func() {
		time.Sleep(60 * time.Second)
		db.Exec("DELETE FROM verificationcode_forgot WHERE EMAIL = ?", requestData.EMAIL)
	}()
	// Gửi email chứa mã xác minh đến địa chỉ email của người dùng
	if err := models.SendVerificationEmail(requestData.EMAIL, verificationCode); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to send verification email"})
		return
	}

	c.JSON(http.StatusOK, gin.H{"message": "An email with verification code has been sent to your email address"})

}

func ConfirmVerificationCode(c *gin.Context) {
	var requestData struct {
		EMAIL string `json:"EMAIL"`
		CODE  string `json:"CODE"`
	}
	if err := c.ShouldBindJSON(&requestData); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	// Kiểm tra xem mã code có hợp lệ không
	var savedCode string
	err := db.Get(&savedCode, "SELECT CODE FROM verificationcode_forgot WHERE EMAIL = ?", requestData.EMAIL)
	if err != nil {
		if err == sql.ErrNoRows {
			c.JSON(http.StatusNotFound, gin.H{"error": "Verification code not found"})
			return
		}
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Database error"})
		return
	}
	if savedCode != requestData.CODE {
		c.JSON(http.StatusUnauthorized, gin.H{"error": "Invalid verification code"})
		return
	}

	// Xác nhận mã code thành công, cho phép đặt lại mật khẩu và gửi mật khẩu mới vào email
	// Điều này có thể làm bằng cách gọi một hàm khác để đặt lại mật khẩu và gửi email.
	// Ví dụ:
	newPassword, err := models.GenerateRandomPassword(16) // Đảm bảo tạo mật khẩu mạnh và ngẫu nhiên
	if err != nil {
		// Xử lý lỗi, như ghi log hoặc trả về phản hồi lỗi
		log.Println("Lỗi khi tạo mật khẩu ngẫu nhiên:", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Không thể tạo mật khẩu ngẫu nhiên"})
		return
	}
	if err := models.ResetPasswordAndSendEmail(db, requestData.EMAIL, newPassword); err != nil {
		log.Println(err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to reset password and send email"})
		return
	}

	// Ở đây, chúng ta chỉ trả về một thông báo thành công
	c.JSON(http.StatusOK, gin.H{"message": "Verification code confirmed successfully"})
}

func ConFirmRegister(c *gin.Context) {
	var requestData struct {
		EMAIL    string `json:"EMAIL"`
		CODE     string `json:"CODE"`
		PASSWORD string `json:"PASSWORD"`
	}
	if err := c.ShouldBindJSON(&requestData); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	// Kiểm tra xem mã code có hợp lệ không
	var savedCode string
	err := db.Get(&savedCode, "SELECT CODE FROM verificationcode WHERE EMAIL = ?", requestData.EMAIL)
	if err != nil {
		if err == sql.ErrNoRows {
			c.JSON(http.StatusNotFound, gin.H{"error": "Verification code not found"})
			return
		}
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Database error"})
		return
	}
	if savedCode != requestData.CODE {
		c.JSON(http.StatusUnauthorized, gin.H{"error": "Invalid verification code"})
		return
	}
	hashedPassword, err := bcrypt.GenerateFromPassword([]byte(requestData.PASSWORD), bcrypt.DefaultCost)
	if err != nil {
		log.Println("Error hashing password:", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Failed to hash password"})
		return
	}
	//Thêm new user vào database
	_, err = db.Exec("INSERT INTO Users (EMAIL, PASSWORD) VALUES (?, ?)", requestData.EMAIL, hashedPassword)
	if err != nil {
		log.Println("Error querying database:", err)
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Database error 2"})
		return
	}

	c.JSON(http.StatusCreated, gin.H{"message": "User registered successfully"})
}
