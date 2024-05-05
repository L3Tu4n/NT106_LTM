﻿using System;
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
        USCRankMusic ucRank = new USCRankMusic();
        ucPlaylists ucPlaylists = new ucPlaylists();
        ucProfile ucProfile = new ucProfile();

        public Form1()
        {
            InitializeComponent();
          
            addUserControl(homepage);

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
      

        public void AddPlaylistControl(ucPlaylists ucPlaylists)
        {
            ucPlaylists.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(ucPlaylists);
            ucPlaylists.BringToFront();
        }

     

        private void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            addUserControl(homepage);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            
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
    }
}