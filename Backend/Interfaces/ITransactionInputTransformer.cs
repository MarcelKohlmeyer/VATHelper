using VATHelper.Models;
namespace VATHelper.Interfaces;

public interface ITransactionInputTransformer
{
    public Transaction GetTransactionFrom<T>(T input) where T : ITransformableToTransaction;
}