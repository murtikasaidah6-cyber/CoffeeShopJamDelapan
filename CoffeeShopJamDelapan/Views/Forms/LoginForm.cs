using System;
using System.Windows.Forms;
using BCrypt.Net;
using CoffeeShopJamDelapan.Repo;

namespace CoffeeShopJamDelapan.Views.Forms
{
    public partial class LoginForm : Form
    {
        private readonly MemberRepo _memberRepo = new();
        private string _captcha;
        public LoginForm()
        {
            InitializeComponent();
            buttonLogin.Click += ButtonLogin_Click;
            buttonRegister.Click += ButtonRegister_Click;
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            var rnd = new Random();
            _captcha = rnd.Next(1000, 9999).ToString();
            labelCaptcha.Text = _captcha; // simplistic captcha
        }

        private async void ButtonLogin_Click(object? sender, EventArgs e)
        {
            var username = textBoxUsername.Text.Trim();
            var password = textBoxPassword.Text;

            var captcha = textBoxCaptcha.Text.Trim();

            if (captcha != _captcha)
            {
                MessageBox.Show("Captcha invalid");
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Provide username and password");
                return;
            }

            var member = await _memberRepo.GetByUsernameAsync(username);
            var isValid = BCrypt.Net.BCrypt.Verify(password, member.Password);
            if (member == null || !isValid)
            {
                MessageBox.Show("Invalid credentials");
                return;
            }

            MessageBox.Show($"Welcome {member.FullName ?? member.Username}");
            // open admin form for simplicity
            var f = new AdminForm();
            f.Show();
            this.Hide();
        }

        private void ButtonRegister_Click(object? sender, EventArgs e)
        {
            this.Hide();
            var reg = new RegisterForm();
            reg.ShowDialog();
        }

        private void buttonRefreshCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
            this.Hide();
        }

        private void linkResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
            this.Hide();
        }
    }
}
