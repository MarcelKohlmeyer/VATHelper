using VATHelper.Models;

namespace VATHelper.Interfaces;

public interface ITransformableToTransaction
{
    public Transaction ToTransaction();
}