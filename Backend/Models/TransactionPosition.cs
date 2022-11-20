using System;
namespace VATHelper.Models
{
    public class TransactionPosition
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; } // Hetzner eg has really precise measurement in the invoice
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
        
    }
}

