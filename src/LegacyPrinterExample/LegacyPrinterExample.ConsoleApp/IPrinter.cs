namespace LegacyPrinterExample;

public interface IPrinter
{
    void Print(string document, int copies = 1);
    int Counter
    {
        get;
    }
}
