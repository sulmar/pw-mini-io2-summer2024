namespace DiscountCalculatorLibrary;

public class DiscountStrategyFactoryProxy : IDiscountStrategyFactory
{
    private readonly HashSet<string> discountCodes = [];

    // Real Subject
    private readonly IDiscountStrategyFactory _factory;

    public DiscountStrategyFactoryProxy(
        IDiscountStrategyFactory factory, 
        IEnumerable<string> discountCodes)
    {
        _factory = factory;

        this.discountCodes = discountCodes.ToHashSet();
    }

    public IDiscountStrategy Create(string discountCode)
    {
        if (discountCodes.Remove(discountCode))
        {
            return new PercentageDiscountStrategy(0.5m);
        }
        else
            // Real Operation
            return _factory.Create(discountCode);

    }
}
