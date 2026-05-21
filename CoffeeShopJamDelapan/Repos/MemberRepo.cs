using CoffeeShopJamDelapan.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CoffeeShopJamDelapan.Repo
{
    public class MemberRepo
    {
        public async Task<int> CreateAsync (Member member)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO member (code,full_name,phone,email,username,password,last_update,is_deleted) VALUES (@code,@full_name,@phone,@email,@username,@password,@last_update,@is_deleted); SELECT LAST_INSERT_ID();";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 20).Value = member.Code;
            cmd.Parameters.Add("@full_name", MySqlDbType.VarChar, 100).Value = (object?)member.FullName ?? System.DBNull.Value;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 16).Value = (object?)member.Phone ?? System.DBNull.Value;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 200).Value = (object?)member.Email ?? System.DBNull.Value;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = member.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar, 400).Value = (object?)member.Password ?? System.DBNull.Value;
            cmd.Parameters.Add("@last_update", MySqlDbType.DateTime).Value = (object?)member.LastUpdate ?? System.DBNull.Value;
            cmd.Parameters.Add("@is_deleted", MySqlDbType.VarChar, 1).Value = (object?)member.IsDeleted ?? System.DBNull.Value;
            await cmd.PrepareAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task<List<Member>> SearchByPhoneAsync(string phone)
        {
            var list = new List<Member>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_member, code, full_name, phone, email, username, password, last_update, is_deleted FROM member WHERE (is_deleted IS NULL OR is_deleted != '1') AND phone LIKE @phone";
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 50).Value = "%" + phone + "%";
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Member
                {
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    FullName = reader.IsDBNull("full_name") ? null : reader.GetString("full_name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.IsDBNull("username") ? null : reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                });
            }
            return list;
        }

        // prepared statement dengan parameter untuk mencegah SQL injection
        // statement biasa langung menyisipkan nilai ke dalam query string, raw SQL, rentan terhadap SQL injection

        public async Task<Member?> GetByIdAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_member, code, full_name, phone, email, username, password, last_update, is_deleted FROM member WHERE id_member=@id AND (is_deleted IS NULL OR is_deleted != '1') LIMIT 1";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Member
                {
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    FullName = reader.IsDBNull("full_name") ? null : reader.GetString("full_name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                };
            }
            return null;
        }

        public async Task<List<Member>> GetAllAsync()
        {
            var list = new List<Member>();
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_member, code, full_name, phone, email, username, password, last_update, is_deleted FROM member WHERE (is_deleted IS NULL OR is_deleted != '1')";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Member
                {
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    FullName = reader.IsDBNull("full_name") ? null : reader.GetString("full_name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                });
            }
            return list;
        }


        
        public async Task<bool> UpdateAsync(Member member)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE member SET code=@code, full_name=@full_name, phone=@phone, email=@email, username=@username, password=@password, last_update=@last_update, is_deleted=@is_deleted WHERE id_member=@id";
            cmd.Parameters.Add("@code", MySqlDbType.VarChar, 20).Value = member.Code;
            cmd.Parameters.Add("@full_name", MySqlDbType.VarChar, 100).Value = (object?)member.FullName ?? System.DBNull.Value;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 16).Value = (object?)member.Phone ?? System.DBNull.Value;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 200).Value = (object?)member.Email ?? System.DBNull.Value;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = member.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar, 400).Value = (object?)member.Password ?? System.DBNull.Value;
            cmd.Parameters.Add("@last_update", MySqlDbType.DateTime).Value = (object?)member.LastUpdate ?? System.DBNull.Value;
            cmd.Parameters.Add("@is_deleted", MySqlDbType.VarChar, 1).Value = (object?)member.IsDeleted ?? System.DBNull.Value;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = member.IdMember;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE member SET is_deleted='1' WHERE id_member=@id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            await cmd.PrepareAsync();
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }

        public async Task<bool> ExistsByUsernameAsync(string username, int? excludeId = null)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            if (excludeId.HasValue)
            {
                cmd.CommandText = "SELECT COUNT(1) FROM member WHERE username=@username AND id_member<>@exclude AND (is_deleted IS NULL OR is_deleted != '1')";
                cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = username;
                cmd.Parameters.Add("@exclude", MySqlDbType.Int32).Value = excludeId.Value;
            }
            else
            {
                cmd.CommandText = "SELECT COUNT(1) FROM member WHERE username=@username AND (is_deleted IS NULL OR is_deleted != '1')";
                cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = username;
            }
            await cmd.PrepareAsync();
            var obj = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(obj) > 0;
        }

        public async Task<Member?> GetByUsernameAsync(string username)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_member, code, full_name, phone, email, username, password, last_update, is_deleted FROM member WHERE username=@username AND (is_deleted IS NULL OR is_deleted != '1') LIMIT 1";
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 100).Value = username;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Member
                {
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    FullName = reader.IsDBNull("full_name") ? null : reader.GetString("full_name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.IsDBNull("username") ? null : reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                };
            }
            return null;
        }

        public async Task<bool> ExistsByPhoneAsync(string phone, int? excludeId = null)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            if (excludeId.HasValue)
            {
                cmd.CommandText = "SELECT COUNT(1) FROM member WHERE phone=@phone AND id_member<>@exclude AND (is_deleted IS NULL OR is_deleted != '1')";
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 16).Value = phone;
                cmd.Parameters.Add("@exclude", MySqlDbType.Int32).Value = excludeId.Value;
            }
            else
            {
                cmd.CommandText = "SELECT COUNT(1) FROM member WHERE phone=@phone AND (is_deleted IS NULL OR is_deleted != '1')";
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 16).Value = phone;
            }
            await cmd.PrepareAsync();
            var obj = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(obj) > 0;
        }

        public async Task<Member?> ExistsByEmailAsync(string email, int? excludeId = null)
        {
            await using var conn = await Database.GetOpenConnectionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_member, code, full_name, phone, email, username, password, last_update, is_deleted " +
                "FROM member WHERE email=@email AND (is_deleted IS NULL OR is_deleted != '1') LIMIT 1";
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 200).Value = email;
            await cmd.PrepareAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())  // true jika ada data, false jika tidak ada data
            {
                return new Member
                {
                    IdMember = reader.GetInt32("id_member"),
                    Code = reader.GetString("code"),
                    FullName = reader.IsDBNull("full_name") ? null : reader.GetString("full_name"),
                    Phone = reader.IsDBNull("phone") ? null : reader.GetString("phone"),
                    Email = reader.IsDBNull("email") ? null : reader.GetString("email"),
                    Username = reader.IsDBNull("username") ? null : reader.GetString("username"),
                    Password = reader.IsDBNull("password") ? null : reader.GetString("password"),
                    LastUpdate = reader.IsDBNull("last_update") ? null : reader.GetDateTime("last_update"),
                    IsDeleted = reader.IsDBNull("is_deleted") ? null : reader.GetString("is_deleted"),
                };
            }
            return null;
        }
    }
}
