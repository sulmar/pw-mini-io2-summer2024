namespace DiscountCalculatorLibrary
{
    // Object Null Pattern
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal price)
        {
            return decimal.Zero;
        }
    }
}
