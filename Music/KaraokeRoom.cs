using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music
{
    public partial class KaraokeRoom : UserControl
    {
        private TcpClient client;
        private NetworkStream stream;
        public KaraokeRoom()
        {
            InitializeComponent();
            for(int i = 0; i < 5; i++)
            {
                cardTrack card = new cardTrack();
                flowLayoutPanelRoom.Controls.Add(card);
            }
        }
        private void ConnectToServer()
        {
            client = new TcpClient("127.0.0.1", 8888); // Địa chỉ IP và cổng của máy chủ
            stream = client.GetStream();
        }
        private async void ListenForServerMessages()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                HandleServerMessage(message);
            }
        }
        private void HandleServerMessage(string message)
        {
            if (message.StartsWith("JOIN_ROOM_SUCCESS") || message.StartsWith("CREATE_ROOM_SUCCESS"))
            {
                this.Invoke((MethodInvoker)delegate {
                    EnterRoomUI();
                });
            }
        }
        private void EnterRoomUI()
        {
            Room room = new Room();
            room.Show();
            this.Hide();
            
        }
        private void btJoinRoom_Click(object sender, EventArgs e)
        {
            string roomId = tbRoomID.Text; // txtRoomId là TextBox để nhập ID phòng
            ConnectToServer();
            JoinRoom(roomId);
        }
        private void JoinRoom(string roomId)
        {
            string joinMessage = $"JOIN_ROOM {roomId}";
            byte[] joinMessageBytes = Encoding.ASCII.GetBytes(joinMessage);
            stream.Write(joinMessageBytes, 0, joinMessageBytes.Length);
        }
        private void btCreateRoom_Click(object sender, EventArgs e)
        {
            string roomId = tbRoomID.Text; // txtRoomId là TextBox để nhập ID phòng
            ConnectToServer();
            CreateRoom(roomId);
        }
        private void CreateRoom(string roomId)
        {
            string createMessage = $"CREATE_ROOM {roomId}";
            byte[] createMessageBytes = Encoding.ASCII.GetBytes(createMessage);
            stream.Write(createMessageBytes, 0, createMessageBytes.Length);
        }
    }
}
