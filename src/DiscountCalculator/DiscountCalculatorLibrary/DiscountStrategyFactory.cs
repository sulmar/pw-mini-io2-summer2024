namespace DiscountCalculatorLibrary;


// Concrete Factory
public class DiscountStrategyFactory : IDiscountStrategyFactory
{
    public IDiscountStrategy Create(string discountCode) => discountCode switch
    {
        "SAVE10NOW" => new PercentageDiscountStrategy(0.1m),
        "DISCOUNT20OFF" => new PercentageDiscountStrategy(0.2m),
        _ => throw new ArgumentException("Invalid discount code")
    };
}

// Proxy
public class DiscountStrategyFactoryProxy : IDiscountStrategyFactory
{
    // Real Subject
    private readonly IDiscountStrategyFactory realDiscountStrategyFactory;
    
    private readonly HashSet<string> discountCodes = [];

    public DiscountStrategyFactoryProxy(IEnumerable<string> discountCodes, IDiscountStrategyFactory realDiscountStrategyFactory)
    {
        this.discountCodes = discountCodes.ToHashSet();
        this.realDiscountStrategyFactory = realDiscountStrategyFactory;
    }

    public IDiscountStrategy Create(string discountCode)
    {
        if (discountCodes.Remove(discountCode))
        {
            return new PercentageDiscountStrategy(0.5m);
        }
        else
            return realDiscountStrategyFactory.Create(discountCode);
    }
}