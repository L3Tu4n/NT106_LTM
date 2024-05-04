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
            this.NgheSi = new Bunifu.UI.WinForms.BunifuLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageArtist = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lbNameArtist = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageArtist)).BeginInit();
            this.SuspendLayout();
            // 
            // NgheSi
            // 
            this.NgheSi.AllowParentOverrides = false;
            this.NgheSi.AutoEllipsis = false;
            this.NgheSi.Cursor = System.Windows.Forms.Cursors.Default;
            this.NgheSi.CursorType = System.Windows.Forms.Cursors.Default;
            this.NgheSi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NgheSi.ForeColor = System.Drawing.Color.Silver;
            this.NgheSi.Location = new System.Drawing.Point(63, 223);
            this.NgheSi.Name = "NgheSi";
            this.NgheSi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NgheSi.Size = new System.Drawing.Size(58, 23);
            this.NgheSi.TabIndex = 3;
            this.NgheSi.Text = "Nghệ sĩ";
            this.NgheSi.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.NgheSi.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageArtist);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 199);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbNameArtist);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 26);
            this.panel2.TabIndex = 6;
            // 
            // imageArtist
            // 
            this.imageArtist.AllowFocused = false;
            this.imageArtist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageArtist.AutoSizeHeight = true;
            this.imageArtist.BorderRadius = 90;
            this.imageArtist.Image = ((System.Drawing.Image)(resources.GetObject("imageArtist.Image")));
            this.imageArtist.IsCircle = true;
            this.imageArtist.Location = new System.Drawing.Point(3, 9);
            this.imageArtist.Name = "imageArtist";
            this.imageArtist.Size = new System.Drawing.Size(180, 180);
            this.imageArtist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageArtist.TabIndex = 0;
            this.imageArtist.TabStop = false;
            this.imageArtist.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // lbNameArtist
            // 
            this.lbNameArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNameArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameArtist.Location = new System.Drawing.Point(3, 0);
            this.lbNameArtist.Name = "lbNameArtist";
            this.lbNameArtist.Size = new System.Drawing.Size(183, 26);
            this.lbNameArtist.TabIndex = 0;
            this.lbNameArtist.Text = "lbNameArtist";
            this.lbNameArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Artist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.Black;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BorderRadius = 36;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NgheSi);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Artist";
            this.Size = new System.Drawing.Size(186, 249);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageArtist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel NgheSi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.UI.WinForms.BunifuPictureBox imageArtist;
        private System.Windows.Forms.Label lbNameArtist;
    }
}
