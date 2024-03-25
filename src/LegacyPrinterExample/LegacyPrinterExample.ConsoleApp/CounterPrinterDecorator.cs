namespace LegacyPrinterExample;

public class CounterPrinterDecorator : IPrinterAdapter, ICounter
{
    private readonly IPrinterAdapter _printerAdapter;

    public CounterPrinterDecorator(IPrinterAdapter printerAdapter)
    {
        _printerAdapter = printerAdapter;
    }

    public int Counter { get; private set; }

    public void Print(string document, int copies = 1)
    {
        _printerAdapter.Print(document, copies);

        Counter += copies;
    }
}
