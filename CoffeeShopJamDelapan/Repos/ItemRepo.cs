using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CoffeeShopJamDelapan.Models;
using MySqlConnector;

namespace CoffeeShopJamDelapan.Repo
{
    public class ItemRepo
    {
        public async Task<int> CreateAsync(Item item)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO item_stock (code,title,measurement,quantity,last_update,is_deleted) VALUES (@code,@title,@measurement,@quantity,@last_update,@is_deleted); SELECT LAST_INSERT_ID();";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 8).Value = item.Code;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 200).Value = (object?)item.Title ?? System.DBNull.Value;
            cmd.Parameters.Add("@measurement", MySqlDbType.VarChar, 100).Value = (object?)item.Measurement ?? System.DBNull.Value;
            cmd.Parameters.Add("@quantity", MySqlDbType.Double).Value = (object?)item.Quantity ?? System.DBNull.Value;
            cmd.Parameters.Add("@last_update", MySqlDbType.DateTime).Value = (object?)item.LastUpdate ?? System.DBNull.Value;
            cmd.Parameters.Add("@is_deleted", MySqlDbType.VarChar, 1).Value = (object?)item.IsDeleted ?? System.DBNull.Value;
            await cmd.PrepareAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_item, code, title, measurement, quantity, price, last_update, is_deleted FROM item_stock WHERE id_item=@id AND (is_deleted IS NULL OR is_deleted != '1') LIMIT 1";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Item
                {
                    IdItem = reader.GetInt32("id_item"),
                    Code = reader.GetString("code"),
                    Title = reader.IsDBNull("title") ? null : reader.GetString("title"),
                    Measurement = reader.IsDBNull("measurement") ? null : reader.GetString("measurement"),
                    Quantity = reader.IsDBNull("quantity") ? null : reader.GetDouble("quantity"),
                    Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                };
            }
            return null;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            var list = new List<Item>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_item, code, title, measurement, quantity, price, last_update, is_deleted FROM item_stock WHERE (is_deleted IS NULL OR is_deleted != '1')";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Item
                {
                    IdItem = reader.GetInt32("id_item"),
                    Code = reader.GetString("code"),
                    Title = reader.IsDBNull("title") ? null : reader.GetString("title"),
                    Measurement = reader.IsDBNull("measurement") ? null : reader.GetString("measurement"),
                    Quantity = reader.IsDBNull("quantity") ? null : reader.GetDouble("quantity"),
                    Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                });
            }
            return list;
        }

        public async Task<List<Item>> SearchByTitleAsync(string title)
        {
            var list = new List<Item>(); // collection( bentuk data enhancement dari array)
            //var arrayList = new String { "a", "c", "f" };
            //MappingType = KeyEventArgs dan value;
            //mapList = new Map<Object, Object>;
            //dictionary di python
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_item, code, title, measurement, quantity, price, last_update, is_deleted " +
                "FROM item_stock WHERE (is_deleted IS NULL OR is_deleted != '1')" +
                "and title LIKE @title";
            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 200).Value = $"%{title}%";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Item
                {
                    IdItem = reader.GetInt32("id_item"),
                    Code = reader.GetString("code"),
                    Title = reader.IsDBNull("title") ? null : reader.GetString("title"),
                    Measurement = reader.IsDBNull("measurement") ? null : reader.GetString("measurement"),
                    Quantity = reader.IsDBNull("quantity") ? null : reader.GetDouble("quantity"),
                    Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                });
            }
            return list;
        }

        public async Task<bool> UpdateAsync(Item item)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE item_stock SET code=@code, title=@title, measurement=@measurement, quantity=@quantity, last_update=@last_update, is_deleted=@is_deleted WHERE id_item=@id";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 8).Value = item.Code;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 200).Value = (object?)item.Title ?? System.DBNull.Value;
            cmd.Parameters.Add("@measurement", MySqlDbType.VarChar, 100).Value = (object?)item.Measurement ?? System.DBNull.Value;
            cmd.Parameters.Add("@quantity", MySqlDbType.Double).Value = (object?)item.Quantity ?? System.DBNull.Value;
            cmd.Parameters.Add("@last_update", MySqlDbType.DateTime).Value = (object?)item.LastUpdate ?? System.DBNull.Value;
            cmd.Parameters.Add("@is_deleted", MySqlDbType.VarChar, 1).Value = (object?)item.IsDeleted ?? System.DBNull.Value;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = item.IdItem;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE item_stock SET is_deleted='1' WHERE id_item=@id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }
    }
}
