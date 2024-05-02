using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Login
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            {
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

                            var current_password = txtcurrentPassword.Text;
                            var new_password = txtnewPassword.Text;
                            var Request = new
                            {
                                current_password,
                                new_password
                            };
                            string json = JsonConvert.SerializeObject(Request);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            MessageBox.Show(json);
                            try
                            {
                                // Đúng là client thay vì httpClient
                                var response = await client.PutAsync("http://localhost:9999/v1/profiles/password", content);

                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Cập nhật mật khẩu thành công");
                                }
                                else
                                {
                                    MessageBox.Show($"Failed to update name. Status code: {response.StatusCode}");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred: {ex.Message}");
                            }
                        }
                    }

                }
            }
        }
    }
}