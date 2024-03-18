namespace DiscountCalculatorLibrary;

public class DiscountCalculator(IDiscountStrategyFactory discountStrategyFactory)
{
    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        IDiscountStrategy discountStrategy = discountStrategyFactory.Create(discountCode);

        return price - discountStrategy.CalculateDiscount(price);
    }
}
