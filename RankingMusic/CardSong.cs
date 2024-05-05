using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RankingMusic
{   public partial class CardSong : Bunifu.UI.WinForms.BunifuUserControl
    {
        private WaveOutEvent _waveOut;
        bool isPlaying = false;
        private AudioFileReader _audioFileReader;
        private string currentTrackPath; // Lưu đường dẫn của bài hát đang phát

        public CardSong()
        {
            InitializeComponent();
        }

        public CardSong(string stt, string imageUrl, string namesong, string nameartist, string namealbum, string duration, string fs_path)
        {
            InitializeComponent();

            // Gán các giá trị cho các thuộc tính
            lNumber.Text = stt;
            Image image = LoadImageFromUrl(imageUrl);
            if (image != null)
            {
                picImage.Image = image;
            }
            lNameSong.Text = namesong;
            lNameSinger.Text = nameartist;
            lNameAlbum.Text = namealbum;
            lTime.Text = duration;

            bPause.Visible = false;

            bPause.Click += (sender, e) =>
            {
                PauseMusic();
            };

            bPlay.Click += (sender, e) =>
            {
                if (currentTrackPath == fs_path)
                {
                    if (!isPlaying)
                    {
                        ResumeMusic();
                    }
                }
                else
                {
                    PlayMusic(fs_path);
                    currentTrackPath = fs_path;
                    bPlay.Visible = false;
                    bPause.Visible = true;
                }
            };

        }

        private void PauseMusic()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
            {
                _waveOut.Pause();
                isPlaying = false;
                bPause.Visible = false;
                bPlay.Visible = true;
            }
        }

        private void ResumeMusic()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Paused)
            {
                _waveOut.Play();
                isPlaying = true;
                bPlay.Visible = false;
                bPause.Visible = true;
            }
        }

        private void HandlePlaybackStopped(object sender, StoppedEventArgs args)
        {
            _audioFileReader.Position = 0;
            isPlaying = false;
            bPause.Visible = false;
            bPlay.Visible = true;
        }


        private void PlayMusic(string trackUrl)
        {
            try
            {
                using (var inputStream = new MediaFoundationReader(trackUrl))
                {
                    if (_waveOut == null)
                    {
                        _waveOut = new WaveOutEvent();
                    }
                    else if (_waveOut.PlaybackState == PlaybackState.Playing) // Đang phát, dừng trước khi chơi bài mới
                    {
                        _waveOut.Stop();
                        isPlaying = false; // Thiết lập lại trạng thái khi bài hát kết thúc
                    }

                    _audioFileReader = new AudioFileReader(trackUrl);
                    _waveOut.Init(_audioFileReader);
                    _waveOut.Play();
                    isPlaying = true; // Đã bắt đầu phát
                    currentTrackPath = trackUrl; // Cập nhật đường dẫn bài hát đang phát

                    // Gắn sự kiện cho sự kiện khi bài hát kết thúc
                    _waveOut.PlaybackStopped += HandlePlaybackStopped;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi phát nhạc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(url);
                    using (var stream = new System.IO.MemoryStream(data))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load image from URL: " + ex.Message);
                return null;
            }
        }

        public string stt
        {
            get
            {
                return lNumber.Text;
            }
            set
            {
                lNumber.Text = value;
            }
        }
        public Image TrackImage
        {
            get
            {
                return picImage.Image;
            }
            set
            {
                picImage.Image = value;
            }
        }
        public string namesong
        {
            get
            {
                return lNameSong.Text;
            }
            set
            {
                lNameSong.Text = value;
            }
        }
        public string nameartist
        {
            get
            {
                return lNameSinger.Text;
            }
            set
            {
                lNameSinger.Text = value;
            }
        }
        public string namealbum
        {
            get
            {
                return lNameAlbum.Text;
            }
            set
            {
                lNameAlbum.Text = value;
            }
        }
        public string duration
        {
            get
            {
                return lTime.Text;
            }
            set
            {
                lTime.Text = value;
            }
        }
    }
}
