using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShopJamDelapan.Models;
using MySqlConnector;
using System.Data;

namespace CoffeeShopJamDelapan.Repo
{
    public class TransactionRepo
    {
        public async Task<int> CreateAsync(Transaction t)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO `transaction` (id_member, code, n_menu, transaction_date, subtotal, id_discount, discount, tax_rate, tax, total, paid, `change`) 
VALUES (@id_member, @code, @n_menu, @transaction_date, @subtotal, @id_discount, @discount, @tax_rate, @tax, @total, @paid, @change); SELECT LAST_INSERT_ID();";
            cmd.Parameters.Add("@id_member", MySqlDbType.Int32).Value = t.IdMember;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 20).Value = t.Code;
            cmd.Parameters.Add("@n_menu", MySqlDbType.Int32).Value = t.NMenu;
            cmd.Parameters.Add("@transaction_date", MySqlDbType.DateTime).Value = (object?)t.TransactionDate ?? System.DBNull.Value;
            cmd.Parameters.Add("@subtotal", MySqlDbType.Double).Value = (object?)t.Subtotal ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_discount", MySqlDbType.Int32).Value = (object?)t.IdDiscount ?? System.DBNull.Value;
            cmd.Parameters.Add("@discount", MySqlDbType.Double).Value = (object?)t.Discount ?? System.DBNull.Value;
            cmd.Parameters.Add("@tax_rate", MySqlDbType.Double).Value = (object?)t.TaxRate ?? System.DBNull.Value;
            cmd.Parameters.Add("@tax", MySqlDbType.Double).Value = (object?)t.Tax ?? System.DBNull.Value;
            cmd.Parameters.Add("@total", MySqlDbType.Double).Value = (object?)t.Total ?? System.DBNull.Value;
            cmd.Parameters.Add("@paid", MySqlDbType.Double).Value = (object?)t.Paid ?? System.DBNull.Value;
            cmd.Parameters.Add("@change", MySqlDbType.Double).Value = (object?)t.Change ?? System.DBNull.Value;
            await cmd.PrepareAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_transaction, id_member, code, n_menu, transaction_date, subtotal, id_discount, discount, tax_rate, tax, total, paid, `change` FROM `transaction` WHERE id_transaction=@id LIMIT 1";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Transaction
                {
                    IdTransaction = reader.GetInt32("id_transaction"),
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    NMenu = reader.GetInt32("n_menu"),
                    TransactionDate = reader.IsDBNull("transaction_date") ? null : reader.GetDateTime("transaction_date"),
                    Subtotal = reader.IsDBNull("subtotal") ? null : reader.GetDouble("subtotal"),
                    IdDiscount = reader.IsDBNull("id_discount") ? null : reader.GetInt32("id_discount"),
                    Discount = reader.IsDBNull("discount") ? null : reader.GetDouble("discount"),
                    TaxRate = reader.IsDBNull("tax_rate") ? null : reader.GetDouble("tax_rate"),
                    Tax = reader.IsDBNull("tax") ? null : reader.GetDouble("tax"),
                    Total = reader.IsDBNull("total") ? null : reader.GetDouble("total"),
                    Paid = reader.IsDBNull("paid") ? null : reader.GetDouble("paid"),
                    Change = reader.IsDBNull("change") ? null : reader.GetDouble("change"),
                };
            }
            return null;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            var list = new List<Transaction>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_transaction, id_member, code, n_menu, transaction_date, subtotal, id_discount, discount, tax_rate, tax, total, paid, `change` FROM `transaction`";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Transaction
                {
                    IdTransaction = reader.GetInt32("id_transaction"),
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    NMenu = reader.GetInt32("n_menu"),
                    TransactionDate = reader.IsDBNull("transaction_date") ? null : reader.GetDateTime("transaction_date"),
                    Subtotal = reader.IsDBNull("subtotal") ? null : reader.GetDouble("subtotal"),
                    IdDiscount = reader.IsDBNull("id_discount") ? null : reader.GetInt32("id_discount"),
                    Discount = reader.IsDBNull("discount") ? null : reader.GetDouble("discount"),
                    TaxRate = reader.IsDBNull("tax_rate") ? null : reader.GetDouble("tax_rate"),
                    Tax = reader.IsDBNull("tax") ? null : reader.GetDouble("tax"),
                    Total = reader.IsDBNull("total") ? null : reader.GetDouble("total"),
                    Paid = reader.IsDBNull("paid") ? null : reader.GetDouble("paid"),
                    Change = reader.IsDBNull("change") ? null : reader.GetDouble("change"),
                });
            }
            return list;
        }

        public async Task<bool> UpdateAsync(Transaction t)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE `transaction` SET id_member=@id_member, code=@code, n_menu=@n_menu, transaction_date=@transaction_date, subtotal=@subtotal, id_discount=@id_discount, discount=@discount, tax_rate=@tax_rate, tax=@tax, total=@total, paid=@paid, `change`=@change WHERE id_transaction=@id";
            cmd.Parameters.Add("@id_member", MySqlDbType.Int32).Value = t.IdMember;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 20).Value = t.Code;
            cmd.Parameters.Add("@n_menu", MySqlDbType.Int32).Value = t.NMenu;
            cmd.Parameters.Add("@transaction_date", MySqlDbType.DateTime).Value = (object?)t.TransactionDate ?? System.DBNull.Value;
            cmd.Parameters.Add("@subtotal", MySqlDbType.Double).Value = (object?)t.Subtotal ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_discount", MySqlDbType.Int32).Value = (object?)t.IdDiscount ?? System.DBNull.Value;
            cmd.Parameters.Add("@discount", MySqlDbType.Double).Value = (object?)t.Discount ?? System.DBNull.Value;
            cmd.Parameters.Add("@tax_rate", MySqlDbType.Double).Value = (object?)t.TaxRate ?? System.DBNull.Value;
            cmd.Parameters.Add("@tax", MySqlDbType.Double).Value = (object?)t.Tax ?? System.DBNull.Value;
            cmd.Parameters.Add("@total", MySqlDbType.Double).Value = (object?)t.Total ?? System.DBNull.Value;
            cmd.Parameters.Add("@paid", MySqlDbType.Double).Value = (object?)t.Paid ?? System.DBNull.Value;
            cmd.Parameters.Add("@change", MySqlDbType.Double).Value = (object?)t.Change ?? System.DBNull.Value;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = t.IdTransaction;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `transaction` WHERE id_transaction=@id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }
    }
}
