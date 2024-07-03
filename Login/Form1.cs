using RankingMusic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Music
{
    public partial class Form1 : Form
    {
        Homepage homepage = new Homepage();
        ucPlaylists ucPlaylists = new ucPlaylists();
        ucProfile ucProfile = new ucProfile();
        KaraokeRoom room = new KaraokeRoom();
        private USCPlay uscPlayControl;
        private Panel panel5;
        public Panel Panel3 => panel3;

        public Form1()
        {
            InitializeComponent();

            panel5 = new Panel();
            panel5.Dock = DockStyle.Fill;
            panel3.Controls.Add(panel5);

            addUserControl(homepage);
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel5.Controls.Clear();
            panel5.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public void AddPlaylistControl(ucPlaylists ucPlaylists)
        {
            ucPlaylists.Dock = DockStyle.Fill;
            panel5.Controls.Clear();
            panel5.Controls.Add(ucPlaylists);
            ucPlaylists.BringToFront();
        }

        public void AddUSCPlay(USCPlay uscPlay)
        {
            if (uscPlayControl != null)
            {
                panel3.Controls.Remove(uscPlayControl);
                uscPlayControl.Dispose();
            }

            uscPlay.Dock = DockStyle.Bottom;
            uscPlayControl = uscPlay;
            panel3.Controls.Add(uscPlay);
            uscPlay.BringToFront();

            panel5.Dock = DockStyle.Top;
            panel5.Height = panel3.Height - uscPlay.Height;
        }   

        public void RemoveUSCPlay()
        {
            if (uscPlayControl != null)
            {
                panel3.Controls.Remove(uscPlayControl);
                uscPlayControl.Dispose();
                uscPlayControl = null;

                panel5.Dock = DockStyle.Fill;
                panel5.Height = 0;
            }
        }

        private void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            addUserControl(homepage);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            USCRankMusic ucRank = new USCRankMusic();
            ucRank.ParentForm = this;
            addUserControl(ucRank);
        }
        private void bunifuButton26_Click_1(object sender, EventArgs e)
        {
            addUserControl(ucPlaylists);
        }

        private void bunifuButton27_Click_1(object sender, EventArgs e)
        {
            addUserControl(ucProfile);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text == null)
            {
                return;
            }
            Search search = new Search(tbSearch.Text);
            addUserControl(search);
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            addUserControl(room);
        }
    }
}