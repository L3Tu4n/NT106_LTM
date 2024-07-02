using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Music
{
    public partial class Room : UserControl
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private string roomId;
        public Room()
        {
            InitializeComponent();
            avtkaraoke avtkaraoke = new avtkaraoke();
            listmember.Controls.Add(avtkaraoke);
        }
        public Room(string roomId, TcpClient client, NetworkStream stream, Thread receiveThread)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.client = client;
            this.stream = stream;
            this.receiveThread = receiveThread;
            lbRoomID.Text += roomId;

            // Bắt đầu nhận tin nhắn từ server
            if (receiveThread == null || !receiveThread.IsAlive)
            {
                this.receiveThread = new Thread(ListenForServerMessages);
                this.receiveThread.IsBackground = true;
                this.receiveThread.Start();
            }
        }
        private void ListenForServerMessages()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    HandleServerMessage(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while reading from stream: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Handle the exception as needed, possibly close resources
                    break;
                }
            }
        }
        private void HandleServerMessage(string message)
        {
            dynamic data = JsonConvert.DeserializeObject(message);

            if (data.type == "EXISTING_CLIENT_INFO" || data.type == "NEW_CLIENT_JOIN")
            {
                string clientName = data.name;
                string clientImage = data.image;
                this.Invoke((MethodInvoker)delegate
                {
                    // Cập nhật giao diện để hiển thị thông tin client mới hoặc đã tồn tại
                    AddClientToUI(clientName, clientImage);
                });
            }
        }
        private void AddClientToUI(string clientName, string clientImage)
        {
            avtkaraoke avtkaraoke = new avtkaraoke(clientName,clientImage);
            listmember.Controls.Add(avtkaraoke);
        }
        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Room_Load(object sender, EventArgs e)
        {
            if (client != null && client.Connected && stream != null)
            {
                try
                {
                    // Send request to the server to get info of clients already joined in this room (roomId)
                    string requestMessage = $"GET_CLIENTS_INFO {roomId}";
                    byte[] requestMessageBytes = Encoding.ASCII.GetBytes(requestMessage);
                    stream.Write(requestMessageBytes, 0, requestMessageBytes.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending request to server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Handle the exception as needed, possibly close resources
                }
            }
            else
            {
                MessageBox.Show("Client or stream is not available or connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Handle the case where client or stream is not available or connected
            }
        }
    }
}
