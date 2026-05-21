using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class ItemPanel : UserControl
    {
        private readonly ItemRepo _repo = new();
        public ItemPanel()
        {
            InitializeComponent();
            _ = LoadAllAsync();
        }

        private async Task LoadAllAsync()
        {
            var list = await _repo.GetAllAsync();
            dgvItem.DataSource = list;
        }

        private void DgvItem_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0) return;

            var row = dgvItem.SelectedRows[0];
            if (row.DataBoundItem is Item itm)
            {
                textIdItem.Text = itm.IdItem.ToString();
                textTitle.Text = itm.Title ?? string.Empty;
                comboMeasurement.SelectedIndex = selectedMea(itm.Measurement ?? string.Empty);
                textQty.Text = itm.Quantity.ToString();
                textPrice.Text = itm.Price.ToString();
                textLastUpdate.Text = itm.LastUpdate?.ToString() ?? string.Empty;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            textIdItem.Text = string.Empty;
            textTitle.Text = string.Empty;
            comboMeasurement.SelectedIndex = -1;
            textQty.Text = string.Empty;
            textPrice.Text = string.Empty;
            textLastUpdate.Text = string.Empty;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            clearForm();
            await LoadAllAsync();
        }

        private async void textSearch_TextChanged(object sender, EventArgs e)
        {
            var titleSearch = textSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(titleSearch))
            {
                await LoadAllAsync();  // memunculkan semua daftar item
                return;
            }
            var list = await _repo.SearchByTitleAsync(titleSearch);
            dgvItem.DataSource = list;
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0) return;

            var row = dgvItem.SelectedRows[0];
            if (row.DataBoundItem is Item itm)
            {
                var dr = MessageBox.Show($"Delete item {itm.Title}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                var ok = await _repo.DeleteAsync(itm.IdItem);
                if (ok) await LoadAllAsync();
            }
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                MessageBox.Show("Title is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboMeasurement.Text))
            {
                MessageBox.Show("Measurement is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textQty.Text))
            {
                MessageBox.Show("Quantity is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (!int.TryParse(textQty.Text, out var qty) || qty < 0)
            {
                MessageBox.Show("Quantity must be a non-negative number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textPrice.Text))
            {
                MessageBox.Show("Price is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(textPrice.Text, out var price) || price < 0)
            {
                MessageBox.Show("Price must be a non-negative number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = new Item
            {
                Title = textTitle.Text.Trim(),
                Measurement = comboMeasurement.Text.Trim(),
                Quantity = int.Parse(textQty.Text),
                Price = int.Parse(textPrice.Text),
                LastUpdate = DateTime.Now
            };

            // check uniqueness for username and phone
            int.TryParse(textIdItem.Text, out var existingId);
            if (existingId > 0)
            {
                item.IdItem = existingId;
                var ok = await _repo.UpdateAsync(item);
                MessageBox.Show(ok ? "Item updated" : "Update failed");
            }
            else
            {
                item.Code = "I" + DateTime.Now.ToString("HHmmss");
                var newId = await _repo.CreateAsync(item);
                MessageBox.Show($"Item created (id={newId})");
            }

            await LoadAllAsync();
            clearForm();
        }

        private int selectedMea(string mea)
        {
            if (mea == "Grams") return 0;
            if (mea == "Mililitres") return 1;
            if (mea == "Pieces") return 2;

            return 0;
        }
    }
}
