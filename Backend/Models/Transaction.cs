using System;
using VATHelper.Extensions;

namespace VATHelper.Models
{
    public class Transaction
    {
        public const decimal TaxRate = (decimal)0.19;
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } // Date of the Invoice
        public TransactionType TransactionType { get; set; } // Did I spend or get money?
        public string TransactionSecondParty { get; set; } = string.Empty; // Who was the customer/supplier
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public List<TransactionPosition> Positions { get; set; } = new();

        public static Transaction FromPositions(DateTime transactionDate, TransactionType transactionType,
            string transactionSecondParty, List<TransactionPosition> transactionPositions)
        {
            return new Transaction()
            {
                Date = transactionDate,
                TransactionType = transactionType,
                TransactionSecondParty = transactionSecondParty,
                NetValue = transactionPositions.GetNetSum(),
                GrossValue = transactionPositions.GetNetSum().NetToGross(),
                Positions = transactionPositions
            };
        }
    }
}

