namespace CoffeeShopJamDelapan.Views.Forms
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textAddress = new TextBox();
            textUsername = new TextBox();
            textEmail = new TextBox();
            textPhone = new TextBox();
            textName = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textConfirmPassword = new TextBox();
            textPassword = new TextBox();
            buttonLogin = new Button();
            buttonSubmit = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 176);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 19;
            label5.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(185, 76);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 18;
            label4.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 76);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 17;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(185, 23);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 16;
            label2.Text = "Phone";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 23);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 15;
            label1.Text = "Name";
            // 
            // textAddress
            // 
            textAddress.Location = new Point(33, 194);
            textAddress.Multiline = true;
            textAddress.Name = "textAddress";
            textAddress.Size = new Size(316, 90);
            textAddress.TabIndex = 14;
            // 
            // textUsername
            // 
            textUsername.Location = new Point(185, 94);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(164, 23);
            textUsername.TabIndex = 13;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(33, 94);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(146, 23);
            textEmail.TabIndex = 12;
            // 
            // textPhone
            // 
            textPhone.Location = new Point(185, 41);
            textPhone.Name = "textPhone";
            textPhone.Size = new Size(164, 23);
            textPhone.TabIndex = 11;
            // 
            // textName
            // 
            textName.Location = new Point(33, 41);
            textName.Name = "textName";
            textName.Size = new Size(146, 23);
            textName.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(185, 125);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 23;
            label6.Text = "Confirm Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 125);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 22;
            label7.Text = "Password";
            // 
            // textConfirmPassword
            // 
            textConfirmPassword.Location = new Point(185, 143);
            textConfirmPassword.Name = "textConfirmPassword";
            textConfirmPassword.Size = new Size(164, 23);
            textConfirmPassword.TabIndex = 21;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(33, 143);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(146, 23);
            textPassword.TabIndex = 20;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(33, 299);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(98, 27);
            buttonLogin.TabIndex = 24;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(146, 299);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(98, 27);
            buttonSubmit.TabIndex = 25;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 385);
            Controls.Add(buttonSubmit);
            Controls.Add(buttonLogin);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(textConfirmPassword);
            Controls.Add(textPassword);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textAddress);
            Controls.Add(textUsername);
            Controls.Add(textEmail);
            Controls.Add(textPhone);
            Controls.Add(textName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignUpForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textAddress;
        private TextBox textUsername;
        private TextBox textEmail;
        private TextBox textPhone;
        private TextBox textName;
        private Label label6;
        private Label label7;
        private TextBox textConfirmPassword;
        private TextBox textPassword;
        private Button buttonLogin;
        private Button buttonSubmit;
    }
}