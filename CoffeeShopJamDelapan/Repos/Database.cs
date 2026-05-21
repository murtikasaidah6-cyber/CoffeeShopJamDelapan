using MySqlConnector;
using System.Threading.Tasks;

namespace CoffeeShopJamDelapan.Repo
{ 
    public static class Database
    {
        // 8 - 14 tradisional
        public static string ConnectionStringOldStyle { get; set; } 
            = "Server=103.82.242.90;Port=3306;Database=db_coffee_shop_jam_delapan;Uid=exadash;Pwd=;";

        public static MySqlConnection GetConnectionOldStyle()
        {
            return new MySqlConnection(ConnectionStringOldStyle);
        }

        // connection pool
        private static MySqlConnectionStringBuilder DefaultBuilder => new()
        {
            Server = "localhost",
            Port = 3306,
            Database = "db_coffee_shop_jam_delapan",
            UserID = "root",
            Password = "12Qpalzmxn.",
            Pooling = true,
            MinimumPoolSize = 0,
            MaximumPoolSize = 100,
            ConnectionLifeTime = 0,
            ConnectionTimeout = 15
        };

        public static string? ConnectionString { get; set; }

        public static MySqlConnection GetConnection()
        {
            var cs = ConnectionString ?? DefaultBuilder.ConnectionString;
            return new MySqlConnection(cs);
        }

        public static async Task<MySqlConnection> GetOpenConnectionAsync()
        {
            var conn = GetConnection();
            await conn.OpenAsync();
            return conn;
        }
        
    }
}
