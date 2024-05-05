using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Music
{
    public class ClassCard
    {
        public string Name { get; set; }
        public Playlist PlaylistData { get; set; }

        public class Playlist
        {
            public int id { get; set; }
            public string PlaylistName { get; set; }
            public string PlaylistImage { get; set; }
        }

        public async Task Save()
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    var cookieContainer = new CookieContainer();
                    handler.CookieContainer = cookieContainer;

                    using (var client = new HttpClient(handler))
                    {
                        // Lấy token từ manageToken.AccessToken
                        string token = manageToken.AccessToken;

                        // Tạo cookie từ token và thêm vào cookieContainer
                        var cookie = new Cookie("token", token, "/", "localhost");
                        cookieContainer.Add(cookie);

                        // Lấy tên playlist từ thuộc tính Name
                        var name = Name;

                        // Tạo payload JSON từ tên playlist
                        var Request = new
                        {
                            name
                        };
                        string json = JsonConvert.SerializeObject(Request);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync("http://localhost:9999/v1/playlist/addname", content);

                        // Kiểm tra phản hồi từ server
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Lưu tên playlist thành công");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<ClassCard>> GetPlaylist()
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    var cookieContainer = new CookieContainer();
                    handler.CookieContainer = cookieContainer;

                    using (var client = new HttpClient(handler))
                    {
                        // Lấy token từ manageToken.AccessToken
                        string token = manageToken.AccessToken;

                        // Tạo cookie từ token và thêm vào cookieContainer
                        var cookie = new Cookie("token", token, "/", "localhost");
                        cookieContainer.Add(cookie);

                        // Gửi yêu cầu GET đến endpoint /playlist/getall
                        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9999/v1/playlist/getall");
                        var response = await client.SendAsync(request);
                        // Kiểm tra phản hồi từ server
                        if (response.IsSuccessStatusCode)
                        {
                            // Đọc nội dung phản hồi và chuyển đổi thành danh sách ClassCard
                            string jsonContent = await response.Content.ReadAsStringAsync();

                            // Tạo danh sách để lưu trữ ClassCard
                            List<ClassCard> classCards = new List<ClassCard>();

                            // Chuyển đổi từ JSON thành danh sách dynamic objects
                            var dynamicObjects = JsonConvert.DeserializeObject<List<dynamic>>(jsonContent);

                            // Duyệt qua từng dynamic object để lấy các trường cần thiết và tạo ClassCard
                            foreach (var obj in dynamicObjects)
                            {
                                var classCard = new ClassCard
                                {
                                    PlaylistData = new ClassCard.Playlist
                                    {
                                        id = obj.ID,
                                        PlaylistName = obj.NAME,
                                        PlaylistImage = obj.PLAYLIST_IMAGE
                                    }
                                };

                                // Thêm ClassCard vào danh sách
                                classCards.Add(classCard);
                            }

                            // Trả về danh sách ClassCard
                            return classCards;
                        }
                        else
                        {
                            // Phản hồi không thành công, xử lý tương ứng
                            Console.WriteLine($"Failed to get playlists. Status code: {response.StatusCode}");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<Playlist> GetNewInsertedData()
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    var cookieContainer = new CookieContainer();
                    handler.CookieContainer = cookieContainer;

                    using (var client = new HttpClient(handler))
                    {
                        // Lấy token từ manageToken.AccessToken
                        string token = manageToken.AccessToken;

                        // Tạo cookie từ token và thêm vào cookieContainer
                        var cookie = new Cookie("token", token, "/", "localhost");
                        cookieContainer.Add(cookie);

                        // Gửi yêu cầu GET đến endpoint /playlist/getnewinserted
                        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9999/v1/playlist/getnewinserted");
                        var response = await client.SendAsync(request);

                        // Kiểm tra phản hồi từ server
                        if (response.IsSuccessStatusCode)
                        {
                            // Đọc nội dung phản hồi và chuyển đổi thành đối tượng dynamic
                            string jsonContent = await response.Content.ReadAsStringAsync();
                            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                            // Tạo đối tượng Playlist từ dữ liệu JSON
                            Playlist playlist = new Playlist
                            {
                                id = jsonData.ID,
                                PlaylistName = jsonData.NAME
                            };

                            return playlist;
                        }
                        else
                        {
                            // Phản hồi không thành công, xử lý tương ứng
                            Console.WriteLine($"Failed to get playlist. Status code: {response.StatusCode}");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public void getDetails(string details_id)
        {

        }
    }
   
}