 using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShopJamDelapan.Models;
using MySqlConnector;
using System.Data;

namespace CoffeeShopJamDelapan.Repo
{
    public class TransactionDetailsRepo
    {
        public async Task<int> CreateAsync(TransactionDetails ti)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO transaction_details (id_transaction, id_recipe, quantity, price, total) 
                VALUES (@id_transaction,@id_recipe,@quantity,@price,@total); SELECT LAST_INSERT_ID();";
            cmd.Parameters.Add("@id_transaction", MySqlDbType.Int32).Value = ti.IdTransaction;
            cmd.Parameters.Add("@id_recipe", MySqlDbType.Int32).Value = ti.IdRecipe;
            cmd.Parameters.Add("@quantity", MySqlDbType.Double).Value = ti.Quantity;
            cmd.Parameters.Add("@price", MySqlDbType.Double).Value = ti.Price;
            cmd.Parameters.Add("@total", MySqlDbType.Double).Value = ti.Total;
            await cmd.PrepareAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task<List<TransactionDetails>> GetByTransactionIdAsync(int txId)
        {
            var list = new List<TransactionDetails>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_details, id_transaction, id_recipe, quantity, price, total " +
                "FROM transaction_details WHERE id_transaction=@tx";
            cmd.Parameters.Add("@tx", MySqlDbType.Int32).Value = txId;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new TransactionDetails
                {
                    IdDetails = reader.GetInt32("id_details"),
                    IdTransaction = reader.GetInt32("id_transaction"),
                    IdRecipe = reader.GetInt32("id_recipe"),
                    Quantity = reader.GetDouble("quantity"),
                    Price = reader.GetDouble("price"),
                    Total = reader.GetDouble("total")
                });
            }
            return list;
        }
    }
}
