using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music
{
    public partial class playlist_item : Bunifu.UI.WinForms.BunifuUserControl
    {
        public playlist_item()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }
        public Image ItemImage
        {
            get
            {
                return itemImage.Image;
            }
            set
            {
                itemImage.Image = value;
            }
        }
        public string NamePlaylist
        {
            get
            {
                return lbNamePlaylist.Text;
            }
            set
            {
                lbNamePlaylist.Text = value;
            }
        }
        
    }
}
