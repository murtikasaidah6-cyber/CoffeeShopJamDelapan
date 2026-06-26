using CoffeeShopJamDelapan.Views.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Forms
{
    public partial class AdminForm : Form
    {
        MyCartPanel myCartPanel;
        public AdminForm()
        {
            myCartPanel = new MyCartPanel(this);
            InitializeComponent();
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new DashboardPanel());

            panelCart.Controls.Clear();
            panelCart.Controls.Add(myCartPanel);
        }

        public void showPaymentPanel(int idTransaction)

        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new PaymentPanel(idTransaction));

        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Yakin?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void recipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new RecipePanel());
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new MemberPanel());
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new DashboardPanel());
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new ItemPanel());
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new TransactionPanel(myCartPanel));//terhubung antara transactsion panel dan mycart panel
        }

        private void panelCart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new HistoryPanel(this));
        }
    }
}
