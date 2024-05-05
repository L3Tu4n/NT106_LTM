package main

import (
	"Login/controller" //Tạo token JWT
	"log"

	"github.com/gin-gonic/gin"
	"github.com/joho/godotenv" //để sử dụng biến môi trường trong .env
	_ "github.com/mattn/go-sqlite3"
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Error getting env, %v", err)
	}
	router := gin.Default()
	v1 := router.Group("/v1")
	{
		v1.GET("/DatamusicTrack", controller.GetDataMusic)
		v1.GET("/DatamusicAlbum", controller.GetDataMusicAlbum)
		v1.GET("/DatamusicArtist", controller.GetDataMusicArtist)
		
		v1.POST("/Track", controller.GetTrack)	
		v1.POST("/Album", controller.GetAlbum)
		v1.POST("/Artist", controller.GetArtist)
		v1.GET("/Top5Tracks", controller.GetTop5Tracks)
	}
	router.Run(":9999")
}

