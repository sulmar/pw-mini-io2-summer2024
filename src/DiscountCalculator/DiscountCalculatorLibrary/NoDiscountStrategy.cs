namespace DiscountCalculatorLibrary
{
    // Object Null Pattern
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal Discount(decimal price)
        {
            return decimal.Zero;
        }
    }
}
