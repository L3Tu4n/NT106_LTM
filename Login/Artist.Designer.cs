namespace Music
{
    partial class Artist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Artist));
            this.imageArtist = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lbNameAlbum = new Bunifu.UI.WinForms.BunifuLabel();
            this.lbNameArtist = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imageArtist)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageArtist
            // 
            this.imageArtist.AllowFocused = false;
            this.imageArtist.AutoSizeHeight = true;
            this.imageArtist.BorderRadius = 91;
            this.imageArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageArtist.Image = ((System.Drawing.Image)(resources.GetObject("imageArtist.Image")));
            this.imageArtist.IsCircle = true;
            this.imageArtist.Location = new System.Drawing.Point(0, 0);
            this.imageArtist.Name = "imageArtist";
            this.imageArtist.Size = new System.Drawing.Size(183, 183);
            this.imageArtist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageArtist.TabIndex = 0;
            this.imageArtist.TabStop = false;
            this.imageArtist.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // lbNameAlbum
            // 
            this.lbNameAlbum.AllowParentOverrides = false;
            this.lbNameAlbum.AutoEllipsis = false;
            this.lbNameAlbum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbNameAlbum.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbNameAlbum.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameAlbum.ForeColor = System.Drawing.Color.White;
            this.lbNameAlbum.Location = new System.Drawing.Point(34, 195);
            this.lbNameAlbum.Name = "lbNameAlbum";
            this.lbNameAlbum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNameAlbum.Size = new System.Drawing.Size(118, 23);
            this.lbNameAlbum.TabIndex = 2;
            this.lbNameAlbum.Text = "Sơn Tùng MTP";
            this.lbNameAlbum.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbNameAlbum.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lbNameArtist
            // 
            this.lbNameArtist.AllowParentOverrides = false;
            this.lbNameArtist.AutoEllipsis = false;
            this.lbNameArtist.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbNameArtist.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbNameArtist.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameArtist.ForeColor = System.Drawing.Color.Silver;
            this.lbNameArtist.Location = new System.Drawing.Point(63, 223);
            this.lbNameArtist.Name = "lbNameArtist";
            this.lbNameArtist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNameArtist.Size = new System.Drawing.Size(58, 23);
            this.lbNameArtist.TabIndex = 3;
            this.lbNameArtist.Text = "Nghệ sĩ";
            this.lbNameArtist.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbNameArtist.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.imageArtist);
            this.bunifuPanel1.Location = new System.Drawing.Point(3, 12);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(183, 186);
            this.bunifuPanel1.TabIndex = 4;
            // 
            // Artist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.Black;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BorderRadius = 36;
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.lbNameArtist);
            this.Controls.Add(this.lbNameAlbum);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Artist";
            this.Size = new System.Drawing.Size(186, 249);
            ((System.ComponentModel.ISupportInitialize)(this.imageArtist)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox imageArtist;
        private Bunifu.UI.WinForms.BunifuLabel lbNameAlbum;
        private Bunifu.UI.WinForms.BunifuLabel lbNameArtist;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
    }
}
