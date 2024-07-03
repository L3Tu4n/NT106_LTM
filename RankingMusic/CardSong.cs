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
            picImage.ImageLocation = imageUrl;
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
            _rankMusicControl.PlayMusic(_trackUrl, picImage.ImageLocation, lNameSong.Text, lNameSinger.Text, lTime.Text);
        }

        private void PauseMusic()
        {
            _rankMusicControl.PauseMusic();
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
        public string TrackImage
        {
            get { return picImage.ImageLocation; }
            set { picImage.ImageLocation = value; }
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
