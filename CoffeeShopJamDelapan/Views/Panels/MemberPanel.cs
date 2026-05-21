using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Repo;

namespace CoffeeShopJamDelapan.Views.Panels
{
    public partial class MemberPanel : UserControl
    {
        private readonly MemberRepo _repo = new();

        public MemberPanel()
        {
            InitializeComponent();

            button1.Click += New_Click;
            button2.Click += Submit_Click;
            button3.Click += Delete_Click;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;

            _ = LoadAllAsync();
        }

        private async void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            var phone = textBoxSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                await LoadAllAsync();
                return;
            }
            var list = await _repo.SearchByPhoneAsync(phone);
            dataGridView1.DataSource = list;
        }

        private void New_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private async void Submit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textUsername.Text))
            {
                MessageBox.Show("Username is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate email format if provided
            if (!string.IsNullOrWhiteSpace(textEmail.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(textEmail.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Invalid email format", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var member = new Member
            {
                Username = textUsername.Text.Trim(),
                Phone = textPhone.Text.Trim(),
                Email = textEmail.Text.Trim(),
                FullName = textFullName.Text.Trim(),
                LastUpdate = DateTime.Now
            };

            // check uniqueness for username and phone
            int.TryParse(textIdMember.Text, out var existingId);
            if (await _repo.ExistsByUsernameAsync(member.Username, existingId > 0 ? existingId : null))
            {
                MessageBox.Show("Username already exists", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(member.Phone) && await _repo.ExistsByPhoneAsync(member.Phone, existingId > 0 ? existingId : null))
            {
                MessageBox.Show("Phone already exists", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existingId > 0)
            {
                member.IdMember = existingId;
                var ok = await _repo.UpdateAsync(member);
                MessageBox.Show(ok ? "Member updated" : "Update failed");
            }
            else
            {
                member.Code = "M" + DateTime.Now.ToString("yyMMddHHmmss");
                var newId = await _repo.CreateAsync(member);
                MessageBox.Show($"Member created (id={newId})");
            }

            await LoadAllAsync();
            ClearForm();
        }

        private async void Delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            if (row.DataBoundItem is Member m)
            {
                var dr = MessageBox.Show($"Delete member {m.FullName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;
                var ok = await _repo.DeleteAsync(m.IdMember);
                if (ok) await LoadAllAsync();
            }
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            if (row.DataBoundItem is Member m)
            {
                textIdMember.Text = m.IdMember.ToString();
                textUsername.Text = m.Username ?? string.Empty;
                textPhone.Text = m.Phone ?? string.Empty;
                textEmail.Text = m.Email ?? string.Empty;
                textFullName.Text = m.FullName ?? string.Empty;
                textLastTransaction.Text = m.LastUpdate?.ToString() ?? string.Empty;
            }
        }

        private void ClearForm()
        {
            textIdMember.Text = string.Empty;
            textUsername.Text = string.Empty;
            textPhone.Text = string.Empty;
            textFullName.Text = string.Empty;
            textEmail.Text = string.Empty;
            textLastTransaction.Text = string.Empty;
            dataGridView1.ClearSelection();
        }

        private async Task LoadAllAsync()
        {
            var list = await _repo.GetAllAsync();
            dataGridView1.DataSource = list;
        }
    }
}
