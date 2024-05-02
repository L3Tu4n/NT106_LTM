package main

import (
	"context"
	"fmt"
	"log"
	"net/http"
	"time"

	"github.com/zmb3/spotify"
	"golang.org/x/oauth2/clientcredentials"
)

const (
	clientID     = "1b1d9ce0969346558e465944c46279a5"
	clientSecret = "b6a0080351174d84808d3040b02001f4"
)

func main() {
	config := &clientcredentials.Config{
		ClientID:     clientID,
		ClientSecret: clientSecret,
		TokenURL:     spotify.TokenURL,
	}

	http.HandleFunc("/play", playHandler(config))
	log.Fatal(http.ListenAndServe(":9999", nil))
}

func playHandler(config *clientcredentials.Config) http.HandlerFunc {
	return func(w http.ResponseWriter, r *http.Request) {
		client := config.Client(context.Background())

		client.Timeout = 5 * time.Second

		auth := spotify.NewAuthenticator("")
		token, err := config.Token(context.Background())	
		if err != nil {
			http.Error(w, "Failed to retrieve token", http.StatusInternalServerError)
			return
		}
		spotifyClient := auth.NewClient(token)

		trackID := "4HlHNLtfxP7Y5z03j3eNOi" // ID của bài hát cần phát

		track, err := spotifyClient.GetTrack(spotify.ID(trackID))
		if err != nil {
			http.Error(w, "Failed to retrieve track information", http.StatusInternalServerError)
			return
		}

		album, err := spotifyClient.GetAlbum(track.Album.ID)
		if err != nil {
			http.Error(w, "Failed to retrieve album information", http.StatusInternalServerError)
			return
		}

		var imageUrl string
		if len(album.Images) > 0 {
			// Chọn hình ảnh đầu tiên từ album
			imageUrl = album.Images[0].URL
		}
		// Chuyển đổi thời gian từ milliseconds sang dạng phút:giây
		duration := fmt.Sprintf("%d:%02d", track.Duration/60000, (track.Duration/1000)%60)

		playtrack := track.PreviewURL

		trackInfo := fmt.Sprintf("%s|%s|%s|%s|%s", track.Name, track.Artists[0].Name, track.Album.Name, duration, imageUrl)
		
		// Kết hợp playtrack và trackInfo thành một chuỗi với dấu |
		response := fmt.Sprintf("%s|%s", playtrack, trackInfo)

		// Trả về URL của bài hát
		w.Write([]byte(response))
	}
}