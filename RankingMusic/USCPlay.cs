using NAudio.Wave;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace RankingMusic
{
    public partial class USCPlay : UserControl
    {
        private USCRankMusic _rankMusicControl;
        private string _trackUrl;

        public USCPlay()
        {
            InitializeComponent();
        }

        public USCPlay(Image artistimage, string namesong, string nameartist, string duration, string fs_path, USCRankMusic rankMusicControl)
        {
            InitializeComponent();
            _rankMusicControl = rankMusicControl;
            _trackUrl = fs_path;

            picImage.Image = artistimage;
            lNameSong.Text = namesong;
            lNameSinger.Text = nameartist;
            lTime2.Text = duration;

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
            _rankMusicControl.PlayMusic(_trackUrl, picImage.Image, lNameSong.Text, lNameSinger.Text, lTime2.Text);
        }

        public void PauseMusic()
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

        public string duration
        {
            get { return lTime2.Text; }
            set { lTime2.Text = value; }
        }

        public string fs_path
        {
            get { return _trackUrl; }
            set { _trackUrl = value; }
        }
    }
}
