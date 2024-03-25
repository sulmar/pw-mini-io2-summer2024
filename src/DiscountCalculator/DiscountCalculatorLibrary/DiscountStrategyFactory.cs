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
