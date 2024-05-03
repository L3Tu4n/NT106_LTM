using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
namespace Music
{
    public partial class AddPlaylist : MaterialForm
    {
        MaterialSkinManager skinManager;
        public AddPlaylist()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.LightGreen200, Primary.LightGreen500, Primary.LightGreen500, Accent.LightGreen200, TextShade.WHITE);
        }


        private void btSavePlaylist_Click(object sender, EventArgs e)
        {
           
        }


    }
}
