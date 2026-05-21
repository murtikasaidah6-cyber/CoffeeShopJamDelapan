using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;

namespace CoffeeShopJamDelapan.Views.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly MemberRepo _repo = new();
        private string _captcha;
        public RegisterForm()
        {
            InitializeComponent();
            buttonSubmit.Click += ButtonSubmit_Click;
            buttonRefreshCaptcha.Click += ButtonRefreshCaptcha_Click;
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            var rnd = new Random();
            _captcha = rnd.Next(1000, 9999).ToString();
            labelCaptcha.Text = _captcha; // simplistic captcha
        }

        private void ButtonRefreshCaptcha_Click(object? sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private async void ButtonSubmit_Click(object? sender, EventArgs e)
        {
            var username = textBoxUsername.Text.Trim();
            var phone = textBoxPhone.Text.Trim();
            var email = textBoxEmail.Text.Trim();
            var fullname = textBoxFullName.Text.Trim();
            var password = textBoxPassword.Text;
            var captcha = textBoxCaptcha.Text.Trim();

            if (captcha != _captcha)
            {
                MessageBox.Show("Captcha invalid");
                return;
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password required");
                return;
            }
            if (!string.IsNullOrWhiteSpace(email))
            {
                try { var a = new System.Net.Mail.MailAddress(email); } catch { MessageBox.Show("Invalid email"); return; }
            }

            if (await _repo.ExistsByUsernameAsync(username))
            {
                MessageBox.Show("Username already exists");
                return;
            }
            if (!string.IsNullOrWhiteSpace(phone) && await _repo.ExistsByPhoneAsync(phone))
            {
                MessageBox.Show("Phone already exists");
                return;
            }

            string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var m = new Member
            {
                Username = username,
                Phone = phone,
                Email = email,
                FullName = fullname,
                Password = hashPassword,
                Code = "M" + DateTime.Now.ToString("yyMMddHHmmss"),
                LastUpdate = DateTime.Now
            };
            var id = await _repo.CreateAsync(m);
            MessageBox.Show($"Registered id={id}");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void ClearForm()
        {
            textBoxUsername.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxFullName.Text = "";
            textBoxPassword.Text = "";
            textBoxCaptcha.Text = "";
        }
    }
}
