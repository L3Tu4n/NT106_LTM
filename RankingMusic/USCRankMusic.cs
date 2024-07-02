using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private AudioFileReader _audioFileReader;
        private string _currentTrackPath;
        private Image _currentTrackImage;
        private string _currentTrackName;
        private string _currentTrackArtist;
        private string _currentTrackDuration;
        private bool _isPlaying = false;
        private bool _isPaused = false;
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

                        CardSong cardSong = new CardSong(stt, imageURL, NameSong, NameArtist, NameAlbum, Duration, Fs_path, this);
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

        public void PlayMusic(string trackUrl, Image trackImage, string trackName, string trackArtist, string trackDuration)
        {
            try
            {
                if (_isPaused && _currentTrackPath == trackUrl)
                {
                    // Nếu bài hát đang tạm dừng và đường dẫn bài hát giống nhau, tiếp tục phát từ vị trí đã dừng
                    _waveOut.Play();
                    _isPlaying = true;
                    _isPaused = false;

                    // Cập nhật trạng thái nút cho tất cả các CardSong
                    UpdateCardSongsPlayPauseState(trackUrl, true);

                    // Cập nhật trạng thái nút cho tất cả các USCPlay
                    UpdateUSCPlaysPlayPauseState(trackUrl, true);
                }
                else
                {
                    StopMusic(); // Dừng bất kỳ bài hát nào đang phát

                    _audioFileReader = new AudioFileReader(trackUrl);
                    _waveOut.Init(_audioFileReader);
                    _waveOut.Play();
                    _isPlaying = true;
                    _isPaused = false;
                    _currentTrackPath = trackUrl;
                    _currentTrackImage = trackImage;
                    _currentTrackName = trackName;
                    _currentTrackArtist = trackArtist;
                    _currentTrackDuration = trackDuration;

                    // Cập nhật trạng thái nút cho tất cả các CardSong
                    UpdateCardSongsPlayPauseState(trackUrl, true);

                    // Cập nhật trạng thái nút cho tất cả các USCPlay
                    UpdateUSCPlaysPlayPauseState(trackUrl, true);

                    // Thêm USCPlay vào panel
                    USCPlay uscPlay = new USCPlay(_currentTrackImage, _currentTrackName, _currentTrackArtist, _currentTrackDuration, _currentTrackPath, this); 
                    flowLayoutPanel2.Controls.Clear();
                    flowLayoutPanel2.Controls.Add(uscPlay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi phát nhạc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCardSongsPlayPauseState(string trackUrl, bool isPlaying)
        {
            foreach (CardSong card in flowLayoutPanel1.Controls)
            {
                card.SetPlayPauseButtonState(card.fs_path == trackUrl && isPlaying);
            }
        }

        private void UpdateUSCPlaysPlayPauseState(string trackUrl, bool isPlaying)
        {
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is USCPlay uscPlay)
                {
                    uscPlay.SetPlayPauseButtonState(uscPlay.fs_path == trackUrl && isPlaying);
                }
            }
        }


        public void PauseMusic()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
            {
                _waveOut.Pause();
                _isPlaying = false;
                _isPaused = true;

                // Cập nhật trạng thái nút cho tất cả các CardSong
                UpdateCardSongsPlayPauseState(_currentTrackPath, false);

                // Cập nhật trạng thái nút cho tất cả các USCPlay
                UpdateUSCPlaysPlayPauseState(_currentTrackPath, false);
            }
        }

        public void StopMusic()
        {
            if (_waveOut != null && (_waveOut.PlaybackState == PlaybackState.Playing || _waveOut.PlaybackState == PlaybackState.Paused))
            {
                _waveOut.Stop();
                _isPlaying = false;
                _isPaused = false;
            }
        }
    }
}
