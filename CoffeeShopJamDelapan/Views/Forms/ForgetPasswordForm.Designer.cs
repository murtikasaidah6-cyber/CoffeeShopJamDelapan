namespace CoffeeShopJamDelapan.Views.Forms
{
    partial class ForgetPasswordForm
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
            label1 = new Label();
            label2 = new Label();
            textEmail = new TextBox();
            buttonBack = new Button();
            buttonReset = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 30);
            label1.TabIndex = 0;
            label1.Text = "Forget Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 64);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // textEmail
            // 
            textEmail.Location = new Point(25, 82);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(329, 23);
            textEmail.TabIndex = 2;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(44, 121);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(123, 42);
            buttonBack.TabIndex = 3;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(182, 121);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(123, 42);
            buttonReset.TabIndex = 4;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 204);
            label3.Name = "label3";
            label3.Size = new Size(329, 30);
            label3.TabIndex = 5;
            label3.Text = "Password akan dikirim melalui email.\r\nPastikan Anda sudah terdaftar dan memiliki email yang valid.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ForgetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 260);
            Controls.Add(label3);
            Controls.Add(buttonReset);
            Controls.Add(buttonBack);
            Controls.Add(textEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgetPasswordForm";
            Text = "ForgetPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textEmail;
        private Button buttonBack;
        private Button buttonReset;
        private Label label3;
    }
}