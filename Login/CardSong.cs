using Music;
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
        private USCSinger _singerControl;

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
            lNumber.Text = FormatTrackNumber(stt);
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

        public CardSong(string stt, string imageUrl, string namesong, string nameartist, string namealbum, string duration, string fs_path, USCSinger singerControl)
        {
            InitializeComponent();
            _singerControl = singerControl;
            _trackUrl = fs_path;

            // Gán các giá trị cho các thuộc tính
            lNumber.Text = FormatTrackNumber(stt);
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

        private string FormatTrackNumber(string stt)
        {
            if (int.TryParse(stt, out int number))
            {
                if (number >= 1 && number <= 9)
                {
                    return number.ToString("D2");
                }
            }
            return stt;
        }

        private void PlayMusic()
        {
            if (_rankMusicControl != null)
            {
                _singerControl?.StopMusic(); // Dừng nhạc ở USCSinger nếu nó đang phát
                _rankMusicControl.PlayMusic(_trackUrl, picImage.ImageLocation, lNameSong.Text, lNameSinger.Text, lTime.Text);
            }
            else if (_singerControl != null)
            {
                _rankMusicControl?.StopMusic(); // Dừng nhạc ở USCRankMusic nếu nó đang phát
                _singerControl.PlayMusic(_trackUrl, picImage.ImageLocation, lNameSong.Text, lNameSinger.Text, lTime.Text);
            }
        }

        private void PauseMusic()
        {
            if (_rankMusicControl != null)
            {
                _rankMusicControl.PauseMusic();
            }
            else if (_singerControl != null)
            {
                _singerControl.PauseMusic();
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
