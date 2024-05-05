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

namespace Music
{
    public partial class cardTrack : Bunifu.UI.WinForms.BunifuUserControl
    {
        public cardTrack()
        {
            InitializeComponent();
        }
        public cardTrack(string stt, string imageUrl, string nametrack, string nameartist, string namealbum, string duration)
        {
            InitializeComponent();

            // Gán các giá trị cho các thuộc tính
            STT.Text = stt;
            Image image = LoadImageFromUrl(imageUrl);
            if (image != null)
            {
                ImageArtist.Image = image;
            }
            NameTrack.Text = nametrack;
            NameArtist.Text = nameartist;
            NameAlbum.Text = namealbum;
            Duration.Text = duration;
        }
        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(url);
                    using (var stream = new System.IO.MemoryStream(data))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load image from URL: " + ex.Message);
                return null;
            }
        }
        public string stt
        {
            get
            {
                return STT.Text;
            }
            set
            {
                STT.Text = value;
            }
        }
        public Image TrackImage
        {
            get
            {
                return ImageArtist.Image;
            }
            set
            {
                ImageArtist.Image = value;
            }
        }
        public string nametrack
        {
            get
            {
                return NameTrack.Text;
            }
            set
            {
                NameTrack.Text = value;
            }
        }
        public string nameartist
        {
            get
            {
                return NameArtist.Text;
            }
            set
            {
                NameArtist.Text = value;
            }
        }
        public string namealbum
        {
            get
            {
                return NameAlbum.Text;
            }
            set
            {
                NameAlbum.Text = value;
            }
        }
        public string duration
        {
            get
            {
                return Duration.Text;
            }
            set
            {
                Duration.Text = value;
            }
        }
    }
}