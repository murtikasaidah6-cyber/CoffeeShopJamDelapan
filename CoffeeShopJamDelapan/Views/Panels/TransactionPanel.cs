using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using CoffeeShopJamDelapan.Views.Cards;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class TransactionPanel : UserControl
    {
        private readonly RecipeRepo _recipeRepo = new();
        private readonly ItemRepo _itemRepo = new();
        private readonly MemberRepo _memberRepo = new();

        private List<CartItem> _cart = new();
        private MyCartPanel _cartPanel;

        public TransactionPanel(MyCartPanel cartPanel)
        {
            InitializeComponent();
            _cartPanel = cartPanel;

            buttonAppetizer.Click += (s, e) => LoadCategory("appetizer");
            buttonNonCoffee.Click += (s, e) => LoadCategory("non-coffee");
            buttonCoffee.Click += (s, e) => LoadCategory("coffee");
            buttonMainCourse.Click += (s, e) => LoadCategory("main-course");
            buttonDesert.Click += (s, e) => LoadCategory("dessert");

            //buttonCartCodeRecipe.Click += (s, e) => AddSelectedMenuToCart();


            textBoxSearch.TextChanged += async (s, e) => await SearchRecipesAsync(textBoxSearch.Text.Trim());

            _ = LoadRecipesAsync();
            //_ = LoadMembersAsync();
        }

        private async Task SearchRecipesAsync(string q)
        {
            var all = await _recipeRepo.GetAllAsync();
            var found = all.Where(r => string.IsNullOrWhiteSpace(q) || (r.Name?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false) || (r.Code?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();
            RenderMenuThumbnails(found);
        }

        private async Task LoadCategory(string category)
        {
            var all = await _recipeRepo.GetAllAsync();
            var found = all.Where(r => string.Equals(r.Type, category, StringComparison.OrdinalIgnoreCase)).ToList();
            RenderMenuThumbnails(found);
        }

        private void RenderMenuThumbnails(List<Recipe> recipes)
        {
            flowLayoutMenu.Controls.Clear();
            int maxPerRow = 4;
            int idx = 0;
            foreach (var r in recipes)
            {
                //Panel panel = MenuCard(r);
                MenuCard panel = new MenuCard(r, _cart, _cartPanel);
                flowLayoutMenu.Controls.Add(panel);
                idx++;
            }
        }

        /*private Panel MenuCard(Recipe r) // ubah ke MenuCard.cs
        {
            var panel = new Panel { Width = 150, Height = 200, Margin = new Padding(5) };
            var pb = new PictureBox { Width = 140, Height = 120, SizeMode = PictureBoxSizeMode.Zoom, Tag = r };
            if (!string.IsNullOrWhiteSpace(r.ImagePath) && System.IO.File.Exists(r.ImagePath))
                pb.Image = Image.FromFile(r.ImagePath);

            var lbl = new Label
            {
                Text = r.Code + "-" + r.Name,
                AutoSize = false,
                Width = 140,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblPrice = new Label
            {
                Text = "IDR " + r.Price.ToString(),
                AutoSize = false,
                Width = 140,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
            };

            var btn = new Button { Text = "Add To Cart", Width = 140, Height = 30, Tag = r };
            btn.Click += (s, e) => {
                ButtonAdd_Click(s, e);
            };
            lbl.Top = pb.Bottom;
            lblPrice.Top = lbl.Bottom;
            btn.Top = lblPrice.Bottom;
            panel.Controls.Add(pb);
            panel.Controls.Add(lbl);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(btn);

            return panel;
        } */

        /*private void AddSelectedMenuToCart()
        {
            if (flowLayoutMenu.Controls.Count == 0) return;
            if (flowLayoutMenu.Controls[0] is Panel p && p.Controls[0] is PictureBox pb && pb.Tag is Recipe r)
            {
                _cart.Add(new CartItem { RecipeId = r.IdReceipt, RecipeCode = r.Code, RecipeName = r.Name, Qty = 1, UnitPrice = r.Price ?? 0 });
                _cartPanel.RefreshCartGrid(_cart);
            }
        }*/

        private async Task LoadRecipesAsync()
        {
            var list = await _recipeRepo.GetAllAsync();
            RenderMenuThumbnails(list);
        }

        /*private async Task LoadMembersAsync()
        {
            var list = await _memberRepo.GetAllAsync();
            comboBoxMember.Items.Clear();
            comboBoxMember.Items.Add(new ComboItem(0, "Walk-in"));
            foreach (var m in list) {
                comboBoxMember.Items.Add(
                    new ComboItem(m.IdMember, m.FullName ?? m.Username));
            }
            comboBoxMember.SelectedIndex = 0;
        }*/

        private void NewTransaction_Click(object? sender, EventArgs e)
        {
            _cartPanel.RefreshCartGrid(_cart);
        }

        private async void Search_Click(object? sender, EventArgs e)
        {
            await SearchRecipesAsync(textBoxSearch.Text.Trim());
        }

        private void ButtonAdd_Click(object? s, EventArgs e)
        {
            /*if (comboBoxMember.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a member first.", "No Member Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            if (s is Button b && b.Tag is Recipe rr)
            {
                _cart.Add(new CartItem
                {
                    RecipeId = rr.IdReceipt,
                    RecipeCode = rr.Code,
                    RecipeName = rr.Name,
                    Qty = 1,
                    UnitPrice = rr.Price ?? 0
                });
                _cartPanel.RefreshCartGrid(_cart);
            }
        }

        private void buttonDesert_Click(object sender, EventArgs e)
        {

        }
    }
}
