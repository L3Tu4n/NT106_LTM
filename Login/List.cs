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
    public partial class List : UserControl

    {
        public List()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
        }
        private void InitializeFlowLayoutPanel()
        {
            for (int i = 0; i < 10; i++)
            {
                cardTrack card = new cardTrack();
                flowLayoutPanelTrack.Controls.Add(card);
            }
        }
    }
}