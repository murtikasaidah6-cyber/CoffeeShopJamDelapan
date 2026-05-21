using System;

namespace CoffeeShopJamDelapan.Models
{
    public class User // table
    {
        public int IdUser { get; set; } // column
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}
