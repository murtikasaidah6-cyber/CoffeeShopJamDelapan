using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Views.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Cards
{
    public partial class MenuCard : UserControl
    {
        private List<CartItem> _cart;
        private MyCartPanel _cartPanel;
        private Recipe _recipe;

        public MenuCard(Recipe recipe, List<CartItem> cart, MyCartPanel cartPanel)
        {
            InitializeComponent();
            _cart = cart;
            _cartPanel = cartPanel;
            _recipe = recipe;

            if (!string.IsNullOrWhiteSpace(recipe.ImagePath)
                && System.IO.File.Exists(recipe.ImagePath))
            {
                pictureBoxMenu.Image = Image.FromFile(recipe.ImagePath);

            }




            labelName.Text = recipe.Code + "-" + recipe.Name;
            labelPrice.Text = recipe.Price.HasValue ? $"IDR {recipe.Price:0.00}"
                : "Price not available";
            buttonAddCart.Tag = recipe;
            buttonAddCart.Click += ButtonAddCard_Click;

        }

        private void ButtonAddCard_Click(object? s, EventArgs e)
        {
            int qty = int.Parse(textBoxQty.Text);
            if (qty == 0)
            {
                MessageBox.Show("Quantity must be a number greater than 0.", "Invalid Quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                var item = new CartItem
                {
                    RecipeId = _recipe.IdReceipt,
                    RecipeCode = _recipe.Code,
                    RecipeName = _recipe.Name,
                    Qty = qty,
                    UnitPrice = _recipe.Price ?? 0
                };

                if (_cart != null)
                {
                    var existing = _cart.Find(x => x.RecipeId == item.RecipeId);
                    if (existing != null) existing.Qty += 1;
                    else _cart.Add(item);
                }

                CoffeeShopJamDelapan.Services.CartService.Instance.Add(new CartItem
                {
                    RecipeId = item.RecipeId,
                    RecipeCode = item.RecipeCode,
                    RecipeName = item.RecipeName,
                    Qty = item.Qty,
                    UnitPrice = item.UnitPrice
                });

                _cartPanel?.RefreshCartGrid(_cart);
            }
        


        private void MenuCard_Load(object sender, EventArgs e)
        {

        }
    }
}
