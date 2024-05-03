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
    public partial class ucPlaylists : Form
    {
        public ucPlaylists()
        {
            InitializeComponent();
        }
        private void btAddPlaylists_Click(object sender, EventArgs e)
        { 
           Form background = new Form();
            try
            {
                using(AddPlaylist uc = new AddPlaylist())
                {
                    background.StartPosition  = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = Color.Black;
                    background.WindowState = FormWindowState.Maximized;
                    background.Location = this.Location;
                    background.ShowInTaskbar = false;
                    background.Show();

                    uc.Owner = background;
                    uc.ShowDialog();
                    background.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {  background.Dispose(); }
        }
    }
}
