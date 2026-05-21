namespace CoffeeShopJamDelapan.Views.Panels
{
    partial class MyCartPanel
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
            label1 = new Label();
            comboBoxMember = new ComboBox();
            dgvCart = new DataGridView();
            labelSubtotal = new Label();
            labelTax = new Label();
            labelTotal = new Label();
            buttonCheckout = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 6);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 0;
            label1.Text = "Member ";
            // 
            // comboBoxMember
            // 
            comboBoxMember.FormattingEnabled = true;
            comboBoxMember.Location = new Point(15, 37);
            comboBoxMember.Name = "comboBoxMember";
            comboBoxMember.Size = new Size(288, 28);
            comboBoxMember.TabIndex = 1;
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(15, 84);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(288, 366);
            dgvCart.TabIndex = 2;
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Location = new Point(97, 472);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(50, 20);
            labelSubtotal.TabIndex = 3;
            labelSubtotal.Text = "label1";
            // 
            // labelTax
            // 
            labelTax.AutoSize = true;
            labelTax.Location = new Point(97, 507);
            labelTax.Name = "labelTax";
            labelTax.Size = new Size(50, 20);
            labelTax.TabIndex = 4;
            labelTax.Text = "label1";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(97, 549);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(50, 20);
            labelTotal.TabIndex = 5;
            labelTotal.Text = "label1";
            // 
            // buttonCheckout
            // 
            buttonCheckout.Location = new Point(15, 581);
            buttonCheckout.Name = "buttonCheckout";
            buttonCheckout.Size = new Size(288, 29);
            buttonCheckout.TabIndex = 6;
            buttonCheckout.Text = "Checkuot";
            buttonCheckout.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(15, 633);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(288, 29);
            buttonClear.TabIndex = 7;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // MyCartPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonClear);
            Controls.Add(buttonCheckout);
            Controls.Add(labelTotal);
            Controls.Add(labelTax);
            Controls.Add(labelSubtotal);
            Controls.Add(dgvCart);
            Controls.Add(comboBoxMember);
            Controls.Add(label1);
            Name = "MyCartPanel";
            Size = new Size(1000, 767);
            Load += MyCartPanel_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxMember;
        private DataGridView dgvCart;
        private Label labelSubtotal;
        private Label labelTax;
        private Label labelTotal;
        private Button buttonCheckout;
        private Button buttonClear;
    }
}
