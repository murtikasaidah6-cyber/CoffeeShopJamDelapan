using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopJamDelapan.Models
{
    public class TransactionDetails
    {
        public int IdDetails { get; set; }
        public int IdTransaction { get; set; }
        public int IdRecipe { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
