namespace CoffeeShopJamDelapan.Views.Panels
{
    partial class HistoryPanel
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
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            buttonFilter = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvTransaction = new DataGridView();
            buttonView = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTransaction).BeginInit();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(94, 69);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 0;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(391, 69);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 1;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(647, 70);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(139, 29);
            buttonFilter.TabIndex = 2;
            buttonFilter.Text = "Filter ";
            buttonFilter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 69);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 3;
            label1.Text = "Strat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 70);
            label2.Name = "label2";
            label2.Size = new Size(23, 20);
            label2.TabIndex = 4;
            label2.Text = "to";
            // 
            // dgvTransaction
            // 
            dgvTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaction.Location = new Point(26, 116);
            dgvTransaction.Name = "dgvTransaction";
            dgvTransaction.RowHeadersWidth = 51;
            dgvTransaction.Size = new Size(775, 397);
            dgvTransaction.TabIndex = 5;
            // 
            // buttonView
            // 
            buttonView.Location = new Point(350, 548);
            buttonView.Name = "buttonView";
            buttonView.Size = new Size(139, 29);
            buttonView.TabIndex = 6;
            buttonView.Text = "View";
            buttonView.UseVisualStyleBackColor = true;
            // 
            // HistoryPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonView);
            Controls.Add(dgvTransaction);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonFilter);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Name = "HistoryPanel";
            Size = new Size(912, 602);
            ((System.ComponentModel.ISupportInitialize)dgvTransaction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Button buttonFilter;
        private Label label1;
        private Label label2;
        private DataGridView dgvTransaction;
        private Button buttonView;
    }
}
