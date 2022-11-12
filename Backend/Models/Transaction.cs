using System;
namespace VATHelper.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; } // Date of the Invoice
        public TransactionType TransactionType { get; set; } // Did I spend or get money?
        public string TransactionSecondParty { get; set; } = string.Empty; // Who was the customer/supplier
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public List<TransactionPosition> Positions { get; set; } = new();
    }
}

