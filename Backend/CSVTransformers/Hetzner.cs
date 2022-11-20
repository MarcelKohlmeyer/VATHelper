using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using VATHelper.Interfaces;
using VATHelper.Models;

namespace VATHelper.CSVTransformers;

public class Hetzner: ITransformableToTransaction
{
    private readonly string _csvInput;
    private readonly string _fileName;
    public Hetzner(string csvInput, string fileName)
    {
        _csvInput = csvInput;
        _fileName = fileName;
    }
    
    public Transaction ToTransaction()
    {
        List<TransactionPosition> positions = new();
        var lines = _csvInput.Split(",\"\"\n"); // CSV ends with empty field and linebreak
        foreach (string line in lines)
        {
            if (line == "")
                break; // Last element is empty
            NumberStyles style = NumberStyles.Float;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            var fields = line.Split(',');
            if (!decimal.TryParse(fields[5].Trim('"'), style, culture, out var quantity))
                throw new Exception("Could not parse quantity");
            
            if (!decimal.TryParse(fields[6].Trim('"'),style,culture, out var unitPrice))
                throw new Exception("Could not parse unitPrice");
            
            positions.Add(new TransactionPosition
            {
                Name = fields[1].Trim('"'),
                Description = fields[2].Trim('"'),
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalPrice = quantity * unitPrice
            });
        }

        Regex dateExtractionRegex = new Regex(@"Hetzner_([0-9]{4}-[0-9]{2}-[0-9]{2})_R[0-9]{10}\.csv");
        var dateMatch = dateExtractionRegex.Match(_fileName);
        var date = dateMatch.Groups[1].Value;
        DateTime invoiceDate = DateTime.Parse(date);

        return Transaction.FromPositions(invoiceDate, TransactionType.Expense, nameof(Hetzner), positions);
    }
}