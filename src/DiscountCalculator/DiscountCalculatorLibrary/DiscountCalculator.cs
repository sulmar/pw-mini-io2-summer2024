namespace DiscountCalculatorLibrary;

public class DiscountCalculator
{
    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        if (discountCode == "SAVE10NOW")
            return price - price * 0.1m;

        if (discountCode == "DISCOUNT20OFF")
            return price - price * 0.2m;

        throw new NotImplementedException();
    }
}
