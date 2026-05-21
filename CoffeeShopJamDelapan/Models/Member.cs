using System;

namespace CoffeeShopJamDelapan.Models
{
    public class Member
    {
        public int IdMember { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? IsDeleted { get; set; }
    }
}
