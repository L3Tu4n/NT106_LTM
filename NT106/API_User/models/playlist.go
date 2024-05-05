// định nghĩa là cấu trúc dữ liệu sẽ được lưu vào collection.
package models

import (

	//Tạo token JWT

	//để sử dụng biến môi trường trong .env

	"github.com/jmoiron/sqlx"
	_ "github.com/mattn/go-sqlite3"
)

type Playlist struct {
	ID             int    `json:"ID" db:"ID"`
	EMAIL          string `json:"EMAIL" db:"EMAIL"`
	NAME           string `json:"NAME" db:"NAME"`
	PLAYLIST_IMAGE string `json:"PLAYLIST_IMAGE" db:"PLAYLIST_IMAGE"`
}

func InsertPlaylist(db *sqlx.DB, email string, playlistName string) error {
	// Chuẩn bị câu lệnh SQL để chèn dữ liệu vào cơ sở dữ liệu
	query := `INSERT INTO Playlist (EMAIL, NAME) VALUES (?, ?)`

	// Thực thi câu lệnh SQL với các tham số được truyền vào
	_, err := db.Exec(query, email, playlistName)
	if err != nil {
		return err
	}

	return nil
}
func GetPlaylistsByEmail(email string, db *sqlx.DB) ([]Playlist, error) {
	// Chuẩn bị câu lệnh SQL để lấy danh sách playlist dựa trên email
	query := `SELECT * FROM Playlist WHERE EMAIL = ?`

	// Thực thi câu lệnh SQL với email được truyền vào và lấy danh sách kết quả
	var playlists []Playlist
	err := db.Select(&playlists, query, email)
	if err != nil {
		return nil, err
	}

	return playlists, nil
}
func GetPlaylistNewest(email string, db *sqlx.DB) (*Playlist, error) {
	// Chuẩn bị câu lệnh SQL để lấy playlist mới nhất dựa trên email
	query := `SELECT * FROM Playlist WHERE EMAIL = ? ORDER BY ID DESC LIMIT 1`

	// Thực thi câu lệnh SQL với email được truyền vào và lấy kết quả
	var playlist Playlist
	err := db.Get(&playlist, query, email)
	if err != nil {
		return nil, err
	}

	return &playlist, nil
}
func UpdatePlaylistName(email string, db *sqlx.DB, playlistID, newName string) error {
	// Chuẩn bị câu lệnh SQL để cập nhật tên playlist dựa trên email và ID của playlist
	query := `UPDATE Playlist SET NAME = ? WHERE EMAIL = ? AND ID = ?`

	// Thực thi câu lệnh SQL với các tham số được truyền vào
	_, err := db.Exec(query, newName, email, playlistID)
	if err != nil {
		return err
	}

	return nil
}
