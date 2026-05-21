using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class RecipePanel : UserControl
    {

        private readonly RecipeRepo _repo = new();

        public RecipePanel()
        {
            InitializeComponent();

            // wire events
            button1.Click += ClearForm;
            button2.Click += ViewAll;
            button3.Click += SubmitAsync;
            button4.Click += DeleteSelectedAsync;
            dgvRecipes.SelectionChanged += DgvRecipes_SelectionChanged;
            buttonImageBrowse.Click += ButtonImageBrowse_Click;
            buttonImageClear.Click += ButtonImageClear_Click;

            // load data
            _ = LoadTypesAndIngredientsAsync();
            _ = LoadAllAsync();
        }

        private async Task<bool> ConfirmStockOkAsync(Recipe r)
        {
            var itemRepo = new ItemRepo();
            var check = new List<string>();

            async Task CheckOne(int? id, double need, string label)
            {
                if (!id.HasValue) return;
                var it = await itemRepo.GetByIdAsync(id.Value);
                var stock = it?.Quantity ?? 0;
                if (stock < need)
                {
                    check.Add($"{label}: need {need}, stock {stock}");
                }
            }

            await CheckOne(r.IdItemA, r.QtyItemA ?? 0, "Ingredient A");
            await CheckOne(r.IdItemB, r.QtyItemB ?? 0, "Ingredient B");
            await CheckOne(r.IdItemC, r.QtyItemC ?? 0, "Ingredient C");
            await CheckOne(r.IdItemD, r.QtyItemD ?? 0, "Ingredient D");

            if (check.Count == 0) return true;

            var msg = "Insufficient stock:\n" + string.Join("\n", check) + "\nContinue anyway?";
            return MessageBox.Show(msg, "Stock Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        private class RecipeGridItem
        {
            public int IdReceipt { get; set; }
            public string? Code { get; set; }
            public string? Title { get; set; }
            public string? Type { get; set; }

            public string? IngredientA { get; set; }
            public double QtyA { get; set; }
            public double StockA { get; set; }

            public string? IngredientB { get; set; }
            public double QtyB { get; set; }
            public double StockB { get; set; }

            public string? IngredientC { get; set; }
            public double QtyC { get; set; }
            public double StockC { get; set; }

            public string? IngredientD { get; set; }
            public double QtyD { get; set; }
            public double StockD { get; set; }

            public System.DateTime? LastUpdate { get; set; }
            public string? IsDeleted { get; set; }
        }

        private async Task LoadTypesAndIngredientsAsync()
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(new[] { "coffee", "non-coffee", "appetizer", "main-course", "dessert" });
            comboBoxType.SelectedIndex = 0;

            var itemRepo = new ItemRepo();
            var items = await itemRepo.GetAllAsync();

            void FillCombo(ComboBox cb)
            {
                cb.Items.Clear();
                cb.DisplayMember = "Text";
                cb.ValueMember = "Value";
                cb.Items.Add(new ComboItem(0, "(none)"));
                foreach (var it in items) cb.Items.Add(new ComboItem(it.IdItem, it.Title ?? it.Code));
                cb.SelectedIndex = 0;
            }

            FillCombo(comboBoxA);
            FillCombo(comboBoxB);
            FillCombo(comboBoxC);
            FillCombo(comboBoxD);
        }

        private async void ViewAll(object? sender, EventArgs e)
        {
            await LoadAllAsync();
        }

        private void ClearForm(object? sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBoxPrice.Text = string.Empty;
            comboBoxType.SelectedIndex = 0;
            comboBoxA.SelectedIndex = 0;
            comboBoxB.SelectedIndex = 0;
            comboBoxC.SelectedIndex = 0;
            comboBoxD.SelectedIndex = 0;
            dgvRecipes.ClearSelection();
        }

        private async void SubmitAsync(object? sender, EventArgs e)
        {
            try
            {
                int? selectedId = null;
                if (dgvRecipes.SelectedRows.Count > 0)
                {
                    selectedId = dgvRecipes.SelectedRows[0].Cells[1].Value as int?;
                }

                var r = new Recipe();
                if (selectedId.HasValue)
                    r.IdReceipt = selectedId.Value;

                r.Code = GenerateCode();
                r.Name = textBox3.Text.Trim();
                r.Type = comboBoxType.SelectedItem?.ToString();
                r.Price   = Double.Parse(textBoxPrice.Text.Trim());

                int? GetSelectedId(ComboBox cb)
                {
                    if (cb.SelectedIndex <= 0) return null;
                    return cb.SelectedItem is ComboItem ci ? ci.Id : null;
                }

                r.IdItemA = GetSelectedId(comboBoxA);
                r.IdItemB = GetSelectedId(comboBoxB);
                r.IdItemC = GetSelectedId(comboBoxC);
                r.IdItemD = GetSelectedId(comboBoxD);

                r.QtyItemA = (double)numericUpDown2.Value;
                r.QtyItemB = (double)numericUpDown3.Value;
                r.QtyItemC = (double)numericUpDown4.Value;
                r.QtyItemD = (double)numericUpDown5.Value;

                r.RecipeInstruction = textBox1.Text.Trim();
                r.SavingInstruction = textBox2.Text.Trim();
                r.LastUpdate = DateTime.Now;

                if (pictureBoxImage.Tag is byte[] imgBytes)
                {
                    var imagesDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "recipes");
                    System.IO.Directory.CreateDirectory(imagesDir);

                    var fname = $"recipe_{DateTime.Now:yyyyMMddHHmmss}_{new Random().Next(1000, 9999)}.jpg";
                    var fpath = System.IO.Path.Combine(imagesDir, fname);

                    using var inMs = new System.IO.MemoryStream(imgBytes);
                    using var img = Image.FromStream(inMs);
                    var resized = ResizeImage(img, 800, 800);
                    resized.Save(fpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    resized.Dispose();
                    r.ImagePath = fpath;
                }

                var proceed = await ConfirmStockOkAsync(r);
                if (!proceed)
                {
                    return;
                }

                if (selectedId.HasValue && selectedId.Value > 0)
                {
                    var ok = await _repo.UpdateAsync(r);
                    MessageBox.Show(ok ? "Updated" : "Update failed");
                }
                else
                {
                    var id = await _repo.CreateAsync(r);
                    MessageBox.Show($"Saved recipe id={id}");
                }

                await LoadAllAsync();
                ClearForm(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void DeleteSelectedAsync(object? sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count == 0) return;
            var id = (int)dgvRecipes.SelectedRows[0].Cells["IdReceipt"].Value;
            var ok = MessageBox.Show("Delete selected?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (!ok) return;
            var success = await _repo.DeleteAsync(id);
            if (success) await LoadAllAsync();
        }

        private async void DgvRecipes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count == 0) return;
            var id = (int)dgvRecipes.SelectedRows[0].Cells["IdReceipt"].Value;
            var r = await _repo.GetByIdAsync(id);
            if (r == null) return;
            textBox3.Text = r.Name ?? string.Empty;
            textBox1.Text = r.RecipeInstruction ?? string.Empty;
            textBox2.Text = r.SavingInstruction ?? string.Empty;
            textBoxPrice.Text = r.Price.ToString() ?? string.Empty;
            SelectComboTypeById(comboBoxType, r.Type != null ? comboBoxType.Items.IndexOf(r.Type) : (int?)null);
            SelectComboById(comboBoxA, r.IdItemA);
            SelectComboById(comboBoxB, r.IdItemB);
            SelectComboById(comboBoxC, r.IdItemC);
            SelectComboById(comboBoxD, r.IdItemD);

            numericUpDown2.Value = (decimal)(r.QtyItemA ?? 0);
            numericUpDown3.Value = (decimal)(r.QtyItemB ?? 0);
            numericUpDown4.Value = (decimal)(r.QtyItemC ?? 0);
            numericUpDown5.Value = (decimal)(r.QtyItemD ?? 0);

            // load image ke pictureBox dari path, dan simpan path di Tag
            if (!string.IsNullOrWhiteSpace(r.ImagePath) && System.IO.File.Exists(r.ImagePath))
            {
                try
                {
                    pictureBoxImage.Image = Image.FromFile(r.ImagePath);
                    pictureBoxImage.Tag = r.ImagePath;
                }
                catch
                {
                    pictureBoxImage.Image = null;
                    pictureBoxImage.Tag = null;
                }
            }
            else
            {
                pictureBoxImage.Image = null;
                pictureBoxImage.Tag = null;
            }
        }

        private void ButtonImageClear_Click(object? sender, EventArgs e)
        {
            pictureBoxImage.Image = null;
            pictureBoxImage.Tag = null;
        }

        private void ButtonImageBrowse_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var bytes = System.IO.File.ReadAllBytes(ofd.FileName);
            using var ms = new System.IO.MemoryStream(bytes);
            pictureBoxImage.Image = Image.FromStream(ms);
            pictureBoxImage.Tag = bytes;
        }

        private void SelectComboById(ComboBox cb, int? id)
        {
            if (id == null)
            {
                cb.SelectedIndex = 0;
                return;
            }
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (cb.Items[i] is ComboItem ci && ci.Id == id)
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
            cb.SelectedIndex = 0;
        }

        private void SelectComboTypeById(ComboBox cb, int? id)
        {
            if (id == null)
            {
                cb.SelectedIndex = 0;
                return;
            }
            else
            {
                cb.SelectedIndex = (int)id;
            }

            return;

        }

        private async Task LoadAllAsync()
        {
            List<Recipe> list = await _repo.GetAllAsync(); // data recipe (transaksi)

            var itemRepo = new ItemRepo();
            List<Item> items = await itemRepo.GetAllAsync(); // data item dan stocknya (master)
            var itemDict = new Dictionary<int, Item>();
            foreach (var barang in items) itemDict[barang.IdItem] = barang; // perulangan

            var rows = new List<RecipeGridItem>();
            foreach (var r in list)
            {
                string ia = r.IdItemA.HasValue && itemDict.TryGetValue(r.IdItemA.Value, out var a) ? (a.Title ?? a.Code) : string.Empty;
                string ib = r.IdItemB.HasValue && itemDict.TryGetValue(r.IdItemB.Value, out var b) ? (b.Title ?? b.Code) : string.Empty;
                string ic = r.IdItemC.HasValue && itemDict.TryGetValue(r.IdItemC.Value, out var c) ? (c.Title ?? c.Code) : string.Empty;
                string id = r.IdItemD.HasValue && itemDict.TryGetValue(r.IdItemD.Value, out var d) ? (d.Title ?? d.Code) : string.Empty;

                double stockA = r.IdItemA.HasValue && itemDict.TryGetValue(r.IdItemA.Value, out var sa) ? (sa.Quantity ?? 0) : 0;
                double stockB = r.IdItemB.HasValue && itemDict.TryGetValue(r.IdItemB.Value, out var sb) ? (sb.Quantity ?? 0) : 0;
                double stockC = r.IdItemC.HasValue && itemDict.TryGetValue(r.IdItemC.Value, out var sc) ? (sc.Quantity ?? 0) : 0;
                double stockD = r.IdItemD.HasValue && itemDict.TryGetValue(r.IdItemD.Value, out var sd) ? (sd.Quantity ?? 0) : 0;

                rows.Add(new RecipeGridItem
                {
                    IdReceipt = r.IdReceipt,
                    Code = r.Code,
                    Title = r.Name,
                    Type = r.Type,
                    IngredientA = ia,
                    QtyA = r.QtyItemA ?? 0,
                    StockA = stockA,
                    IngredientB = ib,
                    QtyB = r.QtyItemB ?? 0,
                    StockB = stockB,
                    IngredientC = ic,
                    QtyC = r.QtyItemC ?? 0,
                    StockC = stockC,
                    IngredientD = id,
                    QtyD = r.QtyItemD ?? 0,
                    StockD = stockD,
                    LastUpdate = r.LastUpdate,
                    IsDeleted = r.IsDeleted
                });
            }

            dgvRecipes.DataSource = rows;


            if (dgvRecipes.Columns["Thumbnail"] == null)
            {
                var imgCol = new DataGridViewImageColumn();
                imgCol.Name = "Thumbnail";
                imgCol.HeaderText = "Img";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvRecipes.Columns.Insert(0, imgCol);
            }

            for (int i = 0; i < rows.Count; i++)
            {
                var r = list[i];
                if (!string.IsNullOrWhiteSpace(r.ImagePath) && System.IO.File.Exists(r.ImagePath))
                {
                    using var fs = System.IO.File.OpenRead(r.ImagePath);
                    var img = Image.FromStream(fs);
                    dgvRecipes.Rows[i].Cells["Thumbnail"].Value = img.GetThumbnailImage(64, 64, null, IntPtr.Zero);
                }
                else
                {
                    dgvRecipes.Rows[i].Cells["Thumbnail"].Value = null;
                }
            }

            void SetHeader(string col, string header)
            {
                if (dgvRecipes.Columns[col] != null) dgvRecipes.Columns[col].HeaderText = header;
            }

            SetHeader("Code", "Code");
            SetHeader("Title", "Title");
            SetHeader("Type", "Type");
            SetHeader("IngredientA", "Ingredient A"); SetHeader("QtyA", "Qty A"); SetHeader("StockA", "Stock A");
            SetHeader("IngredientB", "Ingredient B"); SetHeader("QtyB", "Qty B"); SetHeader("StockB", "Stock B");
            SetHeader("IngredientC", "Ingredient C"); SetHeader("QtyC", "Qty C"); SetHeader("StockC", "Stock C");
            SetHeader("IngredientD", "Ingredient D"); SetHeader("QtyD", "Qty D"); SetHeader("StockD", "Stock D");

            if (dgvRecipes.Columns["IsDeleted"] != null) dgvRecipes.Columns["IsDeleted"].Visible = false;
            if (dgvRecipes.Columns["LastUpdate"] != null) dgvRecipes.Columns["LastUpdate"].Visible = false;
        }

        private string GenerateCode()
        {
            //return "R" + DateTime.Now.ToString("yyMMddHHmmss");
            var rnd = new Random().Next(1000, 9999).ToString();
            return "R" + rnd;
        }

        private Image ResizeImage(Image src, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / src.Width;
            var ratioY = (double)maxHeight / src.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newW = (int)(src.Width * ratio);
            var newH = (int)(src.Height * ratio);
            var bmp = new Bitmap(newW, newH);
            using var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(src, 0, 0, newW, newH);
            return bmp;
        }
    }
}
