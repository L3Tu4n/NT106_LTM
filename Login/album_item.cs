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
    public partial class album_item : Bunifu.UI.WinForms.BunifuUserControl
    {
        public album_item()
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
        public string NameAlbum
        {
            get
            {
                return lbNameAlbum.Text;
            }
            set 
            { 
                lbNameAlbum.Text = value;
            }
        }
        public string NameArtist
        {
            get 
            {
                return lbNameArtist.Text;
            }
            set
            {
                lbNameArtist.Text = value;
            }
        }
    }
}
