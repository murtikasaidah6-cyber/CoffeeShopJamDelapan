using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;

namespace CoffeeShopJamDelapan.Views.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly RecipeRepo _recipeRepo = new();
        private readonly List<CartItem> _cart = new();
        private readonly MemberRepo _memberRepo = new();

        public TransactionForm()
        {
            InitializeComponent();
            LoadMenuButtons();
            UpdateCartGrid();
        }

        private async void LoadMenuButtons()
        {
            // load recipes and map to sample buttons (limited)
            var recipes = await _recipeRepo.GetAllAsync();
            if (recipes.Count > 0)
            {
                button1.Text = recipes[0].Name ?? recipes[0].Code;
                button1.Tag = recipes[0];
                button1.Click += MenuButton_Click;
            }
            if (recipes.Count > 1)
            {
                button2.Text = recipes[1].Name ?? recipes[1].Code;
                button2.Tag = recipes[1];
                button2.Click += MenuButton_Click;
            }

            // load members for selector
            var members = await _memberRepo.GetAllAsync();
            comboBoxMember.Items.Clear();
            comboBoxMember.Items.Add(new { Id = 0, Text = "Select member" });
            foreach (var m in members) comboBoxMember.Items.Add(new { Id = m.IdMember, Text = m.FullName ?? m.Username });
            comboBoxMember.DisplayMember = "Text";
            comboBoxMember.ValueMember = "Id";
            comboBoxMember.SelectedIndex = 0;
        }

        private async void MenuButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Recipe r)
            {
                // try to find price from recipe or item_stock
                double price = 0;
                var itemRepo = new ItemRepo();
                if (r.IdItemA.HasValue)
                {
                    var item = await itemRepo.GetByIdAsync(r.IdItemA.Value);
                    if (item != null && item.Price.HasValue) price = item.Price.Value;
                }

                var existing = _cart.Find(c => c.RecipeId == r.IdReceipt);
                if (existing != null)
                {
                    existing.Qty += 1;
                }
                else
                {
                    _cart.Add(new CartItem { RecipeId = r.IdReceipt, RecipeCode = r.Code, RecipeName = r.Name, Qty = 1, UnitPrice = price });
                }
                UpdateCartGrid();
            }
        }

        private void UpdateCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;
            // add context menu for qty/remove
            if (dgvCart.ContextMenuStrip == null)
            {
                var cms = new ContextMenuStrip();
                var miIncrease = new ToolStripMenuItem("Increase Qty");
                var miDecrease = new ToolStripMenuItem("Decrease Qty");
                var miRemove = new ToolStripMenuItem("Remove");
                miIncrease.Click += (s, e) => ChangeQtySelected(1);
                miDecrease.Click += (s, e) => ChangeQtySelected(-1);
                miRemove.Click += (s, e) => RemoveSelectedItem();
                cms.Items.AddRange(new ToolStripItem[] { miIncrease, miDecrease, miRemove });
                dgvCart.ContextMenuStrip = cms;
            }
        }

        private void ChangeQtySelected(int delta)
        {
            if (dgvCart.SelectedRows.Count == 0) return;
            var item = dgvCart.SelectedRows[0].DataBoundItem as CartItem;
            if (item == null) return;
            item.Qty = Math.Max(0, item.Qty + delta);
            if (item.Qty == 0) _cart.Remove(item);
            UpdateCartGrid();
        }

        private void RemoveSelectedItem()
        {
            if (dgvCart.SelectedRows.Count == 0) return;
            var item = dgvCart.SelectedRows[0].DataBoundItem as CartItem;
            if (item == null) return;
            _cart.Remove(item);
            UpdateCartGrid();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void BtnCheckout_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Cart is empty", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // simple save: create transaction header and reduce stock for used items
            var tRepo = new TransactionRepo();
            // calculate totals
            double subtotal = 0;
            foreach (var c in _cart) subtotal += c.LineTotal;

            var trans = new Transaction
            {
                IdMember = 0, // guest
                Code = "T" + DateTime.Now.ToString("yyMMddHHmmss"),
                NMenu = _cart.Count,
                TransactionDate = DateTime.Now,
                Subtotal = subtotal,
                TaxRate = 0,
                Tax = 0,
                Total = subtotal,
                Paid = subtotal,
                Change = 0
            };

            var transId = await tRepo.CreateAsync(trans);

            // reduce stock by recipe ingredient quantities * qty
            var itemRepo = new ItemRepo();
            var recipeRepo = new RecipeRepo();
            foreach (var c in _cart)
            {
                var recipe = await recipeRepo.GetByIdAsync(c.RecipeId);
                if (recipe == null) continue;
                // for each ingredient A..D
                async Task Reduce(int? itemId, double? qtyPerRecipe)
                {
                    if (!itemId.HasValue || !qtyPerRecipe.HasValue) return;
                    var item = await itemRepo.GetByIdAsync(itemId.Value);
                    if (item == null) return;
                    var need = qtyPerRecipe.Value * c.Qty;
                    item.Quantity = (item.Quantity ?? 0) - need;
                    item.LastUpdate = DateTime.Now;
                    await itemRepo.UpdateAsync(item);
                }

                await Reduce(recipe.IdItemA, recipe.QtyItemA);
                await Reduce(recipe.IdItemB, recipe.QtyItemB);
                await Reduce(recipe.IdItemC, recipe.QtyItemC);
                await Reduce(recipe.IdItemD, recipe.QtyItemD);
            }

            MessageBox.Show($"Transaction saved id={transId}", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _cart.Clear();
            UpdateCartGrid();
        }
    }
}

