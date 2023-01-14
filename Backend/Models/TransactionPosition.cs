using System;
using System.ComponentModel.DataAnnotations;

namespace VATHelper.Models
{
    public class TransactionPosition
    {
        [Key] public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; } // Hetzner eg has really precise measurement in the invoice
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
        
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        
    }
}

