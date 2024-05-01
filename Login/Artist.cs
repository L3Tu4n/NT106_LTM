using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RankingMusic
{
    public partial class Artist : Bunifu.UI.WinForms.BunifuUserControl
    {
        public Artist()
        {
            InitializeComponent();
        }
        public Image ItemImage
        {
            get
            {
                return imageArtist.Image;
            }
            set
            {
                imageArtist.Image = value;
            }
        }
        public string NameArtist
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
    }
}
