using VATHelper.Interfaces;
using VATHelper.Models;

namespace VATHelper.CSVTransformers;

public class Hetzner: ITransformableToTransaction
{
    private string _csvInput;
    public Hetzner(string csvInput)
    {
        _csvInput = csvInput;
    }
    
    public Transaction ToTransaction()
    {
        return new Transaction();
    }
}