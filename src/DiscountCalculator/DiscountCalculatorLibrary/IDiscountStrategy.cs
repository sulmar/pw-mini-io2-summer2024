namespace DiscountCalculatorLibrary;

// Abstract Strategy
public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal price);
}
