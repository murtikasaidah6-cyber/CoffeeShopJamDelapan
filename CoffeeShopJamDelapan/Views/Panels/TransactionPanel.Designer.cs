namespace CoffeeShopJamDelapan.Views.Panels
{
    partial class TransactionPanel
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
            buttonAllMenu = new Button();
            buttonCoffee = new Button();
            buttonNonCoffee = new Button();
            buttonAppetizer = new Button();
            buttonMainCourse = new Button();
            buttonDesert = new Button();
            label2 = new Label();
            textBoxSearch = new TextBox();
            flowLayoutMenu = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 24);
            label1.Name = "label1";
            label1.Size = new Size(93, 38);
            label1.TabIndex = 0;
            label1.Text = "Menu";
            // 
            // buttonAllMenu
            // 
            buttonAllMenu.Location = new Point(26, 77);
            buttonAllMenu.Name = "buttonAllMenu";
            buttonAllMenu.Size = new Size(94, 29);
            buttonAllMenu.TabIndex = 1;
            buttonAllMenu.Text = "All";
            buttonAllMenu.UseVisualStyleBackColor = true;
            // 
            // buttonCoffee
            // 
            buttonCoffee.BackColor = Color.LightCoral;
            buttonCoffee.Location = new Point(137, 77);
            buttonCoffee.Name = "buttonCoffee";
            buttonCoffee.Size = new Size(94, 29);
            buttonCoffee.TabIndex = 2;
            buttonCoffee.Text = "Coffee";
            buttonCoffee.UseVisualStyleBackColor = false;
            // 
            // buttonNonCoffee
            // 
            buttonNonCoffee.BackColor = Color.LightCoral;
            buttonNonCoffee.Location = new Point(249, 77);
            buttonNonCoffee.Name = "buttonNonCoffee";
            buttonNonCoffee.Size = new Size(94, 29);
            buttonNonCoffee.TabIndex = 3;
            buttonNonCoffee.Text = "Non-Coffee";
            buttonNonCoffee.UseVisualStyleBackColor = false;
            // 
            // buttonAppetizer
            // 
            buttonAppetizer.BackColor = Color.LightCoral;
            buttonAppetizer.Location = new Point(363, 77);
            buttonAppetizer.Name = "buttonAppetizer";
            buttonAppetizer.Size = new Size(94, 29);
            buttonAppetizer.TabIndex = 4;
            buttonAppetizer.Text = "Appetizer";
            buttonAppetizer.UseVisualStyleBackColor = false;
            // 
            // buttonMainCourse
            // 
            buttonMainCourse.BackColor = Color.LightCoral;
            buttonMainCourse.Location = new Point(475, 77);
            buttonMainCourse.Name = "buttonMainCourse";
            buttonMainCourse.Size = new Size(94, 29);
            buttonMainCourse.TabIndex = 5;
            buttonMainCourse.Text = "Main-Course";
            buttonMainCourse.UseVisualStyleBackColor = false;
            // 
            // buttonDesert
            // 
            buttonDesert.BackColor = Color.LightCoral;
            buttonDesert.Location = new Point(588, 77);
            buttonDesert.Name = "buttonDesert";
            buttonDesert.Size = new Size(94, 29);
            buttonDesert.TabIndex = 6;
            buttonDesert.Text = "Desert";
            buttonDesert.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(717, 77);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 7;
            label2.Text = "Search";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(773, 77);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(199, 27);
            textBoxSearch.TabIndex = 8;
            // 
            // flowLayoutMenu
            // 
            flowLayoutMenu.Location = new Point(26, 134);
            flowLayoutMenu.Name = "flowLayoutMenu";
            flowLayoutMenu.Size = new Size(946, 608);
            flowLayoutMenu.TabIndex = 9;
            // 
            // TransactionPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSalmon;
            Controls.Add(flowLayoutMenu);
            Controls.Add(textBoxSearch);
            Controls.Add(label2);
            Controls.Add(buttonDesert);
            Controls.Add(buttonMainCourse);
            Controls.Add(buttonAppetizer);
            Controls.Add(buttonNonCoffee);
            Controls.Add(buttonCoffee);
            Controls.Add(buttonAllMenu);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TransactionPanel";
            Size = new Size(1000, 767);
            Load += TransactionPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonAllMenu;
        private Button buttonCoffee;
        private Button buttonNonCoffee;
        private Button buttonAppetizer;
        private Button buttonMainCourse;
        private Button buttonDesert;
        private Label label2;
        private TextBox textBoxSearch;
        private FlowLayoutPanel flowLayoutMenu;
    }
}
