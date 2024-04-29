package main

import (
	"Login/controller" //Tạo token JWT
	"Login/middlewares"
	"log"

	"github.com/gin-gonic/gin"
	"github.com/joho/godotenv" //để sử dụng biến môi trường trong .env
	_ "github.com/mattn/go-sqlite3"
	// Gửi gmail
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Error getting env, %v", err)
	}
	router := gin.Default()
	v1 := router.Group("/v1")
	{
		v1.POST("/Login", controller.LoginUser)
		v1.POST("/Register", controller.RegisterUser)
		v1.POST("/Register/Confirm", controller.ConFirmRegister)
		v1.POST("/Forgot", controller.ForgotPassword)
		v1.POST("/ConfirmVerificationCode", controller.ConfirmVerificationCode)
		secured := v1.Group("/secured").Use(middlewares.AuthMiddleware())
		{
			secured.GET("/ping", controller.Ping)
		}
	}
	router.Run(":8080")
}
