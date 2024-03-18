namespace DiscountCalculatorLibrary
{
    public class DiscountStrategyFactory
    {
        private readonly HashSet<string> discountCodes = [];

        public DiscountStrategyFactory()
        {
            
        }

        public DiscountStrategyFactory(IEnumerable<string> discountCodes)
            : this()
        {
            this.discountCodes = discountCodes.ToHashSet();
        }

        public IDiscountStrategy Create(string discountCode) => discountCode switch
        {
            "SAVE10NOW" => new PercentageDiscountStrategy(0.1m),
            "DISCOUNT20OFF" => new PercentageDiscountStrategy(0.2m),
            var _ when discountCodes.Remove(discountCode)
                => new PercentageDiscountStrategy(0.5m),
            _ => throw new ArgumentException("Invalid discount code")
        };
    }
}
