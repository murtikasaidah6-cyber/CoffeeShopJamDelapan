using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;
using CoffeeShopJamDelapan.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class HistoryPanel : UserControl
    {
        AdminForm _adminForm;
        private readonly TransactionRepo _txRepo = new();
        private readonly MemberRepo _memberRepo = new();

        public HistoryPanel(AdminForm adminForm)
        {
            InitializeComponent();
            _adminForm = adminForm;
            buttonFilter.Click += ButtonFilter_Click;

            _ = LoadTransactionAsync();

        }

        private  async void ButtonFilter_Click(object? sender, EventArgs e)
        {
            await LoadTransactionAsync(dtpStart.Value.Date, dtpEnd.Value.Date);
        }

        private async Task LoadTransactionAsync()
        {
            await LoadTransactionAsync(dtpStart.Value.Date.AddDays(-30), dtpEnd.Value.Date);

        }

        private async Task LoadTransactionAsync(DateTime strat, DateTime end)
        {
            List<Transaction> all = await _txRepo.GetAllFilterDateAsync(strat, end);
            var rows = new List<object>();
            foreach (Transaction tx in all)
            {
                if (!tx.TransactionDate.HasValue) continue;

                string memberName = "-";
                if (tx.IdMember != 0)
                {
                    var n = await _memberRepo.GetByIdAsync(tx.IdMember);
                    if (n != null) memberName = n.FullName ?? n.Username;
                }
                rows.Add(new
                {
                    IdTransaction = tx.IdTransaction,
                    Code = tx.Code,
                    Date = tx.TransactionDate?.ToString() ?? string.Empty,
                    Member = memberName,
                    Total = tx.Total ?? 0,
                    Paid = tx.Paid > 0 ? "Paid" : "Unpaid"

                });
            }
            dgvTransaction.DataSource = rows;

            if (dgvTransaction.Columns["IdTransaction"] != null) dgvTransaction.Columns["IdTransaction"].HeaderText = "ID";
            if (dgvTransaction.Columns["Code"] != null) dgvTransaction.Columns["Code"].HeaderText = "Code";
            if (dgvTransaction.Columns["Date"] != null) dgvTransaction.Columns["Date"].HeaderText = "Date";
            if (dgvTransaction.Columns["Member"] != null) dgvTransaction.Columns["Member"].HeaderText = "Member";
            if (dgvTransaction.Columns["Total"] != null) dgvTransaction.Columns["Total"].HeaderText = "Total";
            if (dgvTransaction.Columns["Paid"] != null) dgvTransaction.Columns["Paid"].HeaderText = "Paid";

            dgvTransaction.Columns["IdTransaction"].Visible = false;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (dgvTransaction.SelectedRows.Count == 0) return;
            var id = (int)dgvTransaction.SelectedRows[0].Cells["IdTransaction"].Value;
            _adminForm.showPaymentPanel(id);

        }

        }
      
    }

