namespace DiscountCalculatorLibrary;

// Concrete Strategy A
public class PercentageDiscountStrategy(decimal _percentage) : IDiscountStrategy
{
    public decimal Discount(decimal price) => price * _percentage;
}
