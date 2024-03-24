namespace LegacyPrinterExample;

public class Printer
{
    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy
    public int Counter { get; private set; }
    
    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }

        var cost = CalculateCost(copies);
        Console.WriteLine($"{cost:C2}");
        
        Counter += copies;
    }

    private decimal CalculateCost(int copies)
    {
        return copies * _costPerCopy;
    }
}

// Uwaga: Nie zmieniaj kodu tej klasy!
public sealed class LegacyPrinter
{
    public void PrintDocument(string document)
    {
        Console.WriteLine($"Legacy Printer is printing: {document}");
    }
}