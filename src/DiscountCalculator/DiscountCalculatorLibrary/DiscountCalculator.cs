namespace DiscountCalculatorLibrary;

public class DiscountCalculator
{
    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (string.IsNullOrEmpty(discountCode))
        {
            return price;
        }

        throw new NotImplementedException();
    }
}
