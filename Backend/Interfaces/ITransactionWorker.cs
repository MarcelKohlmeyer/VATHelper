using System;
using VATHelper.Models;

namespace VATHelper.Interfaces
{
    public interface ITransactionWorker
    {
        /// <summary>
        /// Adds a <see cref="Transaction"/> to the database.
        /// </summary>
        /// <param name="input">The raw filecontent</param>
        /// <param name="filename">The filename of the input file for deciding which transformer to use</param>
        /// <returns>The ID of the newly added <see cref="Transaction"/></returns>
        public Task<Guid> AddTransaction(string input, string filename);
        
        /// <summary>
        /// Gets all <see cref="Transaction"/>s from the database
        /// </summary>
        /// <returns>A list of <see cref="Transaction"/>s</returns>
        public Task<List<Transaction>> GetTransactions();
    }
}

