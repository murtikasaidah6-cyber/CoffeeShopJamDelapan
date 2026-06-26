using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CoffeeShopJamDelapan.Services;
using CoffeeShopJamDelapan.Views.Forms;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class MyCartPanel : UserControl
    {
        private readonly TransactionRepo _txRepo = new();
        private readonly MemberRepo _memberRepo = new();
        private List<CartItem> _cart = new();
        private AdminForm _adminForm;

        public MyCartPanel(AdminForm adminForm) // ditambah  
        {
            InitializeComponent();
            _adminForm = adminForm; // di tambah 
            buttonClearCart.Click += (s, e) => { _cart.Clear(); RefreshCartGrid(); };
            buttonCheckout.Click += ButtonCheckout_Click;
            _ = LoadMembersAsync();
            // subscribe to shared cart
            CartService.Instance.CartChanged += (s, e) => { SyncFromService(); };
            SyncFromService();
        }

        private void SyncFromService()
        {
            _cart.Clear();
            foreach (var it in CartService.Instance.Items) _cart.Add(new CartItem { RecipeId = it.RecipeId, RecipeCode = it.RecipeCode, RecipeName = it.RecipeName, Qty = it.Qty, UnitPrice = it.UnitPrice });
            RefreshCartGrid();

        }

        private async Task LoadMembersAsync()
        {
            var list = await _memberRepo.GetAllAsync();
            comboBoxMember.Items.Clear();
            comboBoxMember.Items.Add(new ComboItem(0, "Guest"));
            foreach (var m in list)
            {
                comboBoxMember.Items.Add(
                    new ComboItem(m.IdMember, m.FullName ?? m.Username));
            }
            comboBoxMember.SelectedIndex = 0;
        }

        private void ButtonRemove_Click(object? sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0) return;
            var id = (int)dgvCart.SelectedRows[0].Cells["RecipeId"].Value;
            var ci = _cart.FirstOrDefault(x => x.RecipeId == id);
            if (ci != null) _cart.Remove(ci);
            RefreshCartGrid();
        }

        public void RefreshCartGrid(List<CartItem> cart)
        {
            _cart = cart;
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart.Select(c => new
            {
                c.RecipeId,
                c.RecipeCode,
                c.RecipeName,
                Qty = c.Qty,
                UnitPrice = c.UnitPrice,
                LineTotal = c.LineTotal
            }).ToList();
            dgvCart.Columns[0].Visible = false;

            var subtotal = _cart.Sum(c => c.LineTotal);
            var tax = subtotal * 0.1;
            var total = subtotal + tax;
            labelSubtotal.Text = $"Subtotal: {subtotal:0.00}";
            labelTax.Text = $"Tax: {tax:0.00}";
            labelTotal.Text = $"Total: {total:0.00}";
        }

        public void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.Select(c => new
            {
                c.RecipeId,
                c.RecipeCode,
                c.RecipeName,
                Qty = c.Qty,
                UnitPrice = c.UnitPrice,
                LineTotal = c.LineTotal
            }).ToList();
            dgvCart.Columns[0].Visible = false;


            var subtotal = _cart.Sum(c => c.LineTotal);
            var tax = subtotal * 0.1;
            var total = subtotal + tax;
            labelSubtotal.Text = $"Subtotal: {subtotal:0.00}";
            labelTax.Text = $"Tax: {tax:0.00}";
            labelTotal.Text = $"Total: {total:0.00}";
        }

        private async void ButtonCheckout_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0) // _cart = koleksi menu/item yang ditambahkan dari transaction
            {
                MessageBox.Show("Cart is empty");
                return;
                // enhance pop-up (audio: faahhh.mav)
            }

            if (comboBoxMember.SelectedItem == null) // memilih member
            {
                MessageBox.Show("Please select a member");
                return;
            }

            var TaxRate = 10;
            var Tax = _cart.Sum(c => c.LineTotal) * (TaxRate / 100);
            var Total = _cart.Sum(c => c.LineTotal) * (1 + Tax);
            var Paid = _cart.Sum(c => c.LineTotal) * (1 + Tax);
            var tx = new Transaction
            {
                IdMember = comboBoxMember.SelectedItem is ComboItem ci ? ci.Id : 0,
                Code = "T" + DateTime.Now.ToString("yyMMddHHmmss"),
                NMenu = _cart.Count,
                TransactionDate = DateTime.Now,
                Subtotal = _cart.Sum(c => c.LineTotal),
                TaxRate = 10, // ubah
                Tax = _cart.Sum(c => c.LineTotal) * (10 / 100), // ubah
                Total = _cart.Sum(c => c.LineTotal * (1 + (c.LineTotal + c.LineTotal) * (10 / 100))), //ubah
                Paid = Paid,
                Change = 0
            };

            var id = await _txRepo.CreateAsync(tx);
            var tir = new TransactionDetailsRepo();
            foreach (var c in _cart)
            {
                var ti = new TransactionDetails
                {
                    IdTransaction = id,
                    IdRecipe = c.RecipeId,
                    Quantity = c.Qty,
                    Price = c.UnitPrice,
                    Total = c.LineTotal
                };
                await tir.CreateAsync(ti);
            }

            MessageBox.Show($"Transaction saved. Transaction Code is {tx.Code}");
            _cart.Clear();
            RefreshCartGrid();

            _adminForm.showPaymentPanel(id);
        }
    }
}
