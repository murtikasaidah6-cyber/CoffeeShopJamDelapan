namespace CoffeeShopJamDelapan.Models
{
    public class CartItem
    {
        public int RecipeId { get; set; }
        public string? RecipeCode { get; set; }
        public string? RecipeName { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal => Qty * UnitPrice;
    }
}
