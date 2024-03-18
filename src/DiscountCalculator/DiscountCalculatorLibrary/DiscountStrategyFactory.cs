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

        public IDiscountStrategy Create(string discountCode)
        {
            IDiscountStrategy discountStrategy = new NoDiscountStrategy();

            switch (discountCode)
            {
                case "SAVE10NOW":
                    discountStrategy = new PercentageDiscountStrategy(0.1m);
                    break;
                case "DISCOUNT20OFF":
                    discountStrategy = new PercentageDiscountStrategy(0.2m);
                    break;
                default:
                    if (discountCodes.Contains(discountCode))
                    {
                        discountCodes.Remove(discountCode);

                        discountStrategy = new PercentageDiscountStrategy(0.5m);
                    }
                    else
                        throw new ArgumentException("Invalid discount code");
                    break;
            }

            return discountStrategy;
        }
    }
}
