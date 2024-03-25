namespace LegacyPrinterExample;

// Abstract Adapter
public interface IPrinterAdapter
{
    void Print(string document, int copies = 1);
}
