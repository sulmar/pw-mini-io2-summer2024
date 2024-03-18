namespace DiscountCalculatorLibrary;

public class DiscountCalculator
{
    private readonly HashSet<string> discountCodes = [];

    public DiscountCalculator()
    {

    }

    public DiscountCalculator(IEnumerable<string> discountCodes)
            : this()
    {
        this.discountCodes = discountCodes.ToHashSet();
    }

    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        // TODO: Refactor this

        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        IDiscountStrategy discountStrategy = new NoDiscountStrategy();

        switch (discountCode)
        {
            case "SAVE10NOW":
                discountStrategy = new DiscountPercentageStrategy(0.1m);
                break;
            case "DISCOUNT20OFF":
                discountStrategy = new DiscountPercentageStrategy(0.2m);
                break;
            default:
                if (discountCodes.Contains(discountCode))
                {
                    discountCodes.Remove(discountCode);

                    discountStrategy = new DiscountPercentageStrategy(0.5m);
                }
                else
                    throw new ArgumentException("Invalid discount code");
                break;
        }

        return price - discountStrategy.Discount(price);
    }
}
