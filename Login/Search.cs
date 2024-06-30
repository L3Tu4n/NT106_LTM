using CloudinaryDotNet.Actions;
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
    public partial class Search : UserControl
    {
        private HttpClient httpClient;
        private int trackCounter;
        public Search(string keyword)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            InitializeFlowLayoutPanel(keyword);
        }
        private async void InitializeFlowLayoutPanel(string keyword)
        {
            try
            {
                var resetpasswordRequest = new
                {
                    keyword
                };
                string json = JsonConvert.SerializeObject(resetpasswordRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Gọi API để lấy top 10 bài hát cùng thông tin về nghệ sĩ và album
                var responseTracks = await httpClient.PostAsync("http://localhost:9999/v1/Search/Tracks",content);
                if (responseTracks.IsSuccessStatusCode)
                {
                    var tracksContent = await responseTracks.Content.ReadAsStringAsync();
                    var tracks = JsonConvert.DeserializeObject<List<dynamic>>(tracksContent);
                    if (tracks != null)
                    {
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
                            cardTrack card = new cardTrack(stt, imageURL, NameTrack, NameArtist, NameAlbum, Duration);
                            flowLayoutPanelTrack.Controls.Add(card);
                        }
                    }
                    else
                    {
                        lbTrack.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top tracks data");
                }

                // Gọi API để lấy top 10 album cùng thông tin nghệ sĩ
                string jsonAlbums = JsonConvert.SerializeObject(resetpasswordRequest);
                var contentAlbums = new StringContent(json, Encoding.UTF8, "application/json");
                var responseAlbums = await httpClient.PostAsync("http://localhost:9999/v1/Search/Albums", contentAlbums);
                if (responseAlbums.IsSuccessStatusCode)
                {
                    var albumsContent = await responseAlbums.Content.ReadAsStringAsync();
                    var albums = JsonConvert.DeserializeObject<List<dynamic>>(albumsContent);
                    if (albums != null)
                    {
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
                        lbAlbum.Text = null;
                        panel3.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top albums data");
                }

                // Gọi API để lấy top 10 nghệ sĩ
                string jsonArtists = JsonConvert.SerializeObject(resetpasswordRequest);
                var contentArtists = new StringContent(json, Encoding.UTF8, "application/json");
                var responseArtists = await httpClient.PostAsync("http://localhost:9999/v1/Search/Artists", contentArtists);
                if (responseArtists.IsSuccessStatusCode)
                {
                    var artistsContent = await responseArtists.Content.ReadAsStringAsync();
                    var artists = JsonConvert.DeserializeObject<List<dynamic>>(artistsContent);
                    if (artists != null)
                    {
                        // Thêm card cho mỗi nghệ sĩ vào FlowLayoutPanelArtist
                        foreach (var artist in artists)
                        {
                            string imageURL = artist.IMAGE.String;
                            string NameArtist = artist.NAME;
                            Artist card = new Artist(imageURL, NameArtist);
                            flowLayoutPanelArtist.Controls.Add(card);
                        }
                    }
                    else
                    {
                        lbArtist.Text = null;
                        panel4.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top artists data");
                }
                if (lbAlbum.Text == null &&lbArtist.Text == null &&lbTrack.Text==null)
                {
                    lbAlbum.Text = "Not Found!!!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
