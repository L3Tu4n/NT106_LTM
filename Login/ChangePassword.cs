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

namespace Music
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        private async void btnSave_Click(object sender, EventArgs e)
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
                    var new_password2 = txtnewPassword2.Text;

                    // Kiểm tra mật khẩu mới và nhập lại mật khẩu mới
                    if (new_password != new_password2)
                    {
                        MessageBox.Show("Nhập lại mật khẩu mới không khớp. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var Request = new
                    {
                        current_password,
                        new_password
                    };
                    string json = JsonConvert.SerializeObject(Request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        // Đúng là client thay vì httpClient
                        var response = await client.PutAsync("http://localhost:9999/v1/profiles/password", content);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Ẩn form sau khi thực hiện cập nhật
                        
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