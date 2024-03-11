namespace DiscountCalculatorLibrary;

public class DiscountCalculator
{
    private readonly HashSet<string> discountCodes=[];

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

        if (discountCode == "SAVE10NOW")
            return price - price * 0.1m;

        if (discountCode == "DISCOUNT20OFF")
            return price - price * 0.2m;

        if (discountCodes.Contains(discountCode))
        {
            discountCodes.Remove(discountCode);

            return price - price * 0.5m;
        }

        throw new ArgumentException("Invalid discount code");
    }
}
