namespace DiscountCalculatorLibrary;

// Abstract Strategy
public interface IDiscountStrategy
{
    decimal Discount(decimal price);
}
