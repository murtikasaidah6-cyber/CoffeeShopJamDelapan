using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using CoffeeShopJamDelapan.Views.Cards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class PaymentPanel : UserControl
    {
        private int _idTransaction;
        public PaymentPanel(int idTransaction)
        {
            InitializeComponent();
            _idTransaction = idTransaction;
        

            _ = setTransactionInfo(idTransaction);
            _ = setTransactionDetail(idTransaction);
        }

        public async Task setTransactionInfo(int idTransaction)
        {
            TransactionRepo _transactionRepo = new();
            Transaction tx = await _transactionRepo.GetByIdAsync(idTransaction);
            textBoxTxCode.Text = tx.Code;
            textBoxTxDate.Text = tx.TransactionDate.ToString();
            textBoxSubtotal.Text = tx.Subtotal.ToString();
            textBoxTax.Text = tx.Tax.ToString();
            textBoxTotal.Text = tx.Total.ToString();
            textBoxNMenu.Text = tx.NMenu.ToString();

            if (tx.IdMember != null && tx.IdMember != 0)
            {
                // ambil data member dari transaksi
                MemberRepo _memberRepo = new();
                Member member = await _memberRepo.GetByIdAsync(tx.IdMember);
                if (member != null)
                {
                    textBoxName.Text = member.FullName;
                    textBoxAddress.Text = "-";
                    textBoxPhone.Text = member.Phone;
                    textBoxEmail.Text = member.Email;

                    textBoxName.ReadOnly = true;
                    textBoxAddress.ReadOnly = true;
                    textBoxPhone.ReadOnly = true;
                    textBoxEmail.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Member not found");
                }
            }
            else
            {
                textBoxName.Text = "";
                textBoxAddress.Text = "-";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";

                textBoxName.ReadOnly = false;
                textBoxAddress.ReadOnly = false;
                textBoxPhone.ReadOnly = false;
                textBoxEmail.ReadOnly = false;
            }
        }

        public async Task setTransactionDetail(int idTransaction)
        {
            TransactionDetailsRepo _transactionDetailsRepo = new();
            RecipeRepo _recipeRepo = new();
            List<TransactionDetails> details = await _transactionDetailsRepo.GetByTransactionIdAsync(idTransaction); // collection
            foreach (TransactionDetails txd in details)
            {
                Prescription recipe = await _recipeRepo.GetByIdAsync(txd.IdRecipe);
                OrderCard orderCard = new OrderCard(recipe, this, txd);
                flowLayoutPayment.Invoke(delegate
                {
                    flowLayoutPayment.Controls.Add(orderCard);
                });
            }
        }

        private async void buttonPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pembayaran berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TransactionRepo transactionRepo = new();
            TransactionDetailsRepo transactionDetailsRepo = new();
            RecipeRepo recipeRepo = new();
            ItemRepo itemRepo = new();


            List<TransactionDetails> details = await transactionDetailsRepo.GetByTransactionIdAsync(_idTransaction);
            foreach (TransactionDetails txd in details)
            {
                Prescription recipe = await recipeRepo.GetByIdAsync(txd.IdRecipe);
                if (recipe.IdItemA != null)
                {
                    Item itemA = await itemRepo.GetByIdAsync((int)recipe.IdItemA);
                    itemA.Quantity -= (recipe.QtyItemA ?? 0) * txd.Quantity;
                    itemA.LastUpdate = DateTime.UtcNow;
                    itemRepo.UpdateAsync(itemA);
                }

                if (recipe.IdItemB != null)
                {
                    Item itemB = await itemRepo.GetByIdAsync((int)recipe.IdItemB);
                    itemB.Quantity -= (recipe.QtyItemB ?? 0) * txd.Quantity;
                    itemB.LastUpdate = DateTime.UtcNow;
                    itemRepo.UpdateAsync(itemB);
                }

                if (recipe.IdItemC != null)
                {
                    Item itemC = await itemRepo.GetByIdAsync((int)recipe.IdItemC);
                    itemC.Quantity -= (recipe.QtyItemC ?? 0) * txd.Quantity;
                    itemC.LastUpdate = DateTime.UtcNow;
                    itemRepo.UpdateAsync(itemC);
                }

                if (recipe.IdItemD != null)
                {
                    Item itemD = await itemRepo.GetByIdAsync((int)recipe.IdItemD);
                    itemD.Quantity -= (recipe.QtyItemD ?? 0) * txd.Quantity;
                    itemD.LastUpdate = DateTime.UtcNow;
                    itemRepo.UpdateAsync(itemD);
                }
            }

            Transaction tx = await transactionRepo.GetByIdAsync(_idTransaction);
            tx.Paid = tx.Total;
            transactionRepo.UpdateAsync(tx);
            buttonPay.Visible = false;

        }
    }
}
