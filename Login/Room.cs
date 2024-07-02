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
        private HttpClient httpClient;
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private string roomId;
        private string name;
        private string image;
        public Room()
        {
            InitializeComponent();
            ConnectToServer();
        }
        public Room(string roomId)
        {
            InitializeComponent();
            this.roomId = roomId;
            ConnectToServer();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void Room_Load(object sender, EventArgs e)
        {
            await LoadProfile();

            if (string.IsNullOrEmpty(roomId))
            {
                await CreateRoom();
                MessageBox.Show(roomId);
                lbRoomID.Text += roomId;
            }
            else
            {
                await JoinRoom(roomId);
                MessageBox.Show(roomId);
                lbRoomID.Text += roomId;
            }
        }
        private async Task LoadProfile()
        {
            using (var handler = new HttpClientHandler())
            {
                var cookieContainer = new CookieContainer();
                handler.CookieContainer = cookieContainer;

                using (var client = new HttpClient(handler))
                {
                    string token = manageToken.AccessToken;
                    var cookie = new Cookie("token", token, "/", "localhost");

                    cookieContainer.Add(cookie);
                    var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9999/v1/profiles/profile");
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responeContent = await response.Content.ReadAsStringAsync();
                        var responseObj = JsonConvert.DeserializeObject<dynamic>(responeContent);

                        name = responseObj.name;
                        if (name == null || name == "") name = responseObj.email;
                        image = responseObj.image;
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve profile information: " + response.ReasonPhrase);
                    }
                }
            }
        }
        private void ConnectToServer()
        {
            client = new TcpClient("127.0.0.1", 8888); // Địa chỉ IP và cổng của máy chủ
            stream = client.GetStream();
            receiveThread = new Thread(ListenForServerMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
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
            
            if (message.StartsWith("JOIN_ROOM_SUCCESS") || message.StartsWith("CREATE_ROOM_SUCCESS"))
            {
                roomId = message.Split(' ')[1];
            }
            else
            {
                try
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
                catch (JsonReaderException ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Error parsing JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
        }
        private void AddClientToUI(string clientName, string clientImage)
        {
            avtkaraoke avtkaraoke = new avtkaraoke(clientName, clientImage);
            listmember.Controls.Add(avtkaraoke);
        }
        public async Task JoinRoom(string roomId)
        {
            var data = new
            {
                roomId = roomId,
                name = name,
                image = image
            };

            string jsonData = JsonConvert.SerializeObject(data);
            string joinMessage = $"JOIN_ROOM {jsonData}";
            byte[] joinMessageBytes = Encoding.ASCII.GetBytes(joinMessage);

            await stream.WriteAsync(joinMessageBytes, 0, joinMessageBytes.Length);
        }

        public async Task CreateRoom()
        {
            var data = new
            {
                name = name,
                image = image
            };

            string jsonData = JsonConvert.SerializeObject(data);
            string createMessage = $"CREATE_ROOM {jsonData}";
            byte[] createMessageBytes = Encoding.ASCII.GetBytes(createMessage);

            await stream.WriteAsync(createMessageBytes, 0, createMessageBytes.Length);
        }
    }
}
