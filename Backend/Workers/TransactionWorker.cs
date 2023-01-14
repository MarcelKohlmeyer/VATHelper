using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using VATHelper.CSVTransformers;
using VATHelper.Database;
using VATHelper.Interfaces;
using VATHelper.Models;

namespace VATHelper.Workers
{
    public class TransactionWorker : ITransactionWorker
    {
        private const string HetznerRegex = @"Hetzner_[0-9]{4}-[0-9]{2}-[0-9]{2}_R[0-9]{10}\.csv";
        private readonly ITransactionInputTransformer _transformer;
        private readonly TransactionContext _database;

        public TransactionWorker(ITransactionInputTransformer transformer, TransactionContext database)
        {
            _transformer = transformer;
            _database = database;
        }

        public async Task<Guid> AddTransaction(string input, string fileName)
        {
            ITransformableToTransaction transformable;
            if (Regex.IsMatch(fileName, HetznerRegex))
            {
                transformable = new Hetzner(input, fileName);
            }
            // Else if (other CSVInput) ...
            else
            {
                throw new Exception($"No transformer for filename {fileName}");
            }

            // Create Transaction:
            var transaction = _transformer.GetTransactionFrom(transformable);
            
            // Save Transaction to database
            _database.Add(transaction);
            await _database.SaveChangesAsync();
            
            
            return transaction.Id;
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            Console.WriteLine(_database.DbPath);
            _database.Transactions.Include(t => t.Positions);
            return await _database.Transactions.ToListAsync();
        }
    }
}

