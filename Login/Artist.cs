﻿using System;
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
    public partial class Artist : Bunifu.UI.WinForms.BunifuUserControl
    {
        public Artist()
        {
            InitializeComponent();
        }
        public Artist(string imageUrl, string nameartist)
        {
            InitializeComponent();
            // Gán các giá trị cho các thuộc tính
            Image image = LoadImageFromUrl(imageUrl);
            if (image != null)
            {
                imageArtist.Image = image;
            }
            lbNameArtist.Text = nameartist;
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
                return lbNameArtist.Text;
            }
            set
            {
                lbNameArtist.Text = value;
            }
        }
    }
}
