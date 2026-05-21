using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CoffeeShopJamDelapan.Models;
using MySqlConnector;

namespace CoffeeShopJamDelapan.Repo
{
    public class UserRepo
    {
        public async Task<int> CreateAsync(User user)
        {
            using var conn = Database.GetConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `user` (`code`,`name`,`phone`,`email`,`username`,`password`) VALUES (@code,@name,@phone,@email,@username,@password); SELECT LAST_INSERT_ID();";
            cmd.Parameters.AddWithValue("@code", user.Code);
            cmd.Parameters.AddWithValue("@name", (object?)user.Name ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object?)user.Phone ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object?)user.Email ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", (object?)user.Password ?? System.DBNull.Value);

            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task<int> CreateAsyncPrepared(User user)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO `user` (`code`,`name`,`phone`,`email`,`username`,`password`) VALUES (@code,@name,@phone,@email,@username,@password); SELECT LAST_INSERT_ID();";

            // define parameters with explicit MySql types and sizes (better than AddWithValue)
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 8).Value = user.Code;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 200).Value = (object?)user.Name ?? System.DBNull.Value;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 16).Value = (object?)user.Phone ?? System.DBNull.Value;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 200).Value = (object?)user.Email ?? System.DBNull.Value;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = user.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar, 400).Value = (object?)user.Password ?? System.DBNull.Value;

            // prepare on server (useful if executing same statement multiple times)
            await cmd.PrepareAsync();

            var idObj = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(idObj);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_user, code, name, phone, email, username, password FROM `user` WHERE id_user = @id AND (is_deleted IS NULL OR is_deleted != '1') LIMIT 1";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    IdUser = reader.GetInt32("id_user"),
                    Code = reader.GetString("code"),
                    Name = reader.IsDBNull("name") ? null : reader.GetString("name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                };
            }
            return null;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var list = new List<User>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_user, code, name, phone, email, username, password FROM `user` WHERE (is_deleted IS NULL OR is_deleted != '1')";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new User
                {
                    IdUser = reader.GetInt32("id_user"),
                    Code = reader.GetString("code"),
                    Name = reader.IsDBNull("name") ? null : reader.GetString("name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                });
            }
            return list;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `user` SET code=@code, name=@name, phone=@phone, email=@email, username=@username, password=@password WHERE id_user=@id";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 8).Value = user.Code;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 200).Value = (object?)user.Name ?? System.DBNull.Value;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 16).Value = (object?)user.Phone ?? System.DBNull.Value;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 200).Value = (object?)user.Email ?? System.DBNull.Value;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = user.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar, 400).Value = (object?)user.Password ?? System.DBNull.Value;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = user.IdUser;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE `user` SET is_deleted='1' WHERE id_user=@id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }
    }
}
