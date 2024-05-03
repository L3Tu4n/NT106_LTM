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
        public Form1()
        {
            InitializeComponent();

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            ucProfile ucProfile = new ucProfile();
            addUserControl(ucProfile);
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            ucPlaylists ucPlaylists = new ucPlaylists();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            addUserControl(homepage);
        }
        public void AddPlaylistControl(ucPlaylists ucPlaylists)
        {
            ucPlaylists.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(ucPlaylists);
            ucPlaylists.BringToFront();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            List list = new List();
            addUserControl(list);
        }
    }
}