namespace LegacyPrinterExample;

public class CounterPrinterProxy : IPrinter
{
    private readonly IPrinter _printer;

    public CounterPrinterProxy(IPrinter printer)
    {
        _printer = printer;
    }

    public int Counter { get; private set; }

    public void Print(string document, int copies = 1)
    {
        _printer.Print(document, copies);

        Counter += copies;
    }
}
