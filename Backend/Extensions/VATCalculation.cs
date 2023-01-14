using VATHelper.Models;
namespace VATHelper.Extensions;

public static class VATCalculation
{
    private const decimal TaxRate = (decimal)0.19;
    public static decimal NetToGross(this decimal input)
    {
        return input * (TaxRate + decimal.One);
    }

    public static decimal GrossToNet(this decimal input)
    {
        return input / (TaxRate + decimal.One);
    }

    public static decimal GetNetSum(this List<TransactionPosition> positions)
    {
        return positions.Aggregate(decimal.Zero, (acc, x) => acc + x.TotalPrice);
    }
}