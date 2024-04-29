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
    public partial class USCPlayMusic : UserControl
    {
        public USCPlayMusic()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            ucPlaymusic.Hide();
            pImageSong.Hide();
            bExit.Hide();
            bPlay.Hide();
            bRepeat.Hide();
            bShuffle.Hide();
            bVolume.Hide();
            bSkipNext.Hide();
            bSkipPrevious.Hide();
            bAddPlaylist.Hide();
            HSlider1.Hide();
            HSlider2.Hide();
            lTime1.Hide();
            lTime2.Hide();
            lNameSong.Hide();
            lNameSinger.Hide();
        }
    }
}
