using System;
namespace VATHelper.Models
{
    public class TransactionPosition
    {
        public string Description { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

