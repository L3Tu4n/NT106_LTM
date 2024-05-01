// định nghĩa là cấu trúc dữ liệu sẽ được lưu vào collection.
package models

import (
	"crypto/rand"
	"database/sql"
	"encoding/base64"
	"encoding/hex"
	"html"
	"log"
	"strings"

	//Tạo token JWT

	//để sử dụng biến môi trường trong .env
	"github.com/jmoiron/sqlx"
	"github.com/joho/godotenv"
	_ "github.com/mattn/go-sqlite3"
	"golang.org/x/crypto/bcrypt"
	"gopkg.in/gomail.v2" // Gửi gmail
)

type User struct {
	ID       int             `json:"ID" db:"ID"`
	BIRTH    sql.NullFloat64 `json:"BIRTH" db:"BIRTH"` // để có thể chứa giá trị null ở cột BIRTH
	NAME     sql.NullString  `json:"NAME" db:"NAME"`
	EMAIL    string          `json:"EMAIL" db:"EMAIL"`
	PASSWORD string          `json:"PASSWORD" db:"PASSWORD"`
	GENDER   sql.NullInt64   `json:"GENDER" db:"GENDER"`
}

func (user *User) HashPassword(password string) error {
	bytes, err := bcrypt.GenerateFromPassword([]byte(password), 14)
	if err != nil {
		return err
	}
	user.PASSWORD = string(bytes)
	return nil
}

func (user *User) CheckPassword(providedPassword string) error {
	err := bcrypt.CompareHashAndPassword([]byte(user.PASSWORD), []byte(providedPassword))
	if err != nil {
		return err
	}
	return nil
}

func (user *User) Santize(data string) string {
	data = html.EscapeString(strings.TrimSpace(data))
	return data
}
func GenerateVerificationCode(length int) (string, error) {
	randomBytes := make([]byte, length)
	_, err := rand.Read(randomBytes)
	if err != nil {
		return "", err
	}
	return hex.EncodeToString(randomBytes)[:length], nil
}
func SendVerificationEmail(email, code string) error {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Error getting env, %v", err)
	}
	// Thông tin xác thực Gmail
	emailFrom := "22521546@gm.uit.edu.vn" //Nhập email
	password := "1162348797"              //Nhập pass

	// Thông tin SMTP của Gmail
	smtpHost := "smtp.gmail.com"
	smtpPort := 587

	// Tạo một đối tượng gửi email
	m := gomail.NewMessage()
	m.SetHeader("From", emailFrom)
	m.SetHeader("To", email)
	m.SetHeader("Subject", "Verification Code")
	m.SetBody("text/plain", "Your verification code is: "+code+"\nPlease verify within 1 minute")

	// Tạo một đối tượng Dialer để gửi email
	d := gomail.NewDialer(smtpHost, smtpPort, emailFrom, password)

	// Gửi email
	if err := d.DialAndSend(m); err != nil {
		log.Println(err)
		return err
	}
	return nil
}
func GenerateRandomPassword(length int) (string, error) {
	randomBytes := make([]byte, length)
	_, err := rand.Read(randomBytes)
	if err != nil {
		return "", err
	}
	return base64.URLEncoding.EncodeToString(randomBytes)[:length], nil
}
func ResetPasswordAndSendEmail(db *sqlx.DB, email, newPassword string) error {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Error getting env, %v", err)
	}
	// Băm mật khẩu mới
	hashedPassword, err := bcrypt.GenerateFromPassword([]byte(newPassword), bcrypt.DefaultCost)
	if err != nil {
		return err
	}
	// Đặt lại mật khẩu cho người dùng trong cơ sở dữ liệu
	// Ở đây bạn cần thực hiện một truy vấn để cập nhật mật khẩu mới cho người dùng với địa chỉ email được cung cấp.
	_, err = db.Exec("UPDATE Users SET PASSWORD = ? WHERE EMAIL = ?", hashedPassword, email)
	if err != nil {
		return err
	}
	// Gửi email chứa mật khẩu mới
	// Thông tin xác thực Gmail
	emailFrom := "" // Địa chỉ email của bạn
	password := ""  // Mật khẩu email của bạn

	// Thông tin SMTP của Gmail
	smtpHost := "smtp.gmail.com"
	smtpPort := 587

	// Tạo một đối tượng gửi email
	m := gomail.NewMessage()
	m.SetHeader("From", emailFrom)
	m.SetHeader("To", email)
	m.SetHeader("Subject", "New Password")
	m.SetBody("text/plain", "Your new password is: "+newPassword+"\nPlease log in and change your new password")

	// Tạo một đối tượng Dialer để gửi email
	d := gomail.NewDialer(smtpHost, smtpPort, emailFrom, password)

	// Gửi email
	if err := d.DialAndSend(m); err != nil {
		return err
	}
	return nil
}
