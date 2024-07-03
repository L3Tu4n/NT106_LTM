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
        public event EventHandler RepeatToggled;
        public event EventHandler ShuffleToggled;
        private bool isRepeatOn = false;
        private bool isShuffleOn = false;
        private Timer _timer;
        private bool _isDragging = false;

        public USCPlay()
        {
            InitializeComponent();
            InitializeTimer();
        }

        public USCPlay(string artistimage, string namesong, string nameartist, string duration, string fs_path, USCRankMusic rankMusicControl)
        {
            InitializeComponent();

            _rankMusicControl = rankMusicControl;
            _trackUrl = fs_path;

            picImage.ImageLocation = artistimage;
            lNameSong.Text = namesong;
            lNameSinger.Text = nameartist;
            lTime2.Text = duration;

            HSlider1.Minimum = 0;
            HSlider1.Maximum = 100;
            HSlider1.Value = 0;

            HSlider2.Minimum = 0;
            HSlider2.Maximum = 100;
            HSlider2.Value = 50;

            bPause.Click += (sender, e) => PauseMusic();
            bPlay.Click += (sender, e) => PlayMusic();
            bRepeat.Click += (sender, e) => ToggleRepeat();
            bShuffle.Click += (sender, e) => ToggleShuffle();
            bSkipNext.Click += (sender, e) => SkipNext();
            bSkipPrevious.Click += (sender, e) => SkipPrevious();

            HSlider2.ValueChanged += hslider2_ValueChanged;
            HSlider1.MouseDown += HSlider1_MouseDown;
            HSlider1.MouseUp += HSlider1_MouseUp;
            HSlider1.ValueChanged += HSlider1_ValueChanged;

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_rankMusicControl.IsPlaying)
            {
                var currentTime = _rankMusicControl.CurrentTime;
                var totalTime = _rankMusicControl.TotalTime;

                // Cập nhật thời gian đã phát
                lTime1.Text = $"{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";

                // Cập nhật HSlider1
                if (totalTime.TotalSeconds > 0)
                {
                    HSlider1.Value = (int)((currentTime.TotalSeconds / totalTime.TotalSeconds) * HSlider1.Maximum);
                }
            }
        }

        private void HSlider1_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            PauseMusic();
        }

        private void HSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            var totalTime = _rankMusicControl.TotalTime;
            var newTime = TimeSpan.FromSeconds((HSlider1.Value / (double)HSlider1.Maximum) * totalTime.TotalSeconds);
            _rankMusicControl.Seek(newTime);
            PlayMusic();
        }

        private void HSlider1_ValueChanged(object sender, EventArgs e)
        {
            if (_isDragging)
            {
                var totalTime = _rankMusicControl.TotalTime;
                var newTime = TimeSpan.FromSeconds((HSlider1.Value / (double)HSlider1.Maximum) * totalTime.TotalSeconds);
                lTime1.Text = $"{newTime.Minutes:D2}:{newTime.Seconds:D2}";
            }
        }

        private void hslider2_ValueChanged(object sender, EventArgs e)
        {
            _rankMusicControl.SetVolume(HSlider2.Value / (float)HSlider2.Maximum);
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        private void SkipPrevious()
        {
            _rankMusicControl.SkipPrevious();
        }

        private void SkipNext()
        {
            _rankMusicControl.SkipNext();
        }

        private void ToggleRepeat()
        {
            isRepeatOn = !isRepeatOn;
            RepeatToggled?.Invoke(this, EventArgs.Empty);
            UpdateButtonColors();
        }

        private void ToggleShuffle()
        {
            isShuffleOn = !isShuffleOn;
            ShuffleToggled?.Invoke(this, EventArgs.Empty);
            UpdateButtonColors();
        }

        public void UpdateRepeatShuffleState(bool repeatOn, bool shuffleOn)
        {
            isRepeatOn = repeatOn;
            isShuffleOn = shuffleOn;
            
            UpdateButtonColors();
        }

        private void UpdateButtonColors()
        {
            bRepeat.BackColor = isRepeatOn ? Color.Green : Color.Transparent;
            bShuffle.BackColor = isShuffleOn ? Color.Green : Color.Transparent;
        }

        private void PlayMusic()
        {
            _rankMusicControl.PlayMusic(_trackUrl, picImage.ImageLocation, lNameSong.Text, lNameSinger.Text, lTime2.Text);
            _timer.Start();
        }

        public void PauseMusic()
        {
            _rankMusicControl.PauseMusic();
            _timer.Stop();
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
