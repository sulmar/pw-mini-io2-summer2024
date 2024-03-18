namespace DiscountCalculatorLibrary;

// Abstract Factory
public interface IDiscountStrategyFactory
{
    IDiscountStrategy Create(string discountCode);
}
