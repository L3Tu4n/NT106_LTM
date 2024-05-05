using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using Newtonsoft.Json;

namespace RankingMusic
{
    public partial class USCRankMusic : UserControl
    {
        private HttpClient httpClient;
        private WaveOutEvent _waveOut;
        private int trackCounter = 0;

        public USCRankMusic()
        {
            InitializeComponent();
            _waveOut = new WaveOutEvent();
            httpClient = new HttpClient();
            InitializePanel();
        }


        private async void InitializePanel()
        {
            try
            {
                // Gọi API để lấy top 5 bài hát có lượt nghe nhiều nhất
                var responseTracks = await httpClient.GetAsync("http://localhost:9999/v1/Top5Tracks");
                if (responseTracks.IsSuccessStatusCode)
                {
                    var tracksContent = await responseTracks.Content.ReadAsStringAsync();
                    var tracks = JsonConvert.DeserializeObject<List<dynamic>>(tracksContent);

                    // Thêm card cho mỗi bài hát vào panel
                    foreach (var track in tracks)
                    {
                        string imageURL = track.IMAGE.String;
                        string NameSong = track.NAME;
                        string NameArtist = track.ARTIST_NAME;
                        string NameAlbum = track.ALBUM_NAME;
                        string Duration = track.DURATION.String;
                        string Fs_path = track.FS_PATH.String;
                        trackCounter++;
                        string stt = trackCounter.ToString();
                        CardSong cardSong = new CardSong(stt, imageURL, NameSong, NameArtist, NameAlbum, Duration, Fs_path);
                        flowLayoutPanel1.Controls.Add(cardSong);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve top tracks data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve top tracks data: " + ex.Message);
            }
        }

        private void USCRankMusic_Load(object sender, EventArgs e)
        {
        }
    }
}
