namespace CoffeeShopJamDelapan.Views.Cards
{
    partial class OrderCard
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
            pictureBoxItem = new PictureBox();
            labelItemName = new Label();
            labelItemPrice = new Label();
            labelItemCode = new Label();
            labelItemCategory = new Label();
            labelItemSubtotal = new Label();
            labelItemQty = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxItem
            // 
            pictureBoxItem.Location = new Point(3, 3);
            pictureBoxItem.Name = "pictureBoxItem";
            pictureBoxItem.Size = new Size(120, 111);
            pictureBoxItem.TabIndex = 0;
            pictureBoxItem.TabStop = false;
            // 
            // labelItemName
            // 
            labelItemName.AutoSize = true;
            labelItemName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelItemName.Location = new Point(129, 3);
            labelItemName.Name = "labelItemName";
            labelItemName.Size = new Size(117, 28);
            labelItemName.TabIndex = 1;
            labelItemName.Text = "wwwwwww";
            // 
            // labelItemPrice
            // 
            labelItemPrice.AutoSize = true;
            labelItemPrice.Location = new Point(152, 43);
            labelItemPrice.Name = "labelItemPrice";
            labelItemPrice.Size = new Size(75, 20);
            labelItemPrice.TabIndex = 2;
            labelItemPrice.Text = "wwwwww";
            // 
            // labelItemCode
            // 
            labelItemCode.AutoSize = true;
            labelItemCode.Location = new Point(152, 63);
            labelItemCode.Name = "labelItemCode";
            labelItemCode.Size = new Size(72, 20);
            labelItemCode.TabIndex = 3;
            labelItemCode.Text = "vvvvvvvvv";
            // 
            // labelItemCategory
            // 
            labelItemCategory.AutoSize = true;
            labelItemCategory.Location = new Point(356, 11);
            labelItemCategory.Name = "labelItemCategory";
            labelItemCategory.Size = new Size(44, 20);
            labelItemCategory.TabIndex = 4;
            labelItemCategory.Text = "vvvvv";
            // 
            // labelItemSubtotal
            // 
            labelItemSubtotal.AutoSize = true;
            labelItemSubtotal.Location = new Point(163, 94);
            labelItemSubtotal.Name = "labelItemSubtotal";
            labelItemSubtotal.Size = new Size(50, 20);
            labelItemSubtotal.TabIndex = 5;
            labelItemSubtotal.Text = "label1";
            // 
            // labelItemQty
            // 
            labelItemQty.AutoSize = true;
            labelItemQty.Location = new Point(356, 84);
            labelItemQty.Name = "labelItemQty";
            labelItemQty.Size = new Size(50, 20);
            labelItemQty.TabIndex = 6;
            labelItemQty.Text = "label1";
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelItemQty);
            Controls.Add(labelItemSubtotal);
            Controls.Add(labelItemCategory);
            Controls.Add(labelItemCode);
            Controls.Add(labelItemPrice);
            Controls.Add(labelItemName);
            Controls.Add(pictureBoxItem);
            Name = "OrderCard";
            Size = new Size(510, 117);
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxItem;
        private Label labelItemName;
        private Label labelItemPrice;
        private Label labelItemCode;
        private Label labelItemCategory;
        private Label labelItemSubtotal;
        private Label labelItemQty;
    }
}
