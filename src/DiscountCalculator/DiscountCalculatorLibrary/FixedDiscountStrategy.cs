namespace DiscountCalculatorLibrary;

// Concrete Strategy B
public class FixedDiscountStrategy(decimal _amount) : IDiscountStrategy
{
    public decimal Discount(decimal price) => _amount;
}