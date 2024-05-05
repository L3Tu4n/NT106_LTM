using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Music
{
    public partial class CardControl : Bunifu.UI.WinForms.BunifuUserControl
    {
        public CardControl()
        {
            InitializeComponent();
        }

        public async void cardDetails(ClassCard e)
        {
            lbid.Text = e.PlaylistData.id.ToString();
            lbNamePlaylist.Text = e.PlaylistData.PlaylistName;

            // Tạo một WebClient để tải hình ảnh từ URL
            using (WebClient wc = new WebClient())
            {
                try
                {
                    // Tải hình ảnh từ URL
                    byte[] bytes = await wc.DownloadDataTaskAsync(e.PlaylistData.PlaylistImage);
                    // Chuyển đổi byte array thành hình ảnh
                    using (var ms = new System.IO.MemoryStream(bytes))
                    {
                        Image img = Image.FromStream(ms);
                        // Gán hình ảnh vào PictureBox
                        itemImage.Image = img;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có lỗi khi tải hình ảnh
                    Console.WriteLine($"An error occurred while downloading image: {ex.Message}");
                }
            }
        }
        public async void displayNew()
        {
                ClassCard get = new ClassCard();
                ClassCard.Playlist playlist = await get.GetNewInsertedData();
                lbNamePlaylist.Text = playlist.PlaylistName;
                itemImage.ImageLocation = "https://static.vecteezy.com/system/resources/previews/001/918/233/non_2x/music-and-sound-line-icon-with-headphones-vector.jpg";
                lbid.Text = playlist.id.ToString(); 
        }
        

        private void CardControl_Load_1(object sender, EventArgs e)
        {
            if (AddPlaylist.refresh == true)
            {
                displayNew();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
