namespace LegacyPrinterExample;

// Concrete Adapter
public class LegacyPrinterAdapter : IPrinter
{
    // Adaptee
    private readonly LegacyPrinter _printer;

    public LegacyPrinterAdapter()
    {
        _printer = new LegacyPrinter();
    }

    public void Print(string document, int copies = 1)
    {
        for (int i = 0; i < copies; i++)
        {
            _printer.PrintDocument(document);
        }
    }
}
