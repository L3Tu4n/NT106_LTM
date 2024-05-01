package middlewares

import (
	"net/http"

	"github.com/dgrijalva/jwt-go" //Tạo token JWT
	"github.com/gin-gonic/gin"    //để sử dụng biến môi trường trong .env
	_ "github.com/mattn/go-sqlite3"
	// Gửi gmail
)

func AuthMiddleware() gin.HandlerFunc {
	return func(c *gin.Context) {
		// Lấy token từ cookie
		tokenString, err := c.Cookie("token")
		if err != nil {
			c.JSON(http.StatusUnauthorized, gin.H{"error": "Unauthorized"})
			c.Abort()
			return
		}

		// Giải mã token
		token, err := jwt.Parse(tokenString, func(token *jwt.Token) (interface{}, error) {
			return []byte("SECRET_JWT"), nil
		})
		if err != nil || !token.Valid {
			c.JSON(http.StatusUnauthorized, gin.H{"error": "Unauthorized"})
			c.Abort()
			return
		}

		// Lưu thông tin người dùng từ token vào context để sử dụng trong xử lý tiếp theo
		claims, _ := token.Claims.(jwt.MapClaims)
		c.Set("user_id", claims["user_id"])

		c.Next()
	}
}
