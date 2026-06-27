namespace CoffeeShopJamDelapan.Views.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            labelCaptcha = new Label();
            textBoxCaptcha = new TextBox();
            buttonRefreshCaptcha = new Button();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            mySqlCommand1 = new MySqlConnector.MySqlCommand();
            button1 = new Button();
            buttonRegister = new Button();
            linkResetPassword = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(327, 90);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(197, 27);
            textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(327, 130);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(197, 27);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(248, 226);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(276, 34);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.Click += buttonLogin_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 93);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 133);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // labelCaptcha
            // 
            labelCaptcha.BackColor = Color.OrangeRed;
            labelCaptcha.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCaptcha.Location = new Point(262, 162);
            labelCaptcha.Name = "labelCaptcha";
            labelCaptcha.Size = new Size(143, 55);
            labelCaptcha.TabIndex = 13;
            labelCaptcha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxCaptcha
            // 
            textBoxCaptcha.Location = new Point(411, 159);
            textBoxCaptcha.Name = "textBoxCaptcha";
            textBoxCaptcha.Size = new Size(113, 27);
            textBoxCaptcha.TabIndex = 14;
            // 
            // buttonRefreshCaptcha
            // 
            buttonRefreshCaptcha.Location = new Point(411, 186);
            buttonRefreshCaptcha.Name = "buttonRefreshCaptcha";
            buttonRefreshCaptcha.Size = new Size(113, 28);
            buttonRefreshCaptcha.TabIndex = 15;
            buttonRefreshCaptcha.Text = "Refresh";
            buttonRefreshCaptcha.Click += buttonRefreshCaptcha_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("News706 BT", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(244, 20);
            label3.Name = "label3";
            label3.Size = new Size(310, 52);
            label3.TabIndex = 16;
            label3.Text = "Apotek Jam 8";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Ravie", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(442, 23);
            label4.Name = "label4";
            label4.Size = new Size(49, 50);
            label4.TabIndex = 17;
            label4.Text = "8";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(5, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(226, 289);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CommandTimeout = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.Transaction = null;
            mySqlCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLight;
            button1.Location = new Point(519, 3);
            button1.Name = "button1";
            button1.Size = new Size(23, 27);
            button1.TabIndex = 19;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(442, 287);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(90, 28);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Register";
            // 
            // linkResetPassword
            // 
            linkResetPassword.AutoSize = true;
            linkResetPassword.Location = new Point(248, 293);
            linkResetPassword.Name = "linkResetPassword";
            linkResetPassword.Size = new Size(118, 20);
            linkResetPassword.TabIndex = 20;
            linkResetPassword.TabStop = true;
            linkResetPassword.Text = "Forgot Password";
            linkResetPassword.LinkClicked += linkResetPassword_LinkClicked;
            // 
            // LoginForm
            // 
            ClientSize = new Size(544, 321);
            Controls.Add(linkResetPassword);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelCaptcha);
            Controls.Add(textBoxCaptcha);
            Controls.Add(buttonRefreshCaptcha);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            Controls.Add(buttonRegister);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Label label1;
        private Label label2;
        private Label labelCaptcha;
        private TextBox textBoxCaptcha;
        private Button buttonRefreshCaptcha;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private MySqlConnector.MySqlCommand mySqlCommand1;
        private Button button1;
        private Button buttonRegister;
        private LinkLabel linkResetPassword;
    }
}
