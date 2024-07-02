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
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private string name;
        private string image;
        public KaraokeRoom()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                cardTrack card = new cardTrack();
                flowLayoutPanelRoom.Controls.Add(card);
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


        private async void ListenForServerMessages()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    HandleServerMessage(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error receiving data: " + ex.Message);
                    break;
                }
            }
        }

        private void HandleServerMessage(string message)
        {
            if (message.StartsWith("JOIN_ROOM_SUCCESS") || message.StartsWith("CREATE_ROOM_SUCCESS"))
            {
                string roomId = message.Split(' ')[1];
                MessageBox.Show($"{roomId}: {message}");
                this.Invoke((MethodInvoker)delegate {
                    EnterRoomUI(roomId);
                });
            }
        }

        private void EnterRoomUI(string roomId)
        {
            Form1 parentForm = this.ParentForm as Form1;
            Room room = new Room(roomId, client, stream, receiveThread);
            parentForm.addUserControl(room);
        }

        private void btJoinRoom_Click(object sender, EventArgs e)
        {
            string roomId = tbRoomID.Text; // tbRoomID là TextBox để nhập ID phòng
            ConnectToServer();
            JoinRoom(roomId);
        }
        private async void JoinRoom(string roomId)
        {
            // Tạo JSON từ dữ liệu cần gửi
            var data = new
            {
                roomId = roomId,
                name = name,
                image = image
            };
            // Chuyển đổi đối tượng data thành chuỗi JSON
            string jsonData = JsonConvert.SerializeObject(data);
            string joinMessage = $"JOIN_ROOM {jsonData}";
            byte[] joinMessageBytes = Encoding.ASCII.GetBytes(joinMessage);
            await stream.WriteAsync(joinMessageBytes, 0, joinMessageBytes.Length);
        }
        

        private void btCreateRoom_Click(object sender, EventArgs e)
        {
            ConnectToServer();
            CreateRoom();
        }
        private async void CreateRoom()
        {
            // Tạo JSON từ dữ liệu cần gửi
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

        private async void KaraokeRoom_Load(object sender, EventArgs e)
        {
            using (var handler = new HttpClientHandler())
            {
                // Tạo cookie container để lưu trữ cookie
                var cookieContainer = new CookieContainer();
                handler.CookieContainer = cookieContainer;
                using (var client = new HttpClient(handler))
                {
                    // Lấy giá trị của token từ form Login
                    string token = manageToken.AccessToken;
                    var cookie = new Cookie("token", token, "/", "localhost");

                    cookieContainer.Add(cookie);
                    var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9999/v1/profiles/profile");
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu JSON từ phản hồi
                        var responeContent = await response.Content.ReadAsStringAsync();
                        // Chuyển chuỗi JSON thành đối tượng động dynamic
                        var responseObj = JsonConvert.DeserializeObject<dynamic>(responeContent);

                        // Điền dữ liệu vào các ô textbox
                        name = responseObj.name;
                        if(name == null || name =="") { name = responseObj.email; }
                        image = responseObj.image;
                        // Load avatar từ database (giả sử avatar được lưu dưới dạng base64 trong responseObj.avatar)
                        MessageBox.Show(name + image);
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve profile information: " + response.ReasonPhrase);
                    }
                }
            }
        }
    }
}
