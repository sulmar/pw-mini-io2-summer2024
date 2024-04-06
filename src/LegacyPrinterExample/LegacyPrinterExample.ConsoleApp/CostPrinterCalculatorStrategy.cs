namespace LegacyPrinterExample;

public class CostPrinterCalculatorStrategy : ICostPrinterCalculatorStrategy
{
    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public decimal CalculateCost(int copies)
    {
        return copies * _costPerCopy;
    }
}
