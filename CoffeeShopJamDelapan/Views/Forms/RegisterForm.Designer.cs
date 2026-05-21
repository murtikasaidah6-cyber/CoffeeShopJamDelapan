namespace CoffeeShopJamDelapan.Views.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            textBoxPhone = new TextBox();
            textBoxEmail = new TextBox();
            textBoxFullName = new TextBox();
            buttonSubmit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            labelCaptcha = new Label();
            textBoxCaptcha = new TextBox();
            buttonRefreshCaptcha = new Button();
            buttonLogin = new Button();
            label6 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(141, 91);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(234, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(141, 121);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(234, 23);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(141, 151);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(234, 23);
            textBoxPhone.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(141, 181);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(234, 23);
            textBoxEmail.TabIndex = 7;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(141, 211);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(234, 23);
            textBoxFullName.TabIndex = 9;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(202, 317);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(100, 34);
            buttonSubmit.TabIndex = 13;
            buttonSubmit.Text = "Register";
            // 
            // label1
            // 
            label1.Location = new Point(21, 94);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.Location = new Point(21, 124);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.Location = new Point(21, 154);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Phone";
            // 
            // label4
            // 
            label4.Location = new Point(21, 184);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 6;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.Location = new Point(21, 214);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 8;
            label5.Text = "Full Name";
            // 
            // labelCaptcha
            // 
            labelCaptcha.BackColor = Color.OrangeRed;
            labelCaptcha.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCaptcha.Location = new Point(141, 240);
            labelCaptcha.Name = "labelCaptcha";
            labelCaptcha.Size = new Size(114, 50);
            labelCaptcha.TabIndex = 10;
            labelCaptcha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxCaptcha
            // 
            textBoxCaptcha.Location = new Point(265, 240);
            textBoxCaptcha.Name = "textBoxCaptcha";
            textBoxCaptcha.Size = new Size(110, 23);
            textBoxCaptcha.TabIndex = 11;
            // 
            // buttonRefreshCaptcha
            // 
            buttonRefreshCaptcha.Location = new Point(265, 267);
            buttonRefreshCaptcha.Name = "buttonRefreshCaptcha";
            buttonRefreshCaptcha.Size = new Size(110, 23);
            buttonRefreshCaptcha.TabIndex = 12;
            buttonRefreshCaptcha.Text = "Refresh";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(84, 317);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(100, 34);
            buttonLogin.TabIndex = 14;
            buttonLogin.Text = "Login";
            buttonLogin.Click += buttonLogin_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(21, 19);
            label6.Name = "label6";
            label6.Size = new Size(206, 50);
            label6.TabIndex = 15;
            label6.Text = "Registration";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkRed;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlLight;
            button2.Location = new Point(376, 0);
            button2.Name = "button2";
            button2.Size = new Size(23, 27);
            button2.TabIndex = 20;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // RegisterForm
            // 
            ClientSize = new Size(399, 378);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(buttonLogin);
            Controls.Add(label1);
            Controls.Add(textBoxUsername);
            Controls.Add(label2);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxPhone);
            Controls.Add(label4);
            Controls.Add(textBoxEmail);
            Controls.Add(label5);
            Controls.Add(textBoxFullName);
            Controls.Add(labelCaptcha);
            Controls.Add(textBoxCaptcha);
            Controls.Add(buttonRefreshCaptcha);
            Controls.Add(buttonSubmit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Registration";
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private TextBox textBoxPhone;
        private TextBox textBoxEmail;
        private TextBox textBoxFullName;
        private Button buttonSubmit;
        private Label label1; private Label label2; private Label label3; private Label label4; private Label label5;
        private Label labelCaptcha; private TextBox textBoxCaptcha; private Button buttonRefreshCaptcha;
        private Button buttonLogin;
        private Label label6;
        private Button button2;
    }
}
