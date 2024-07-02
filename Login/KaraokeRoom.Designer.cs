namespace Music
{
    partial class KaraokeRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KaraokeRoom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuLabel43 = new Bunifu.UI.WinForms.BunifuLabel();
            this.flowLayoutPanelRoom = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCreateRoom = new System.Windows.Forms.Button();
            this.btJoinRoom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRoomID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuLabel43);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 45);
            this.panel1.TabIndex = 170;
            // 
            // bunifuLabel43
            // 
            this.bunifuLabel43.AllowParentOverrides = false;
            this.bunifuLabel43.AutoEllipsis = false;
            this.bunifuLabel43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.bunifuLabel43.CursorType = null;
            this.bunifuLabel43.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel43.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuLabel43.Location = new System.Drawing.Point(3, 2);
            this.bunifuLabel43.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuLabel43.Name = "bunifuLabel43";
            this.bunifuLabel43.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel43.Size = new System.Drawing.Size(227, 39);
            this.bunifuLabel43.TabIndex = 163;
            this.bunifuLabel43.Text = "List Of Rooms";
            this.bunifuLabel43.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel43.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // flowLayoutPanelRoom
            // 
            this.flowLayoutPanelRoom.AutoSize = true;
            this.flowLayoutPanelRoom.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelRoom.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanelRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelRoom.Name = "flowLayoutPanelRoom";
            this.flowLayoutPanelRoom.Size = new System.Drawing.Size(916, 191);
            this.flowLayoutPanelRoom.TabIndex = 171;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.flowLayoutPanelRoom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 282);
            this.panel2.TabIndex = 172;
            // 
            // btCreateRoom
            // 
            this.btCreateRoom.Location = new System.Drawing.Point(225, 429);
            this.btCreateRoom.Name = "btCreateRoom";
            this.btCreateRoom.Size = new System.Drawing.Size(183, 40);
            this.btCreateRoom.TabIndex = 173;
            this.btCreateRoom.Text = "Create Room";
            this.btCreateRoom.UseVisualStyleBackColor = true;
            this.btCreateRoom.Click += new System.EventHandler(this.btCreateRoom_Click);
            // 
            // btJoinRoom
            // 
            this.btJoinRoom.Location = new System.Drawing.Point(645, 429);
            this.btJoinRoom.Name = "btJoinRoom";
            this.btJoinRoom.Size = new System.Drawing.Size(164, 40);
            this.btJoinRoom.TabIndex = 174;
            this.btJoinRoom.Text = "Join Room";
            this.btJoinRoom.UseVisualStyleBackColor = true;
            this.btJoinRoom.Click += new System.EventHandler(this.btJoinRoom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(552, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 175;
            this.label1.Text = "Room ID";
            // 
            // tbRoomID
            // 
            this.tbRoomID.Location = new System.Drawing.Point(645, 401);
            this.tbRoomID.Name = "tbRoomID";
            this.tbRoomID.Size = new System.Drawing.Size(164, 22);
            this.tbRoomID.TabIndex = 176;
            // 
            // KaraokeRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tbRoomID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btJoinRoom);
            this.Controls.Add(this.btCreateRoom);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KaraokeRoom";
            this.Size = new System.Drawing.Size(952, 773);
            this.Load += new System.EventHandler(this.KaraokeRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel43;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRoom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCreateRoom;
        private System.Windows.Forms.Button btJoinRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRoomID;
    }
}
