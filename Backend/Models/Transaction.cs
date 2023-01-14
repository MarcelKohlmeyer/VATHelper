using System;
using System.ComponentModel.DataAnnotations;
using VATHelper.Extensions;

namespace VATHelper.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } // Date of the Invoice
        public TransactionType TransactionType { get; set; } // Did I spend or get money?
        public string TransactionSecondParty { get; init; } = string.Empty; // Who was the customer/supplier
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public List<TransactionPosition> Positions { get; init; } = new();

        private Transaction() {}

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

