using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            MemberRepo memberRepo = new MemberRepo();
            Member member = new Member
            {
                FullName = textName.Text,
                Email = textEmail.Text,
                Password = textPassword.Text,
                Phone = textPhone.Text,
                Username = textUsername.Text,
                IsDeleted = "0",
            };
            memberRepo.CreateAsync(member);
        }
    }
}
