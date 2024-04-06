namespace LegacyPrinterExample;

public class PrinterFactory
{
    public static IPrinter Create(bool legacy)
    {
        return legacy ? new LegacyPrinterAdapter() : new Printer();
    }
}
