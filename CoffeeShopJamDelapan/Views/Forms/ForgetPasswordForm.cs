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
    public partial class ForgetPasswordForm : Form
    {
        private MemberRepo _repo = new(); // deklarasi repository untuk mengakses data member
        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private async void buttonReset_Click(object sender, EventArgs e)
        {
            if  (String.IsNullOrEmpty(textEmail.Text.Trim())) 
                // cek apakah email yang dimasukkan kosong atau hanya spasi
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            if (!System.Net.Mail.MailAddress.TryCreate(textEmail.Text.Trim(), out _)) 
                // cek apakah email yang dimasukkan valid dengan format email yang benar
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            var email = textEmail.Text.Trim();
            var member = await _repo.ExistsByEmailAsync(email); // menunggu respon dari database untuk mengecek apakah email ada di database
            if (member == null) // member tidak ditemukan dengan email yang diberikan
            {
                MessageBox.Show("Email not found or member is not registered yet");
                return;
            }

            ResetPasswordUsingMember(member);

        }

        private async void ResetPasswordUsingMember(Member member) // diketik sendiri
        {
            try
            {
                var rnd = new Random();
                var newPassword = rnd.Next(1000, 9999).ToString();

                // setting smtp
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // TLS port for Gmail
                    Credentials = new NetworkCredential("pandri.academy@gmail.com", "xxxx yyyy zzzz aaaa"), // setting bareng
                    EnableSsl = true, // wajib utk server email yang mendukung SSL/TLS, seperti Gmail/outlook
                };

                // setting receipient email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("pandri.academy@gmail.com"), // sesuaikan email pengirim
                    Subject = "Reset Password Aplikasi",
                    Body = $"Halo {member.FullName},\n\nPassword baru Anda adalah: {newPassword}\n\nSilakan segera login dan ubah password kamu.",
                    IsBodyHtml = false, // format body
                    // <strong></strong>, <h1></h1>
                };
                mailMessage.To.Add(member.Email);

                // panggil method untuk mengirim email dengan password baru
                await smtpClient.SendMailAsync(mailMessage);

                member.Password = BCrypt.Net.BCrypt.HashPassword(newPassword); // hash password baru sebelum disimpan ke database
                await _repo.UpdateAsync(member); // update data member di database
                MessageBox.Show($"Your new password is: {newPassword}"); // tampilkan password baru kepada user
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting the password: {ex.Message}");
            }
        }
    }
}
