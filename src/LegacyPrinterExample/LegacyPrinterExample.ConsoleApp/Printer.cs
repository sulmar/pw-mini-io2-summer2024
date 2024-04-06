namespace LegacyPrinterExample;

public class Printer : IPrinter
{
    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }
    }
}
