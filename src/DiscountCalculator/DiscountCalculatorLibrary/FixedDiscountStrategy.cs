namespace DiscountCalculatorLibrary;

// Concrete Strategy B
public class FixedDiscountStrategy(decimal _amount) : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price) => _amount;
}