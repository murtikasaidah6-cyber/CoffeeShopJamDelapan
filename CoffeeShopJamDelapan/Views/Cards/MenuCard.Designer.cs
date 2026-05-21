namespace CoffeeShopJamDelapan.Views.Cards
{
    partial class MenuCard
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
            pictureBoxMenu = new PictureBox();
            labelName = new Label();
            labelPrice = new Label();
            buttonAddCart = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenu).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMenu
            // 
            pictureBoxMenu.Location = new Point(6, 6);
            pictureBoxMenu.Name = "pictureBoxMenu";
            pictureBoxMenu.Size = new Size(140, 120);
            pictureBoxMenu.TabIndex = 0;
            pictureBoxMenu.TabStop = false;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(45, 129);
            labelName.Name = "labelName";
            labelName.Size = new Size(50, 20);
            labelName.TabIndex = 1;
            labelName.Text = "label1";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrice.Location = new Point(32, 149);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(63, 28);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "label1";
            // 
            // buttonAddCart
            // 
            buttonAddCart.Location = new Point(17, 190);
            buttonAddCart.Name = "buttonAddCart";
            buttonAddCart.Size = new Size(108, 29);
            buttonAddCart.TabIndex = 3;
            buttonAddCart.Text = "Add To Cart";
            buttonAddCart.UseVisualStyleBackColor = true;
            buttonAddCart.Click += buttonAddCard_Click;
            // 
            // MenuCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            Controls.Add(buttonAddCart);
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Controls.Add(pictureBoxMenu);
            Name = "MenuCard";
            Size = new Size(150, 230);
            Load += MenuCard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxMenu;
        private Label labelName;
        private Label labelPrice;
        private Button buttonAddCart;
    }
}
