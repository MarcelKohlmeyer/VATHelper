using System;
namespace VATHelper.Interfaces
{
    public interface ITransactionWorker
    {
        public Task<Guid> AddTransaction(string input, string filename);
    }
}

