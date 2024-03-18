namespace DiscountCalculatorLibrary.Tests;

// TODO: Replace by Mock
internal class FakeDiscountStrategyFactory : IDiscountStrategyFactory
{
    public IDiscountStrategy Create(string discountCode) => new PercentageDiscountStrategy(0.5m);
}
