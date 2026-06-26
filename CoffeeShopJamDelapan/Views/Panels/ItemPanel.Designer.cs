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
            dgvItem.Location = new Point(372, 108);
            dgvItem.Margin = new Padding(3, 4, 3, 4);
            dgvItem.Name = "dgvItem";
            dgvItem.ReadOnly = true;
            dgvItem.RowHeadersWidth = 51;
            dgvItem.Size = new Size(513, 559);
            dgvItem.TabIndex = 0;
            dgvItem.SelectionChanged += DgvItem_SelectionChanged;
            // 
            // textSearch
            // 
            textSearch.Location = new Point(630, 51);
            textSearch.Margin = new Padding(3, 4, 3, 4);
            textSearch.Name = "textSearch";
            textSearch.Size = new Size(245, 27);
            textSearch.TabIndex = 2;
            textSearch.TextChanged += textSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(571, 54);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 3;
            label1.Text = "Search";
            // 
            // textTitle
            // 
            textTitle.Location = new Point(40, 143);
            textTitle.Margin = new Padding(3, 4, 3, 4);
            textTitle.Name = "textTitle";
            textTitle.Size = new Size(325, 27);
            textTitle.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 119);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 5;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 188);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 7;
            label3.Text = "Measurement";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 259);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 9;
            label4.Text = "Quantity";
            // 
            // textQty
            // 
            textQty.Location = new Point(40, 283);
            textQty.Margin = new Padding(3, 4, 3, 4);
            textQty.Name = "textQty";
            textQty.Size = new Size(325, 27);
            textQty.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 333);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 11;
            label5.Text = "Price";
            // 
            // textPrice
            // 
            textPrice.Location = new Point(40, 357);
            textPrice.Margin = new Padding(3, 4, 3, 4);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(325, 27);
            textPrice.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 405);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 13;
            label6.Text = "Last Update";
            // 
            // textLastUpdate
            // 
            textLastUpdate.Location = new Point(40, 429);
            textLastUpdate.Margin = new Padding(3, 4, 3, 4);
            textLastUpdate.Name = "textLastUpdate";
            textLastUpdate.ReadOnly = true;
            textLastUpdate.Size = new Size(325, 27);
            textLastUpdate.TabIndex = 12;
            // 
            // textIdItem
            // 
            textIdItem.Location = new Point(37, 713);
            textIdItem.Margin = new Padding(3, 4, 3, 4);
            textIdItem.Name = "textIdItem";
            textIdItem.Size = new Size(257, 27);
            textIdItem.TabIndex = 14;
            textIdItem.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(40, 33);
            label7.Name = "label7";
            label7.Size = new Size(83, 41);
            label7.TabIndex = 15;
            label7.Text = "Item";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(40, 483);
            buttonClear.Margin = new Padding(3, 4, 3, 4);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(97, 44);
            buttonClear.TabIndex = 16;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(149, 483);
            buttonSubmit.Margin = new Padding(3, 4, 3, 4);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(97, 44);
            buttonSubmit.TabIndex = 17;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(501, 675);
            buttonNew.Margin = new Padding(3, 4, 3, 4);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(97, 44);
            buttonNew.TabIndex = 18;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(707, 675);
            buttonRefresh.Margin = new Padding(3, 4, 3, 4);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(97, 44);
            buttonRefresh.TabIndex = 21;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(604, 675);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(97, 44);
            buttonDelete.TabIndex = 20;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // comboMeasurement
            // 
            comboMeasurement.FormattingEnabled = true;
            comboMeasurement.Items.AddRange(new object[] { "Grams", "Mililitres", "Pieces" });
            comboMeasurement.Location = new Point(37, 212);
            comboMeasurement.Margin = new Padding(3, 4, 3, 4);
            comboMeasurement.Name = "comboMeasurement";
            comboMeasurement.Size = new Size(329, 28);
            comboMeasurement.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(372, 84);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 23;
            label8.Text = "Item List";
            // 
            // ItemPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "ItemPanel";
            Size = new Size(902, 767);
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
