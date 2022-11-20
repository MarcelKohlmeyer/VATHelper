using System.Text.RegularExpressions;
using VATHelper.CSVTransformers;
using VATHelper.Interfaces;

namespace VATHelper.Workers
{
    public class TransactionWorker : ITransactionWorker
    {
        private const string HetznerRegex = @"Hetzner_[0-9]{4}-[0-9]{2}-[0-9]{2}_R[0-9]{10}\.csv";
        private readonly ITransactionInputTransformer _transformer;

        public TransactionWorker(ITransactionInputTransformer transformer)
        {
            _transformer = transformer;
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
            
            return transaction.Id;
        }
    }
}

