package main

import (
	"Music/controller" //Tạo token JWT
	"Music/middlewares"
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
		v1.GET("/profiles/profile", middlewares.AuthMiddleware(), controller.GetProfileByEmail)
		v1.PUT("/profiles/update", middlewares.AuthMiddleware(), controller.Update)
		v1.PUT("/profiles/password", middlewares.AuthMiddleware(), controller.UpdatePassword)
		v1.PUT("/profiles/avatar", middlewares.AuthMiddleware(), controller.UpdateAvatar)
		v1.GET("/DatamusicTrack", controller.GetDataMusic)
		v1.GET("/DatamusicAlbum", controller.GetDataMusicAlbum)
		v1.GET("/DatamusicArtist", controller.GetDataMusicArtist)
	}
	router.Run(":9999")
}
