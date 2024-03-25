namespace LegacyPrinterExample;

// Concrete Adapter
public class LegacyPrinterAdapter : IPrinterAdapter
{
    // Adaptee
    private readonly LegacyPrinter printer;

    public LegacyPrinterAdapter()
    {
        printer = new LegacyPrinter();
    }

 

    public void Print(string document, int copies = 1)
    {
        for (int i = 0; i < copies; i++)
        {
            printer.PrintDocument(document);
        }

    }
}