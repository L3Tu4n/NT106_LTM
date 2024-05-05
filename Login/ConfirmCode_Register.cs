using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Music
{
    public partial class ConfirmCode_Register : Form
    {
        private string email;
        private string password;
        private HttpClient httpClient;
        public ConfirmCode_Register(string Email , string Password)
        {
            InitializeComponent();
            email = Email;
            password = Password;
            lbEmail.Text = email;
            httpClient = new HttpClient();
        }

        private async void btSend_Click(object sender, EventArgs e)
        {
            var Email = email;
            var Password = password;
            var Code = tbCode.Text;
            var registerRequest = new 
            {
                Email,
                Code,
                Password
            };
            string json = JsonConvert.SerializeObject(registerRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync("http://localhost:9999/v1/Register/Confirm", content);

                if (response.IsSuccessStatusCode)
                {
                    lbMessage.Text = "Bạn đã đăng kí thành công.";
                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    lbMessage.Text = "Mã xác nhận không đúng. Vui lòng thử lại.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
