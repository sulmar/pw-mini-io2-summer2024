namespace LegacyPrinterExample;


public interface ICounter
{
    int Counter { get; }
}

public class Printer : IPrinterAdapter
{
    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }        
    }
}
