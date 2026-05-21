namespace CoffeeShopJamDelapan.Views.Panels
{
    partial class MemberPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textUsername = new TextBox();
            textPhone = new TextBox();
            textFullName = new TextBox();
            textEmail = new TextBox();
            textLastTransaction = new TextBox();
            textBoxSearch = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textIdMember = new TextBox();
            labelSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textUsername
            // 
            textUsername.Location = new Point(29, 124);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(291, 23);
            textUsername.TabIndex = 0;
            // 
            // textPhone
            // 
            textPhone.Location = new Point(29, 172);
            textPhone.Name = "textPhone";
            textPhone.Size = new Size(291, 23);
            textPhone.TabIndex = 1;
            // 
            // textFullName
            // 
            textFullName.Location = new Point(29, 273);
            textFullName.Name = "textFullName";
            textFullName.Size = new Size(291, 23);
            textFullName.TabIndex = 3;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(29, 225);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(291, 23);
            textEmail.TabIndex = 2;
            // 
            // textLastTransaction
            // 
            textLastTransaction.Location = new Point(29, 322);
            textLastTransaction.Name = "textLastTransaction";
            textLastTransaction.Size = new Size(291, 23);
            textLastTransaction.TabIndex = 4;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(488, 28);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(288, 23);
            textBoxSearch.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(17, 380);
            button1.Name = "button1";
            button1.Size = new Size(107, 35);
            button1.TabIndex = 5;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(127, 380);
            button2.Name = "button2";
            button2.Size = new Size(107, 35);
            button2.TabIndex = 6;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(237, 380);
            button3.Name = "button3";
            button3.Size = new Size(107, 35);
            button3.TabIndex = 15;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(371, 92);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(479, 460);
            dataGridView1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 106);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 8;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 154);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 9;
            label2.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 207);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 10;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 255);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 11;
            label4.Text = "Full Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 304);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 12;
            label5.Text = "Last Transaction";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(371, 74);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 13;
            label6.Text = "Member List";
            // 
            // textIdMember
            // 
            textIdMember.Location = new Point(17, 529);
            textIdMember.Name = "textIdMember";
            textIdMember.Size = new Size(245, 23);
            textIdMember.TabIndex = 14;
            textIdMember.Visible = false;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(372, 31);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(95, 15);
            labelSearch.TabIndex = 16;
            labelSearch.Text = "Search By Phone";
            // 
            // MemberPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textIdMember);
            Controls.Add(label6);
            Controls.Add(labelSearch);
            Controls.Add(textBoxSearch);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(textLastTransaction);
            Controls.Add(textFullName);
            Controls.Add(textEmail);
            Controls.Add(textPhone);
            Controls.Add(textUsername);
            Name = "MemberPanel";
            Size = new Size(875, 575);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textUsername;
        private TextBox textPhone;
        private TextBox textFullName;
        private TextBox textEmail;
        private TextBox textLastTransaction;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textIdMember;
        private TextBox textBoxSearch;
        private Label labelSearch;
    }
}
