using System;

namespace CoffeeShopJamDelapan.Models
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Measurement { get; set; }
        public double? Quantity { get; set; }
        public double? Price { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? IsDeleted { get; set; }
    }
}
