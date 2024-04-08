namespace LegacyPrinterExample;

// Concrete Decorator
public class CostPrinterDecorator : IPrinter
{
    // decoratee
    private readonly IPrinter _printer;
    private readonly ICostPrinterCalculatorStrategy strategy;

    public CostPrinterDecorator(IPrinter printer, ICostPrinterCalculatorStrategy strategy)
    {
        this._printer = printer;
        this.strategy = strategy;
    }

    public void Print(string document, int copies = 1)
    {
        _printer.Print(document, copies);

        var cost = strategy.CalculateCost(copies);

        Console.WriteLine($"{cost:C2}");

    }

    
}
