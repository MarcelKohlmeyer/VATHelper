using VATHelper.Models;
namespace VATHelper.Extensions;

public static class VATCalculation
{
    public static decimal NetToGross(this decimal input)
    {
        return input * Transaction.TaxRate;
    }

    public static decimal GrossToNet(this decimal input)
    {
        return input / Transaction.TaxRate;
    }

    public static decimal GetNetSum(this List<TransactionPosition> positions)
    {
        return positions.Aggregate((decimal)0, (acc, x) => acc + x.TotalPrice);
    }
}