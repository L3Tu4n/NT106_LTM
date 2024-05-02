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
    public partial class Homepage : UserControl
    {
        public Homepage()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
        }
        private void InitializeFlowLayoutPanel()
        {
            // Tạo và thêm các cardTrack vào FlowLayoutPanelTrack
            for (int i = 0; i < 10; i++)
            {
                cardTrack card = new cardTrack();
                flowLayoutPanelTrack.Controls.Add(card);
            }
            // Tạo và thêm các  album_item vào FlowLayoutPanelAlbum
            for (int i = 0; i < 10; i++)
            {
                album_item card = new album_item();
                flowLayoutPanelAlbum.Controls.Add(card);
            }
            // Tạo và thêm các Artist vào FlowLayoutPanelA
            for (int i = 0; i < 10; i++)
            {
                Artist card = new Artist();
                flowLayoutPanelArtist.Controls.Add(card);
            }
        }
    }
}
