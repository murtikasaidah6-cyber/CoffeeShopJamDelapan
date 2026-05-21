using System;

namespace CoffeeShopJamDelapan.Models
{
    public class Recipe
    {
        public int IdReceipt { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? IdItemA { get; set; }
        public int? IdItemB { get; set; }
        public int? IdItemC { get; set; }
        public int? IdItemD { get; set; }
        public double? QtyItemA { get; set; }
        public double? QtyItemB { get; set; }
        public double? QtyItemC { get; set; }
        public double? QtyItemD { get; set; }
        public string? RecipeInstruction { get; set; }
        public string? SavingInstruction { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? IsDeleted { get; set; }
        public string? ImagePath { get; set; }
        public double? Price { get; set; }
    }
}
