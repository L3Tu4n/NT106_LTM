using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;

namespace Music
{
 
    public partial class KaraokeRoom : UserControl
    {
        public KaraokeRoom()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                cardTrack card = new cardTrack();
                flowLayoutPanelRoom.Controls.Add(card);
            }
        }
        private void btJoinRoom_Click(object sender, EventArgs e)
        {
            string roomId = tbRoomID.Text; // tbRoomID là TextBox để nhập ID phòng
            Form1 parentForm = this.ParentForm as Form1;
            Room room = new Room(roomId);
            parentForm.addUserControl(room);
        }
        private void btCreateRoom_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.ParentForm as Form1;
            Room room = new Room();
            parentForm.addUserControl(room);
        }
    }
}
