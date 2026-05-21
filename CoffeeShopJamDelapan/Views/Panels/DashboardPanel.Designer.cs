namespace CoffeeShopJamDelapan.Views.Panels
{
    partial class DashboardPanel
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
            counterMember = new Panel();
            counterStock = new Panel();
            counterTrx = new Panel();
            counterRecipe = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            counterMember.SuspendLayout();
            counterStock.SuspendLayout();
            counterTrx.SuspendLayout();
            counterRecipe.SuspendLayout();
            SuspendLayout();
            // 
            // counterMember
            // 
            counterMember.BackColor = Color.FromArgb(192, 255, 192);
            counterMember.Controls.Add(label2);
            counterMember.Controls.Add(label1);
            counterMember.Location = new Point(30, 28);
            counterMember.Name = "counterMember";
            counterMember.Size = new Size(200, 100);
            counterMember.TabIndex = 0;
            // 
            // counterStock
            // 
            counterStock.BackColor = Color.FromArgb(224, 224, 224);
            counterStock.Controls.Add(label5);
            counterStock.Controls.Add(label6);
            counterStock.Location = new Point(30, 158);
            counterStock.Name = "counterStock";
            counterStock.Size = new Size(200, 100);
            counterStock.TabIndex = 1;
            // 
            // counterTrx
            // 
            counterTrx.BackColor = Color.FromArgb(255, 255, 192);
            counterTrx.Controls.Add(label3);
            counterTrx.Controls.Add(label4);
            counterTrx.Location = new Point(315, 28);
            counterTrx.Name = "counterTrx";
            counterTrx.Size = new Size(200, 100);
            counterTrx.TabIndex = 2;
            // 
            // counterRecipe
            // 
            counterRecipe.BackColor = Color.FromArgb(255, 192, 192);
            counterRecipe.Controls.Add(label7);
            counterRecipe.Controls.Add(label8);
            counterRecipe.Location = new Point(315, 158);
            counterRecipe.Name = "counterRecipe";
            counterRecipe.Size = new Size(200, 100);
            counterRecipe.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 24);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Jumlah Member";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(141, 66);
            label2.Name = "label2";
            label2.Size = new Size(25, 30);
            label2.TabIndex = 1;
            label2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(143, 66);
            label3.Name = "label3";
            label3.Size = new Size(25, 30);
            label3.TabIndex = 3;
            label3.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 24);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 2;
            label4.Text = "Jumlah Transaksi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(141, 60);
            label5.Name = "label5";
            label5.Size = new Size(25, 30);
            label5.TabIndex = 5;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 18);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 4;
            label6.Text = "Total Stock";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(143, 60);
            label7.Name = "label7";
            label7.Size = new Size(25, 30);
            label7.TabIndex = 7;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 18);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 6;
            label8.Text = "Total Recipe";
            // 
            // DashboardPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(counterRecipe);
            Controls.Add(counterTrx);
            Controls.Add(counterStock);
            Controls.Add(counterMember);
            Name = "DashboardPanel";
            Size = new Size(618, 333);
            counterMember.ResumeLayout(false);
            counterMember.PerformLayout();
            counterStock.ResumeLayout(false);
            counterStock.PerformLayout();
            counterTrx.ResumeLayout(false);
            counterTrx.PerformLayout();
            counterRecipe.ResumeLayout(false);
            counterRecipe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel counterMember;
        private Panel counterStock;
        private Panel counterTrx;
        private Panel counterRecipe;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label8;
    }
}
