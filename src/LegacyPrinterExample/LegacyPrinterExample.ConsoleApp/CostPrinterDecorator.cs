namespace LegacyPrinterExample;

public class CostPrinterDecorator : IPrinterAdapter
{
    private readonly IPrinterAdapter _printerAdapter;

    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public CostPrinterDecorator(IPrinterAdapter printerAdapter)
    {
        this._printerAdapter = printerAdapter;
    }

    public void Print(string document, int copies = 1)
    {
        _printerAdapter.Print(document, copies);

        var cost = CalculateCost(copies);
        Console.WriteLine($"{cost:C2}");
    }

    private decimal CalculateCost(int copies)
    {
        return copies * _costPerCopy;
    }
}
