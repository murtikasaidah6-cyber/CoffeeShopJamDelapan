namespace CoffeeShopJamDelapan.Views.Forms
{
    partial class ForgotPasswordForm
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
            buttonClose = new Button();
            label6 = new Label();
            label4 = new Label();
            textEmail = new TextBox();
            buttonReset = new Button();
            label1 = new Label();
            buttonBack = new Button();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.DarkRed;
            buttonClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.ForeColor = SystemColors.ControlLight;
            buttonClose.Location = new Point(306, -1);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(23, 27);
            buttonClose.TabIndex = 21;
            buttonClose.Text = "X";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(277, 50);
            label6.TabIndex = 22;
            label6.Text = "Forgot Password";
            // 
            // label4
            // 
            label4.Location = new Point(26, 72);
            label4.Name = "label4";
            label4.Size = new Size(46, 18);
            label4.TabIndex = 23;
            label4.Text = "Email";
            // 
            // textEmail
            // 
            textEmail.Location = new Point(26, 93);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(273, 23);
            textEmail.TabIndex = 24;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(146, 122);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(100, 32);
            buttonReset.TabIndex = 25;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // label1
            // 
            label1.Location = new Point(26, 191);
            label1.Name = "label1";
            label1.Size = new Size(273, 40);
            label1.TabIndex = 26;
            label1.Text = "Password baru akan dikirmkan melalui email.\r\nPastikan email sudah terdaftar!";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(40, 122);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(100, 32);
            buttonBack.TabIndex = 27;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 236);
            Controls.Add(buttonBack);
            Controls.Add(label1);
            Controls.Add(buttonReset);
            Controls.Add(label4);
            Controls.Add(textEmail);
            Controls.Add(label6);
            Controls.Add(buttonClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private Label label6;
        private Label label4;
        private TextBox textEmail;
        private Button buttonReset;
        private Label label1;
        private Button buttonBack;
    }
}