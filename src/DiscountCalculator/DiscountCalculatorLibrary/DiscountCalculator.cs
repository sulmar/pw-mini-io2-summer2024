namespace DiscountCalculatorLibrary;

public class DiscountCalculator
{
    private DiscountStrategyFactory _discountStrategyFactory;
    public DiscountCalculator(DiscountStrategyFactory discountStrategyFactory)
    {
        _discountStrategyFactory = discountStrategyFactory;
    }

    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        IDiscountStrategy discountStrategy = _discountStrategyFactory.Create(discountCode);

        return price - discountStrategy.Discount(price);
    }
}
