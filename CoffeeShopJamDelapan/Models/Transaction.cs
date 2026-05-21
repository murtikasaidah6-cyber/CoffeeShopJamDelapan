using System;

namespace CoffeeShopJamDelapan.Models
{
    public class Transaction
    {
        public int IdTransaction { get; set; }
        public int IdMember { get; set; }
        public string Code { get; set; } = string.Empty;
        public int NMenu { get; set; }
        public DateTime? TransactionDate { get; set; }
        public double? Subtotal { get; set; }
        public int? IdDiscount { get; set; }
        public double? Discount { get; set; }
        public double? TaxRate { get; set; }
        public double? Tax { get; set; }
        public double? Total { get; set; }
        public double? Paid { get; set; }
        public double? Change { get; set; }
    }
}
