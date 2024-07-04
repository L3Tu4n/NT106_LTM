using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Music
{
    public partial class Homepage : UserControl
    {
        private HttpClient httpClient;
        private int trackCounter;
        public Homepage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            InitializeFlowLayoutPanel();
        }
        private async void InitializeFlowLayoutPanel()
        {
            try
            {
                // Gọi API để lấy top 10 bài hát cùng thông tin về nghệ sĩ và album
                var responseTracks = await httpClient.GetAsync("http://localhost:9999/v1/Top10Tracks");
                if (responseTracks.IsSuccessStatusCode)
                {
                    var tracksContent = await responseTracks.Content.ReadAsStringAsync();
                    var tracks = JsonConvert.DeserializeObject<List<dynamic>>(tracksContent);

                    // Thêm card cho mỗi bài hát vào FlowLayoutPanelTrack
                    foreach (var track in tracks)
                    {
                        string imageURL = track.IMAGE.String;
                        string NameTrack = track.NAME;
                        string NameArtist = track.ARTIST_NAME;
                        string NameAlbum = track.ALBUM_NAME;
                        string Duration = track.DURATION.String;
                        trackCounter++;
                        string stt = trackCounter.ToString();
                        string fs_path = track.FS_PATH.String;
                        CardSong card = new CardSong(stt, imageURL, NameTrack, NameArtist, NameAlbum, Duration,fs_path, this);
                        flowLayoutPanelTrack.Controls.Add(card);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top tracks data");
                }

                // Gọi API để lấy top 10 album cùng thông tin nghệ sĩ
                var responseAlbums = await httpClient.GetAsync("http://localhost:9999/v1/Top10Albums");
                if (responseAlbums.IsSuccessStatusCode)
                {
                    var albumsContent = await responseAlbums.Content.ReadAsStringAsync();
                    var albums = JsonConvert.DeserializeObject<List<dynamic>>(albumsContent);

                    // Thêm card cho mỗi album vào FlowLayoutPanelAlbum
                    foreach (var album in albums)
                    {
                        string imageURL = album.IMAGE.String;
                        string NameArtist = album.ARTIST_NAME;
                        string NameAlbum = album.NAME;
                        album_item card = new album_item(imageURL, NameArtist, NameAlbum);

                        flowLayoutPanelAlbum.Controls.Add(card);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top albums data");
                }

                // Gọi API để lấy top 10 nghệ sĩ
                var responseArtists = await httpClient.GetAsync("http://localhost:9999/v1/Top10Artists");
                if (responseArtists.IsSuccessStatusCode)
                {
                    var artistsContent = await responseArtists.Content.ReadAsStringAsync();
                    var artists = JsonConvert.DeserializeObject<List<dynamic>>(artistsContent);

                    // Thêm card cho mỗi nghệ sĩ vào FlowLayoutPanelArtist
                    foreach (var artist in artists)
                    {
                        string imageURL = artist.IMAGE.String;
                        string NameArtist = artist.NAME;
                        Artist card = new Artist(imageURL, NameArtist);
                        card.Click += (s, e) => OnArtistCardClick(imageURL, NameArtist);
                        flowLayoutPanelArtist.Controls.Add(card);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top artists data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async void OnArtistCardClick(string imageURL, string artistName)
        {
            try
            {
                var responseTracks = await httpClient.GetAsync($"http://localhost:9999/v1/Artist/Tracks/{artistName}");
                if (responseTracks.IsSuccessStatusCode)
                {
                    var tracksContent = await responseTracks.Content.ReadAsStringAsync();
                    var tracks = JsonConvert.DeserializeObject<List<dynamic>>(tracksContent);

                    USCSinger singerPage = new USCSinger();
                    singerPage.ParentForm = (Form1)this.FindForm();
                    singerPage.SetArtistInfo(tracks, imageURL, artistName);

                    // Thêm USCPlay vào Form1 và điều chỉnh docking style
                    Form1 mainForm = (Form1)this.FindForm();
                    mainForm.addUserControl(singerPage);
                }
                else
                {
                    MessageBox.Show("Failed to retrieve tracks data for the artist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}
