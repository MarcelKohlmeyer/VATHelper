using VATHelper.Interfaces;
using VATHelper.Models;

namespace VATHelper.Workers;

public class TransactionTransformer: ITransactionInputTransformer
{
    public Transaction GetTransactionFrom<T>(T input) where T : ITransformableToTransaction
    {
        return input.ToTransaction();
    }
}