namespace Music
{
    partial class playlist_item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playlist_item));
            this.lbNamePlaylist = new Bunifu.UI.WinForms.BunifuLabel();
            this.itemImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNamePlaylist
            // 
            this.lbNamePlaylist.AllowParentOverrides = false;
            this.lbNamePlaylist.AutoEllipsis = false;
            this.lbNamePlaylist.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbNamePlaylist.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbNamePlaylist.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamePlaylist.ForeColor = System.Drawing.Color.White;
            this.lbNamePlaylist.Location = new System.Drawing.Point(50, 219);
            this.lbNamePlaylist.Name = "lbNamePlaylist";
            this.lbNamePlaylist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNamePlaylist.Size = new System.Drawing.Size(89, 23);
            this.lbNamePlaylist.TabIndex = 1;
            this.lbNamePlaylist.Text = "tên playlist";
            this.lbNamePlaylist.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbNamePlaylist.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // itemImage
            // 
            this.itemImage.Location = new System.Drawing.Point(13, 26);
            this.itemImage.Name = "itemImage";
            this.itemImage.Size = new System.Drawing.Size(173, 187);
            this.itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.itemImage.TabIndex = 3;
            this.itemImage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Music.Properties.Resources.icons8_ellipsis_60;
            this.pictureBox1.Location = new System.Drawing.Point(140, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 22);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.editToolStripMenuItem.Image = global::Music.Properties.Resources.icons8_edit_150;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteToolStripMenuItem.Image = global::Music.Properties.Resources.icons8_delete_30;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // playlist_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BorderRadius = 36;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.itemImage);
            this.Controls.Add(this.lbNamePlaylist);
            this.Name = "playlist_item";
            this.Size = new System.Drawing.Size(190, 249);
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lbNamePlaylist;
        private System.Windows.Forms.PictureBox itemImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
