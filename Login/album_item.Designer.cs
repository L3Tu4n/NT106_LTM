namespace Music
{
    partial class album_item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(album_item));
            this.lbNameAlbum = new Bunifu.UI.WinForms.BunifuLabel();
            this.lbNameArtist = new Bunifu.UI.WinForms.BunifuLabel();
            this.itemImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNameAlbum
            // 
            this.lbNameAlbum.AllowParentOverrides = false;
            this.lbNameAlbum.AutoEllipsis = false;
            this.lbNameAlbum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbNameAlbum.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbNameAlbum.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameAlbum.ForeColor = System.Drawing.Color.White;
            this.lbNameAlbum.Location = new System.Drawing.Point(50, 183);
            this.lbNameAlbum.Name = "lbNameAlbum";
            this.lbNameAlbum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNameAlbum.Size = new System.Drawing.Size(75, 23);
            this.lbNameAlbum.TabIndex = 1;
            this.lbNameAlbum.Text = "Đánh Đổi";
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
            this.lbNameArtist.Location = new System.Drawing.Point(65, 212);
            this.lbNameArtist.Name = "lbNameArtist";
            this.lbNameArtist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNameArtist.Size = new System.Drawing.Size(43, 23);
            this.lbNameArtist.TabIndex = 2;
            this.lbNameArtist.Text = "Obito";
            this.lbNameArtist.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbNameArtist.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // itemImage
            // 
            this.itemImage.Location = new System.Drawing.Point(15, 23);
            this.itemImage.Name = "itemImage";
            this.itemImage.Size = new System.Drawing.Size(159, 154);
            this.itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.itemImage.TabIndex = 3;
            this.itemImage.TabStop = false;
            // 
            // album_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BorderRadius = 36;
            this.Controls.Add(this.itemImage);
            this.Controls.Add(this.lbNameArtist);
            this.Controls.Add(this.lbNameAlbum);
            this.Name = "album_item";
            this.Size = new System.Drawing.Size(186, 249);
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lbNameAlbum;
        private Bunifu.UI.WinForms.BunifuLabel lbNameArtist;
        private System.Windows.Forms.PictureBox itemImage;
    }
}
