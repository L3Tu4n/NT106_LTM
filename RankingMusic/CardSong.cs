using NAudio.Wave;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace RankingMusic
{
    public partial class CardSong : Bunifu.UI.WinForms.BunifuUserControl
    {
        private string _trackUrl;
        private USCRankMusic _rankMusicControl;

        public CardSong()
        {
            InitializeComponent();
        }

        public CardSong(string stt, string imageUrl, string namesong, string nameartist, string namealbum, string duration, string fs_path, USCRankMusic rankMusicControl)
        {
            InitializeComponent();
            _rankMusicControl = rankMusicControl;
            _trackUrl = fs_path;

            // Gán các giá trị cho các thuộc tính
            lNumber.Text = stt;
            picImage.Image = LoadImageFromUrl(imageUrl);
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
                PlayMusic();
            };
        }

        private void PlayMusic()
        {
            _rankMusicControl.PlayMusic(_trackUrl, picImage.Image, lNameSong.Text, lNameSinger.Text, lTime.Text);
        }

        private void PauseMusic()
        {
            _rankMusicControl.PauseMusic();
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

        public void ShowPlayButton()
        {
            bPlay.Visible = true;
            bPause.Visible = false;
        }

        public void ShowPauseButton()
        {
            bPlay.Visible = false;
            bPause.Visible = true;
        }


        public void SetPlayPauseButtonState(bool isPlaying)
        {
            if (isPlaying)
            {
                ShowPauseButton();
            }
            else
            {
                ShowPlayButton();
            }
        }

        public string stt
        {
            get { return lNumber.Text; }
            set { lNumber.Text = value; }
        }
        public Image TrackImage
        {
            get { return picImage.Image; }
            set { picImage.Image = value; }
        }
        public string namesong
        {
            get { return lNameSong.Text; }
            set { lNameSong.Text = value; }
        }
        public string nameartist
        {
            get { return lNameSinger.Text; }
            set { lNameSinger.Text = value; }
        }
        public string namealbum
        {
            get { return lNameAlbum.Text; }
            set { lNameAlbum.Text = value; }
        }
        public string duration
        {
            get { return lTime.Text; }
            set { lTime.Text = value; }
        }

        public string fs_path
        {
            get { return _trackUrl; }
            set { _trackUrl = value; }
        }
    }
}
