using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShopJamDelapan.Models;
using MySqlConnector;
using System.Data;

namespace CoffeeShopJamDelapan.Repo
{
    public class RecipeRepo
    {
        public async Task<int> CreateAsync(Recipe r)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO recipe (code,name,type,id_item_a,id_item_b,id_item_c,id_item_d,qty_item_a,qty_item_b,qty_item_c,qty_item_d,recipe_instruction,
                saving_instruction,image_path,price,last_update,is_deleted)
                VALUES (@code,@name,@type,@id_item_a,@id_item_b,@id_item_c,@id_item_d,@qty_item_a,@qty_item_b,@qty_item_c,@qty_item_d,@recipe_instruction,
                @saving_instruction,@image_path,@price,@last_update,@is_deleted);
                SELECT LAST_INSERT_ID();";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 5).Value = r.Code;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 200).Value = (object?)r.Name ?? System.DBNull.Value;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar, 30).Value = (object?)r.Type ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_a", MySqlDbType.Int32).Value = (object?)r.IdItemA ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_b", MySqlDbType.Int32).Value = (object?)r.IdItemB ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_c", MySqlDbType.Int32).Value = (object?)r.IdItemC ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_d", MySqlDbType.Int32).Value = (object?)r.IdItemD ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_a", MySqlDbType.Double).Value = (object?)r.QtyItemA ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_b", MySqlDbType.Double).Value = (object?)r.QtyItemB ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_c", MySqlDbType.Double).Value = (object?)r.QtyItemC ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_d", MySqlDbType.Double).Value = (object?)r.QtyItemD ?? System.DBNull.Value;
            cmd.Parameters.Add("@recipe_instruction", MySqlDbType.VarChar, 1000).Value = (object?)r.RecipeInstruction ?? System.DBNull.Value;
            cmd.Parameters.Add("@saving_instruction", MySqlDbType.VarChar, 1000).Value = (object?)r.SavingInstruction ?? System.DBNull.Value;
            cmd.Parameters.Add("@image_path", MySqlDbType.VarChar, 500).Value = (object?)r.ImagePath ?? System.DBNull.Value;
            cmd.Parameters.Add("@price", MySqlDbType.Double).Value = (object?)r.Price ?? System.DBNull.Value;
            // optional price column if recipe stores price
            // cmd.Parameters.Add("@price", MySqlDbType.Double).Value = (object?)r.Price ?? System.DBNull.Value;
            cmd.Parameters.Add("@last_update", MySqlDbType.DateTime).Value = (object?)r.LastUpdate ?? System.DBNull.Value;
            cmd.Parameters.Add("@is_deleted", MySqlDbType.VarChar, 1).Value = (object?)r.IsDeleted ?? System.DBNull.Value;
            await cmd.PrepareAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_receipt, code, name, type, id_item_a, id_item_b, id_item_c, id_item_d, qty_item_a, qty_item_b, " +
                "qty_item_c, qty_item_d, recipe_instruction, saving_instruction, image_path, price, last_update, is_deleted " +
                "FROM recipe WHERE id_receipt=@id AND (is_deleted IS NULL OR is_deleted != '1') LIMIT 1";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Recipe
                {
                    IdReceipt = reader.GetInt32("id_receipt"),
                    Code = reader.GetString("code"),
                    Name = reader.IsDBNull("name") ? null : reader.GetString("name"),
                    Type = reader.IsDBNull("type") ? null : reader.GetString("type"),
                    IdItemA = reader.IsDBNull("id_item_a") ? null : reader.GetInt32("id_item_a"),
                    IdItemB = reader.IsDBNull("id_item_b") ? null : reader.GetInt32("id_item_b"),
                    IdItemC = reader.IsDBNull("id_item_c") ? null : reader.GetInt32("id_item_c"),
                    IdItemD = reader.IsDBNull("id_item_d") ? null : reader.GetInt32("id_item_d"),
                    QtyItemA = reader.IsDBNull("qty_item_a") ? null : reader.GetDouble("qty_item_a"),
                    QtyItemB = reader.IsDBNull("qty_item_b") ? null : reader.GetDouble("qty_item_b"),
                    QtyItemC = reader.IsDBNull("qty_item_c") ? null : reader.GetDouble("qty_item_c"),
                    QtyItemD = reader.IsDBNull("qty_item_d") ? null : reader.GetDouble("qty_item_d"),
                    RecipeInstruction = reader.IsDBNull("recipe_instruction") ? null : reader.GetString("recipe_instruction"),
                    SavingInstruction = reader.IsDBNull("saving_instruction") ? null : reader.GetString("saving_instruction"),
                    ImagePath = reader.IsDBNull("image_path") ? null : reader.GetString("image_path"),
                    Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                };
            }
            return null;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            var list = new List<Recipe>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_receipt, code, name, type, id_item_a, id_item_b, id_item_c, id_item_d, qty_item_a, qty_item_b, qty_item_c, qty_item_d, recipe_instruction, " +
                "saving_instruction, image_path, price, last_update, is_deleted FROM recipe WHERE (is_deleted IS NULL OR is_deleted != '1')";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Recipe
                {
                    IdReceipt = reader.GetInt32("id_receipt"),
                    Code = reader.GetString("code"),
                    Name = reader.IsDBNull("name") ? null : reader.GetString("name"),
                    Type = reader.IsDBNull("type") ? null : reader.GetString("type"),
                    IdItemA = reader.IsDBNull("id_item_a") ? null : reader.GetInt32("id_item_a"),
                    IdItemB = reader.IsDBNull("id_item_b") ? null : reader.GetInt32("id_item_b"),
                    IdItemC = reader.IsDBNull("id_item_c") ? null : reader.GetInt32("id_item_c"),
                    IdItemD = reader.IsDBNull("id_item_d") ? null : reader.GetInt32("id_item_d"),
                    QtyItemA = reader.IsDBNull("qty_item_a") ? null : reader.GetDouble("qty_item_a"),
                    QtyItemB = reader.IsDBNull("qty_item_b") ? null : reader.GetDouble("qty_item_b"),
                    QtyItemC = reader.IsDBNull("qty_item_c") ? null : reader.GetDouble("qty_item_c"),
                    QtyItemD = reader.IsDBNull("qty_item_d") ? null : reader.GetDouble("qty_item_d"),
                    RecipeInstruction = reader.IsDBNull("recipe_instruction") ? null : reader.GetString("recipe_instruction"),
                    SavingInstruction = reader.IsDBNull("saving_instruction") ? null : reader.GetString("saving_instruction"),
                    ImagePath = reader.IsDBNull("image_path") ? null : reader.GetString("image_path"),
                    Price = reader.IsDBNull("price") ? null : reader.GetDouble("price"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                });
            }
            return list;
        }

        public async Task<bool> UpdateAsync(Recipe r)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE recipe SET code=@code, name=@name, type=@type, id_item_a=@id_item_a, id_item_b=@id_item_b, id_item_c=@id_item_c, 
                id_item_d=@id_item_d, qty_item_a=@qty_item_a, qty_item_b=@qty_item_b, qty_item_c=@qty_item_c, qty_item_d=@qty_item_d, recipe_instruction=@recipe_instruction, 
                saving_instruction=@saving_instruction, image_path=@image_path, price=@price, last_update=@last_update, is_deleted=@is_deleted WHERE id_receipt=@id";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 5).Value = r.Code;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 200).Value = (object?)r.Name ?? System.DBNull.Value;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar, 30).Value = (object?)r.Type ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_a", MySqlDbType.Int32).Value = (object?)r.IdItemA ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_b", MySqlDbType.Int32).Value = (object?)r.IdItemB ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_c", MySqlDbType.Int32).Value = (object?)r.IdItemC ?? System.DBNull.Value;
            cmd.Parameters.Add("@id_item_d", MySqlDbType.Int32).Value = (object?)r.IdItemD ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_a", MySqlDbType.Double).Value = (object?)r.QtyItemA ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_b", MySqlDbType.Double).Value = (object?)r.QtyItemB ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_c", MySqlDbType.Double).Value = (object?)r.QtyItemC ?? System.DBNull.Value;
            cmd.Parameters.Add("@qty_item_d", MySqlDbType.Double).Value = (object?)r.QtyItemD ?? System.DBNull.Value;
            cmd.Parameters.Add("@recipe_instruction", MySqlDbType.VarChar, 1000).Value = (object?)r.RecipeInstruction ?? System.DBNull.Value;
            cmd.Parameters.Add("@saving_instruction", MySqlDbType.VarChar, 1000).Value = (object?)r.SavingInstruction ?? System.DBNull.Value;
            cmd.Parameters.Add("@image_path", MySqlDbType.VarChar, 500).Value = (object?)r.ImagePath ?? System.DBNull.Value;
            cmd.Parameters.Add("@price", MySqlDbType.Double).Value = (object?)r.Price ?? System.DBNull.Value;
            cmd.Parameters.Add("@last_update", MySqlDbType.DateTime).Value = (object?)r.LastUpdate ?? System.DBNull.Value;
            cmd.Parameters.Add("@is_deleted", MySqlDbType.VarChar, 1).Value = (object?)r.IsDeleted ?? System.DBNull.Value;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = r.IdReceipt;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE recipe SET is_deleted='1' WHERE id_receipt=@id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }
    }
}
