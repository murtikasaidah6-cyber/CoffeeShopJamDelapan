using BCrypt.Net;
using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private MemberRepo _repo = new();
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void buttonReset_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            if (!System.Net.Mail.MailAddress.TryCreate(textEmail.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            var email = textEmail.Text.Trim();
            var member = await _repo.ExistsByEmailAsync(email);
            if (member == null)
            {
                MessageBox.Show("Email not found.");
                return;
            }

            sendResetPassword(member);
        }

        private async void sendResetPassword(Member member)
        {
            try
            {
                string newPassword = GenerateRandomPassword(8);

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("pandri.academy@gmail.com", "ygve bjnk bvtz msng"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("andrijoe90@gmail.com"),
                    Subject = "Reset Password Aplikasi",
                    Body = $"Halo {member.FullName},\n\nPassword baru Anda adalah: {newPassword}\n\nSilakan segera login dan ubah password kamu.",
                    IsBodyHtml = false,
                    // <h1></h1>, <p></p>
                };
                mailMessage.To.Add(member.Email); // table.kolom / model.property

                await smtpClient.SendMailAsync(mailMessage); // method untuk kirim email

                var hashPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                member.Password = hashPassword; // password member lama ditimpa dengan password baru yang sudah di hash
                await _repo.UpdateAsync(member);

                MessageBox.Show("Email reset password berhasil dikirim.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengirim email: {ex.Message}");
            }
        }

        private string GenerateRandomPassword(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string password = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                int position = rand.Next(chars.Length);
                password += chars[position];
            }
            return password;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Hide();
        }
    }
}
