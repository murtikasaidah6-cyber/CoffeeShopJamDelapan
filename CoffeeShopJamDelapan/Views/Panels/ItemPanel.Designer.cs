namespace CoffeeShopJamDelapan.Views.Panels
{
    partial class ItemPanel
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
            dgvItem = new DataGridView();
            textSearch = new TextBox();
            label1 = new Label();
            textTitle = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textQty = new TextBox();
            label5 = new Label();
            textPrice = new TextBox();
            label6 = new Label();
            textLastUpdate = new TextBox();
            textIdItem = new TextBox();
            label7 = new Label();
            buttonClear = new Button();
            buttonSubmit = new Button();
            buttonNew = new Button();
            buttonRefresh = new Button();
            buttonDelete = new Button();
            comboMeasurement = new ComboBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItem).BeginInit();
            SuspendLayout();
            // 
            // dgvItem
            // 
            dgvItem.AllowUserToAddRows = false;
            dgvItem.AllowUserToDeleteRows = false;
            dgvItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItem.Location = new Point(378, 81);
            dgvItem.Name = "dgvItem";
            dgvItem.ReadOnly = true;
            dgvItem.Size = new Size(473, 419);
            dgvItem.TabIndex = 0;
            dgvItem.SelectionChanged += DgvItem_SelectionChanged;
            // 
            // textSearch
            // 
            textSearch.Location = new Point(636, 36);
            textSearch.Name = "textSearch";
            textSearch.Size = new Size(215, 23);
            textSearch.TabIndex = 2;
            textSearch.TextChanged += textSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(588, 39);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Search";
            // 
            // textTitle
            // 
            textTitle.Location = new Point(35, 107);
            textTitle.Name = "textTitle";
            textTitle.Size = new Size(285, 23);
            textTitle.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 89);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 141);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 7;
            label3.Text = "Measurement";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 194);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 9;
            label4.Text = "Quantity";
            // 
            // textQty
            // 
            textQty.Location = new Point(35, 212);
            textQty.Name = "textQty";
            textQty.Size = new Size(285, 23);
            textQty.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 250);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 11;
            label5.Text = "Price";
            // 
            // textPrice
            // 
            textPrice.Location = new Point(35, 268);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(285, 23);
            textPrice.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 304);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 13;
            label6.Text = "Last Update";
            // 
            // textLastUpdate
            // 
            textLastUpdate.Location = new Point(35, 322);
            textLastUpdate.Name = "textLastUpdate";
            textLastUpdate.ReadOnly = true;
            textLastUpdate.Size = new Size(285, 23);
            textLastUpdate.TabIndex = 12;
            // 
            // textIdItem
            // 
            textIdItem.Location = new Point(32, 535);
            textIdItem.Name = "textIdItem";
            textIdItem.Size = new Size(225, 23);
            textIdItem.TabIndex = 14;
            textIdItem.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(35, 25);
            label7.Name = "label7";
            label7.Size = new Size(66, 32);
            label7.TabIndex = 15;
            label7.Text = "Item";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(35, 362);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(85, 33);
            buttonClear.TabIndex = 16;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(130, 362);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(85, 33);
            buttonSubmit.TabIndex = 17;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(481, 506);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(85, 33);
            buttonNew.TabIndex = 18;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(663, 506);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(85, 33);
            buttonRefresh.TabIndex = 21;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(572, 506);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(85, 33);
            buttonDelete.TabIndex = 20;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // comboMeasurement
            // 
            comboMeasurement.FormattingEnabled = true;
            comboMeasurement.Items.AddRange(new object[] { "Grams", "Mililitres", "Pieces" });
            comboMeasurement.Location = new Point(32, 159);
            comboMeasurement.Name = "comboMeasurement";
            comboMeasurement.Size = new Size(288, 23);
            comboMeasurement.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(378, 63);
            label8.Name = "label8";
            label8.Size = new Size(52, 15);
            label8.TabIndex = 23;
            label8.Text = "Item List";
            // 
            // ItemPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label8);
            Controls.Add(comboMeasurement);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonDelete);
            Controls.Add(buttonNew);
            Controls.Add(buttonSubmit);
            Controls.Add(buttonClear);
            Controls.Add(label7);
            Controls.Add(textIdItem);
            Controls.Add(label6);
            Controls.Add(textLastUpdate);
            Controls.Add(label5);
            Controls.Add(textPrice);
            Controls.Add(label4);
            Controls.Add(textQty);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textTitle);
            Controls.Add(label1);
            Controls.Add(textSearch);
            Controls.Add(dgvItem);
            Name = "ItemPanel";
            Size = new Size(875, 575);
            ((System.ComponentModel.ISupportInitialize)dgvItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItem;
        private TextBox textSearch;
        private Label label1;
        private TextBox textTitle;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textQty;
        private Label label5;
        private TextBox textPrice;
        private Label label6;
        private TextBox textLastUpdate;
        private TextBox textIdItem;
        private Label label7;
        private Button buttonClear;
        private Button buttonSubmit;
        private Button buttonNew;
        private Button buttonRefresh;
        private Button buttonDelete;
        private ComboBox comboMeasurement;
        private Label label8;
    }
}
