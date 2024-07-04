using NAudio.Wave;
using RankingMusic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music
{
    public partial class USCAlbum : UserControl
    {
        private int trackCounter = 0;
        public Form1 ParentForm { get; set; }

        public USCAlbum()
        {
            InitializeComponent();
        }

        public void SetAlbumInfo(List<dynamic> tracks, string iamgeURL, string artistName, string albumName, string date, string totalTracks)
        {
            lArtistName.Text = artistName;
            lAlbumName.Text = albumName;
            DateTime parsedDate;
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                lDate.Text = parsedDate.ToString("dd-MM-yyyy");
            }
            else
            {
                lDate.Text = "Invalid date";
            }
            pAlbumImage.ImageLocation = iamgeURL;
            lTotalTracks.Text = totalTracks;

            foreach (var track in tracks)
            {
                string imageURL = track.IMAGE.String;
                string NameSong = track.NAME;
                string NameAlbum = track.ALBUM_NAME;
                string Duration = track.DURATION.String;
                string Fs_path = track.FS_PATH.String;
                trackCounter++;
                string stt = trackCounter.ToString();

                CardSong cardSong = new CardSong(stt, imageURL, NameSong, artistName, NameAlbum, Duration, Fs_path, this);
                flowLayoutPanelTrack.Controls.Add(cardSong);
            }
        }
    }
}
