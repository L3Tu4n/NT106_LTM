namespace RankingMusic
{
    partial class USCPlayMusic
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USCPlayMusic));
            Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges();
            this.ucPlaymusic = new Bunifu.UI.WinForms.BunifuUserControl();
            this.pImageSong = new System.Windows.Forms.Panel();
            this.HSlider1 = new Bunifu.UI.WinForms.BunifuHSlider();
            this.lNameSinger = new Bunifu.UI.WinForms.BunifuLabel();
            this.lTime2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.lTime1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.lNameSong = new Bunifu.UI.WinForms.BunifuLabel();
            this.bVolume = new Bunifu.UI.WinForms.BunifuImageButton();
            this.HSlider2 = new Bunifu.UI.WinForms.BunifuHSlider();
            this.bAddPlaylist = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bShuffle = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bRepeat = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bSkipPrevious = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bSkipNext = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bPlay = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bExit = new Bunifu.UI.WinForms.BunifuFormCaptionButton();
            this.SuspendLayout();
            // 
            // ucPlaymusic
            // 
            this.ucPlaymusic.AllowAnimations = false;
            this.ucPlaymusic.AllowBorderColorChanges = false;
            this.ucPlaymusic.AllowMouseEffects = false;
            this.ucPlaymusic.AnimationSpeed = 200;
            this.ucPlaymusic.BackColor = System.Drawing.Color.Transparent;
            this.ucPlaymusic.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ucPlaymusic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(216)))), ((int)(((byte)(87)))));
            this.ucPlaymusic.BorderRadius = 0;
            this.ucPlaymusic.BorderStyle = Bunifu.UI.WinForms.BunifuUserControl.BorderStyles.Solid;
            this.ucPlaymusic.BorderThickness = 0;
            this.ucPlaymusic.ColorContrastOnClick = 30;
            this.ucPlaymusic.ColorContrastOnHover = 30;
            this.ucPlaymusic.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucPlaymusic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPlaymusic.Image = null;
            this.ucPlaymusic.ImageMargin = new System.Windows.Forms.Padding(0);
            this.ucPlaymusic.Location = new System.Drawing.Point(0, 0);
            this.ucPlaymusic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucPlaymusic.Name = "ucPlaymusic";
            this.ucPlaymusic.ShowBorders = true;
            this.ucPlaymusic.Size = new System.Drawing.Size(1057, 161);
            this.ucPlaymusic.Style = Bunifu.UI.WinForms.BunifuUserControl.UserControlStyles.Flat;
            this.ucPlaymusic.TabIndex = 3;
            // 
            // pImageSong
            // 
            this.pImageSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pImageSong.BackgroundImage = global::RankingMusic.Properties.Resources._220px_Em_của_ngày_hôm_qua;
            this.pImageSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pImageSong.Location = new System.Drawing.Point(17, 12);
            this.pImageSong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pImageSong.Name = "pImageSong";
            this.pImageSong.Size = new System.Drawing.Size(147, 135);
            this.pImageSong.TabIndex = 14;
            // 
            // HSlider1
            // 
            this.HSlider1.AllowCursorChanges = true;
            this.HSlider1.AllowHomeEndKeysDetection = false;
            this.HSlider1.AllowIncrementalClickMoves = true;
            this.HSlider1.AllowMouseDownEffects = false;
            this.HSlider1.AllowMouseHoverEffects = false;
            this.HSlider1.AllowScrollingAnimations = true;
            this.HSlider1.AllowScrollKeysDetection = true;
            this.HSlider1.AllowScrollOptionsMenu = true;
            this.HSlider1.AllowShrinkingOnFocusLost = false;
            this.HSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HSlider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.HSlider1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HSlider1.BackgroundImage")));
            this.HSlider1.BindingContainer = null;
            this.HSlider1.BorderRadius = 2;
            this.HSlider1.BorderThickness = 1;
            this.HSlider1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HSlider1.DrawThickBorder = false;
            this.HSlider1.DurationBeforeShrink = 2000;
            this.HSlider1.ElapsedColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(216)))), ((int)(((byte)(87)))));
            this.HSlider1.LargeChange = 10;
            this.HSlider1.Location = new System.Drawing.Point(236, 60);
            this.HSlider1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HSlider1.Maximum = 100;
            this.HSlider1.Minimum = 0;
            this.HSlider1.MinimumSize = new System.Drawing.Size(0, 38);
            this.HSlider1.MinimumThumbLength = 18;
            this.HSlider1.Name = "HSlider1";
            this.HSlider1.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.HSlider1.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.HSlider1.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.HSlider1.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.HSlider1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.HSlider1.ShrinkSizeLimit = 3;
            this.HSlider1.Size = new System.Drawing.Size(749, 38);
            this.HSlider1.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.HSlider1.SliderStyle = Bunifu.UI.WinForms.BunifuHSlider.SliderStyles.Thin;
            this.HSlider1.SliderThumbStyle = Utilities.BunifuSlider.BunifuHScrollBar.SliderThumbStyles.Circular;
            this.HSlider1.SmallChange = 1;
            this.HSlider1.TabIndex = 33;
            this.HSlider1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(216)))), ((int)(((byte)(87)))));
            this.HSlider1.ThumbFillColor = System.Drawing.SystemColors.Control;
            this.HSlider1.ThumbLength = 74;
            this.HSlider1.ThumbMargin = 1;
            this.HSlider1.ThumbSize = Bunifu.UI.WinForms.BunifuHSlider.ThumbSizes.Medium;
            this.HSlider1.ThumbStyle = Bunifu.UI.WinForms.BunifuHSlider.ThumbStyles.Outline;
            this.HSlider1.Value = 50;
            // 
            // lNameSinger
            // 
            this.lNameSinger.AllowParentOverrides = false;
            this.lNameSinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNameSinger.AutoEllipsis = false;
            this.lNameSinger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lNameSinger.CursorType = null;
            this.lNameSinger.Font = new System.Drawing.Font("UTM Avo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNameSinger.ForeColor = System.Drawing.Color.Transparent;
            this.lNameSinger.Location = new System.Drawing.Point(177, 123);
            this.lNameSinger.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lNameSinger.Name = "lNameSinger";
            this.lNameSinger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lNameSinger.Size = new System.Drawing.Size(130, 26);
            this.lNameSinger.TabIndex = 32;
            this.lNameSinger.Text = "Sơn Tùng M-TP";
            this.lNameSinger.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lNameSinger.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lTime2
            // 
            this.lTime2.AllowParentOverrides = false;
            this.lTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lTime2.AutoEllipsis = false;
            this.lTime2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lTime2.CursorType = null;
            this.lTime2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lTime2.ForeColor = System.Drawing.Color.Transparent;
            this.lTime2.Location = new System.Drawing.Point(1003, 69);
            this.lTime2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lTime2.Name = "lTime2";
            this.lTime2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lTime2.Size = new System.Drawing.Size(39, 21);
            this.lTime2.TabIndex = 31;
            this.lTime2.Text = "03:52";
            this.lTime2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lTime2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lTime1
            // 
            this.lTime1.AllowParentOverrides = false;
            this.lTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTime1.AutoEllipsis = false;
            this.lTime1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lTime1.CursorType = null;
            this.lTime1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lTime1.ForeColor = System.Drawing.Color.Transparent;
            this.lTime1.Location = new System.Drawing.Point(177, 69);
            this.lTime1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lTime1.Name = "lTime1";
            this.lTime1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lTime1.Size = new System.Drawing.Size(39, 21);
            this.lTime1.TabIndex = 30;
            this.lTime1.Text = "00:00";
            this.lTime1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lTime1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lNameSong
            // 
            this.lNameSong.AllowParentOverrides = false;
            this.lNameSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNameSong.AutoEllipsis = false;
            this.lNameSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lNameSong.CursorType = null;
            this.lNameSong.Font = new System.Drawing.Font("UTM Avo", 11.25F, System.Drawing.FontStyle.Bold);
            this.lNameSong.ForeColor = System.Drawing.Color.Transparent;
            this.lNameSong.Location = new System.Drawing.Point(177, 94);
            this.lNameSong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lNameSong.Name = "lNameSong";
            this.lNameSong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lNameSong.Size = new System.Drawing.Size(219, 28);
            this.lNameSong.TabIndex = 29;
            this.lNameSong.Text = "Em của ngày hôm qua";
            this.lNameSong.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lNameSong.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bVolume
            // 
            this.bVolume.ActiveImage = null;
            this.bVolume.AllowAnimations = true;
            this.bVolume.AllowBuffering = false;
            this.bVolume.AllowToggling = false;
            this.bVolume.AllowZooming = true;
            this.bVolume.AllowZoomingOnFocus = false;
            this.bVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bVolume.BackgroundImage = global::RankingMusic.Properties.Resources.baseline_volume_up_white_48dp;
            this.bVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bVolume.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bVolume.ErrorImage = null;
            this.bVolume.FadeWhenInactive = false;
            this.bVolume.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bVolume.Image = global::RankingMusic.Properties.Resources.baseline_volume_up_white_48dp;
            this.bVolume.ImageActive = null;
            this.bVolume.ImageLocation = null;
            this.bVolume.ImageMargin = 0;
            this.bVolume.ImageSize = new System.Drawing.Size(32, 30);
            this.bVolume.ImageZoomSize = new System.Drawing.Size(33, 31);
            this.bVolume.InitialImage = null;
            this.bVolume.Location = new System.Drawing.Point(837, 101);
            this.bVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bVolume.Name = "bVolume";
            this.bVolume.Rotation = 0;
            this.bVolume.ShowActiveImage = false;
            this.bVolume.ShowCursorChanges = true;
            this.bVolume.ShowImageBorders = true;
            this.bVolume.ShowSizeMarkers = false;
            this.bVolume.Size = new System.Drawing.Size(33, 31);
            this.bVolume.TabIndex = 31;
            this.bVolume.ToolTipText = "Tăng/Giảm âm lượng";
            this.bVolume.WaitOnLoad = false;
            this.bVolume.Zoom = 0;
            this.bVolume.ZoomSpeed = 10;
            // 
            // HSlider2
            // 
            this.HSlider2.AllowCursorChanges = true;
            this.HSlider2.AllowHomeEndKeysDetection = false;
            this.HSlider2.AllowIncrementalClickMoves = true;
            this.HSlider2.AllowMouseDownEffects = false;
            this.HSlider2.AllowMouseHoverEffects = false;
            this.HSlider2.AllowScrollingAnimations = true;
            this.HSlider2.AllowScrollKeysDetection = true;
            this.HSlider2.AllowScrollOptionsMenu = true;
            this.HSlider2.AllowShrinkingOnFocusLost = false;
            this.HSlider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HSlider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.HSlider2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HSlider2.BackgroundImage")));
            this.HSlider2.BindingContainer = null;
            this.HSlider2.BorderRadius = 2;
            this.HSlider2.BorderThickness = 1;
            this.HSlider2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HSlider2.DrawThickBorder = false;
            this.HSlider2.DurationBeforeShrink = 2000;
            this.HSlider2.ElapsedColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(216)))), ((int)(((byte)(87)))));
            this.HSlider2.LargeChange = 10;
            this.HSlider2.Location = new System.Drawing.Point(879, 97);
            this.HSlider2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HSlider2.Maximum = 100;
            this.HSlider2.Minimum = 0;
            this.HSlider2.MinimumSize = new System.Drawing.Size(0, 38);
            this.HSlider2.MinimumThumbLength = 18;
            this.HSlider2.Name = "HSlider2";
            this.HSlider2.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.HSlider2.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.HSlider2.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.HSlider2.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.HSlider2.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.HSlider2.ShrinkSizeLimit = 3;
            this.HSlider2.Size = new System.Drawing.Size(167, 38);
            this.HSlider2.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.HSlider2.SliderStyle = Bunifu.UI.WinForms.BunifuHSlider.SliderStyles.Thin;
            this.HSlider2.SliderThumbStyle = Utilities.BunifuSlider.BunifuHScrollBar.SliderThumbStyles.Circular;
            this.HSlider2.SmallChange = 1;
            this.HSlider2.TabIndex = 30;
            this.HSlider2.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(216)))), ((int)(((byte)(87)))));
            this.HSlider2.ThumbFillColor = System.Drawing.SystemColors.Control;
            this.HSlider2.ThumbLength = 18;
            this.HSlider2.ThumbMargin = 1;
            this.HSlider2.ThumbSize = Bunifu.UI.WinForms.BunifuHSlider.ThumbSizes.Medium;
            this.HSlider2.ThumbStyle = Bunifu.UI.WinForms.BunifuHSlider.ThumbStyles.Outline;
            this.HSlider2.Value = 50;
            // 
            // bAddPlaylist
            // 
            this.bAddPlaylist.ActiveImage = null;
            this.bAddPlaylist.AllowAnimations = true;
            this.bAddPlaylist.AllowBuffering = false;
            this.bAddPlaylist.AllowToggling = false;
            this.bAddPlaylist.AllowZooming = true;
            this.bAddPlaylist.AllowZoomingOnFocus = true;
            this.bAddPlaylist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bAddPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bAddPlaylist.BackgroundImage = global::RankingMusic.Properties.Resources.playlist_add_48dp;
            this.bAddPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddPlaylist.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bAddPlaylist.ErrorImage = null;
            this.bAddPlaylist.FadeWhenInactive = false;
            this.bAddPlaylist.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bAddPlaylist.Image = global::RankingMusic.Properties.Resources.playlist_add_48dp1;
            this.bAddPlaylist.ImageActive = null;
            this.bAddPlaylist.ImageLocation = null;
            this.bAddPlaylist.ImageMargin = 0;
            this.bAddPlaylist.ImageSize = new System.Drawing.Size(46, 42);
            this.bAddPlaylist.ImageZoomSize = new System.Drawing.Size(47, 43);
            this.bAddPlaylist.InitialImage = null;
            this.bAddPlaylist.Location = new System.Drawing.Point(740, 16);
            this.bAddPlaylist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAddPlaylist.Name = "bAddPlaylist";
            this.bAddPlaylist.Rotation = 0;
            this.bAddPlaylist.ShowActiveImage = false;
            this.bAddPlaylist.ShowCursorChanges = true;
            this.bAddPlaylist.ShowImageBorders = true;
            this.bAddPlaylist.ShowSizeMarkers = false;
            this.bAddPlaylist.Size = new System.Drawing.Size(47, 43);
            this.bAddPlaylist.TabIndex = 42;
            this.bAddPlaylist.ToolTipText = "Tăng/Giảm âm lượng";
            this.bAddPlaylist.WaitOnLoad = false;
            this.bAddPlaylist.Zoom = 0;
            this.bAddPlaylist.ZoomSpeed = 10;
            // 
            // bShuffle
            // 
            this.bShuffle.ActiveImage = null;
            this.bShuffle.AllowAnimations = true;
            this.bShuffle.AllowBuffering = false;
            this.bShuffle.AllowToggling = false;
            this.bShuffle.AllowZooming = true;
            this.bShuffle.AllowZoomingOnFocus = true;
            this.bShuffle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bShuffle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bShuffle.BackgroundImage = global::RankingMusic.Properties.Resources.baseline_shuffle_white_48dp;
            this.bShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bShuffle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bShuffle.ErrorImage = null;
            this.bShuffle.FadeWhenInactive = false;
            this.bShuffle.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bShuffle.Image = global::RankingMusic.Properties.Resources.baseline_shuffle_white_48dp;
            this.bShuffle.ImageActive = null;
            this.bShuffle.ImageLocation = null;
            this.bShuffle.ImageMargin = 0;
            this.bShuffle.ImageSize = new System.Drawing.Size(39, 36);
            this.bShuffle.ImageZoomSize = new System.Drawing.Size(40, 37);
            this.bShuffle.InitialImage = null;
            this.bShuffle.Location = new System.Drawing.Point(487, 18);
            this.bShuffle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bShuffle.Name = "bShuffle";
            this.bShuffle.Rotation = 0;
            this.bShuffle.ShowActiveImage = false;
            this.bShuffle.ShowCursorChanges = true;
            this.bShuffle.ShowImageBorders = true;
            this.bShuffle.ShowSizeMarkers = false;
            this.bShuffle.Size = new System.Drawing.Size(40, 37);
            this.bShuffle.TabIndex = 41;
            this.bShuffle.ToolTipText = "Tăng/Giảm âm lượng";
            this.bShuffle.WaitOnLoad = false;
            this.bShuffle.Zoom = 0;
            this.bShuffle.ZoomSpeed = 10;
            // 
            // bRepeat
            // 
            this.bRepeat.ActiveImage = null;
            this.bRepeat.AllowAnimations = true;
            this.bRepeat.AllowBuffering = false;
            this.bRepeat.AllowToggling = false;
            this.bRepeat.AllowZooming = true;
            this.bRepeat.AllowZoomingOnFocus = true;
            this.bRepeat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bRepeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bRepeat.BackgroundImage = global::RankingMusic.Properties.Resources.baseline_repeat_white_48dp;
            this.bRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bRepeat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bRepeat.ErrorImage = null;
            this.bRepeat.FadeWhenInactive = false;
            this.bRepeat.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bRepeat.Image = global::RankingMusic.Properties.Resources.baseline_repeat_white_48dp;
            this.bRepeat.ImageActive = null;
            this.bRepeat.ImageLocation = null;
            this.bRepeat.ImageMargin = 0;
            this.bRepeat.ImageSize = new System.Drawing.Size(39, 36);
            this.bRepeat.ImageZoomSize = new System.Drawing.Size(40, 37);
            this.bRepeat.InitialImage = null;
            this.bRepeat.Location = new System.Drawing.Point(692, 18);
            this.bRepeat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bRepeat.Name = "bRepeat";
            this.bRepeat.Rotation = 0;
            this.bRepeat.ShowActiveImage = false;
            this.bRepeat.ShowCursorChanges = true;
            this.bRepeat.ShowImageBorders = true;
            this.bRepeat.ShowSizeMarkers = false;
            this.bRepeat.Size = new System.Drawing.Size(40, 37);
            this.bRepeat.TabIndex = 40;
            this.bRepeat.ToolTipText = "Tăng/Giảm âm lượng";
            this.bRepeat.WaitOnLoad = false;
            this.bRepeat.Zoom = 0;
            this.bRepeat.ZoomSpeed = 10;
            // 
            // bSkipPrevious
            // 
            this.bSkipPrevious.ActiveImage = null;
            this.bSkipPrevious.AllowAnimations = true;
            this.bSkipPrevious.AllowBuffering = false;
            this.bSkipPrevious.AllowToggling = false;
            this.bSkipPrevious.AllowZooming = true;
            this.bSkipPrevious.AllowZoomingOnFocus = true;
            this.bSkipPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bSkipPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bSkipPrevious.BackgroundImage = global::RankingMusic.Properties.Resources.baseline_skip_previous_white_48dp;
            this.bSkipPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSkipPrevious.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bSkipPrevious.ErrorImage = null;
            this.bSkipPrevious.FadeWhenInactive = false;
            this.bSkipPrevious.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bSkipPrevious.Image = global::RankingMusic.Properties.Resources.baseline_skip_previous_white_48dp;
            this.bSkipPrevious.ImageActive = null;
            this.bSkipPrevious.ImageLocation = null;
            this.bSkipPrevious.ImageMargin = 0;
            this.bSkipPrevious.ImageSize = new System.Drawing.Size(39, 36);
            this.bSkipPrevious.ImageZoomSize = new System.Drawing.Size(40, 37);
            this.bSkipPrevious.InitialImage = null;
            this.bSkipPrevious.Location = new System.Drawing.Point(535, 18);
            this.bSkipPrevious.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSkipPrevious.Name = "bSkipPrevious";
            this.bSkipPrevious.Rotation = 0;
            this.bSkipPrevious.ShowActiveImage = false;
            this.bSkipPrevious.ShowCursorChanges = true;
            this.bSkipPrevious.ShowImageBorders = true;
            this.bSkipPrevious.ShowSizeMarkers = false;
            this.bSkipPrevious.Size = new System.Drawing.Size(40, 37);
            this.bSkipPrevious.TabIndex = 39;
            this.bSkipPrevious.ToolTipText = "Tăng/Giảm âm lượng";
            this.bSkipPrevious.WaitOnLoad = false;
            this.bSkipPrevious.Zoom = 0;
            this.bSkipPrevious.ZoomSpeed = 10;
            // 
            // bSkipNext
            // 
            this.bSkipNext.ActiveImage = null;
            this.bSkipNext.AllowAnimations = true;
            this.bSkipNext.AllowBuffering = false;
            this.bSkipNext.AllowToggling = false;
            this.bSkipNext.AllowZooming = true;
            this.bSkipNext.AllowZoomingOnFocus = true;
            this.bSkipNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bSkipNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bSkipNext.BackgroundImage = global::RankingMusic.Properties.Resources.baseline_skip_next_white_48dp;
            this.bSkipNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSkipNext.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bSkipNext.ErrorImage = null;
            this.bSkipNext.FadeWhenInactive = false;
            this.bSkipNext.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bSkipNext.Image = global::RankingMusic.Properties.Resources.baseline_skip_next_white_48dp;
            this.bSkipNext.ImageActive = null;
            this.bSkipNext.ImageLocation = null;
            this.bSkipNext.ImageMargin = 0;
            this.bSkipNext.ImageSize = new System.Drawing.Size(39, 36);
            this.bSkipNext.ImageZoomSize = new System.Drawing.Size(40, 37);
            this.bSkipNext.InitialImage = null;
            this.bSkipNext.Location = new System.Drawing.Point(644, 18);
            this.bSkipNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSkipNext.Name = "bSkipNext";
            this.bSkipNext.Rotation = 0;
            this.bSkipNext.ShowActiveImage = false;
            this.bSkipNext.ShowCursorChanges = true;
            this.bSkipNext.ShowImageBorders = true;
            this.bSkipNext.ShowSizeMarkers = false;
            this.bSkipNext.Size = new System.Drawing.Size(40, 37);
            this.bSkipNext.TabIndex = 38;
            this.bSkipNext.ToolTipText = "Tăng/Giảm âm lượng";
            this.bSkipNext.WaitOnLoad = false;
            this.bSkipNext.Zoom = 0;
            this.bSkipNext.ZoomSpeed = 10;
            // 
            // bPlay
            // 
            this.bPlay.ActiveImage = null;
            this.bPlay.AllowAnimations = true;
            this.bPlay.AllowBuffering = false;
            this.bPlay.AllowToggling = false;
            this.bPlay.AllowZooming = true;
            this.bPlay.AllowZoomingOnFocus = true;
            this.bPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bPlay.BackgroundImage = global::RankingMusic.Properties.Resources.baseline_play_circle_outline_white_48dp;
            this.bPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bPlay.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bPlay.ErrorImage = null;
            this.bPlay.FadeWhenInactive = false;
            this.bPlay.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bPlay.Image = global::RankingMusic.Properties.Resources.baseline_play_circle_outline_white_48dp;
            this.bPlay.ImageActive = null;
            this.bPlay.ImageLocation = null;
            this.bPlay.ImageMargin = 0;
            this.bPlay.ImageSize = new System.Drawing.Size(52, 48);
            this.bPlay.ImageZoomSize = new System.Drawing.Size(53, 49);
            this.bPlay.InitialImage = null;
            this.bPlay.Location = new System.Drawing.Point(583, 12);
            this.bPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bPlay.Name = "bPlay";
            this.bPlay.Rotation = 0;
            this.bPlay.ShowActiveImage = false;
            this.bPlay.ShowCursorChanges = true;
            this.bPlay.ShowImageBorders = true;
            this.bPlay.ShowSizeMarkers = false;
            this.bPlay.Size = new System.Drawing.Size(53, 49);
            this.bPlay.TabIndex = 37;
            this.bPlay.ToolTipText = "Tăng/Giảm âm lượng";
            this.bPlay.WaitOnLoad = false;
            this.bPlay.Zoom = 0;
            this.bPlay.ZoomSpeed = 10;
            // 
            // bExit
            // 
            this.bExit.AllowAnimations = true;
            this.bExit.AllowBorderColorChanges = true;
            this.bExit.AllowDefaults = true;
            this.bExit.AllowMouseEffects = true;
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.AnimationSpeed = 200;
            this.bExit.AutoSizeCaptions = true;
            this.bExit.BackColor = System.Drawing.Color.Transparent;
            this.bExit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.BackHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.BackPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.BorderPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.BorderRadius = 0;
            this.bExit.BorderStyle = Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderStyles.Solid;
            this.bExit.BorderThickness = 0;
            this.bExit.CaptionType = Bunifu.UI.WinForms.BunifuFormCaptionButton.CaptionTypes.Minimize;
            this.bExit.ColorContrastOnClick = 30;
            this.bExit.ColorContrastOnHover = 30;
            this.bExit.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bExit.CustomizableEdges = borderEdges2;
            this.bExit.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bExit.IconColor = System.Drawing.Color.White;
            this.bExit.IconHoverColor = System.Drawing.Color.White;
            this.bExit.IconPressedColor = System.Drawing.Color.White;
            this.bExit.Image = ((System.Drawing.Image)(resources.GetObject("bExit.Image")));
            this.bExit.ImageMargin = new System.Windows.Forms.Padding(0);
            this.bExit.ImageSize = new System.Drawing.Size(20, 20);
            this.bExit.Location = new System.Drawing.Point(1017, 9);
            this.bExit.Margin = new System.Windows.Forms.Padding(0);
            this.bExit.Name = "bExit";
            this.bExit.ShowBorders = true;
            this.bExit.Size = new System.Drawing.Size(36, 37);
            this.bExit.TabIndex = 43;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // USCPlayMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bAddPlaylist);
            this.Controls.Add(this.bShuffle);
            this.Controls.Add(this.bRepeat);
            this.Controls.Add(this.bSkipPrevious);
            this.Controls.Add(this.bSkipNext);
            this.Controls.Add(this.bPlay);
            this.Controls.Add(this.bVolume);
            this.Controls.Add(this.HSlider1);
            this.Controls.Add(this.HSlider2);
            this.Controls.Add(this.lNameSinger);
            this.Controls.Add(this.lTime2);
            this.Controls.Add(this.lTime1);
            this.Controls.Add(this.lNameSong);
            this.Controls.Add(this.pImageSong);
            this.Controls.Add(this.ucPlaymusic);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "USCPlayMusic";
            this.Size = new System.Drawing.Size(1057, 161);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuUserControl ucPlaymusic;
        private System.Windows.Forms.Panel pImageSong;
        private Bunifu.UI.WinForms.BunifuHSlider HSlider1;
        private Bunifu.UI.WinForms.BunifuLabel lNameSinger;
        private Bunifu.UI.WinForms.BunifuLabel lTime2;
        private Bunifu.UI.WinForms.BunifuLabel lTime1;
        private Bunifu.UI.WinForms.BunifuLabel lNameSong;
        private Bunifu.UI.WinForms.BunifuImageButton bVolume;
        private Bunifu.UI.WinForms.BunifuHSlider HSlider2;
        private Bunifu.UI.WinForms.BunifuImageButton bAddPlaylist;
        private Bunifu.UI.WinForms.BunifuImageButton bShuffle;
        private Bunifu.UI.WinForms.BunifuImageButton bRepeat;
        private Bunifu.UI.WinForms.BunifuImageButton bSkipPrevious;
        private Bunifu.UI.WinForms.BunifuImageButton bSkipNext;
        private Bunifu.UI.WinForms.BunifuImageButton bPlay;
        private Bunifu.UI.WinForms.BunifuFormCaptionButton bExit;
    }
}
