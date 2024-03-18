namespace DiscountCalculatorLibrary.Tests;

public class PercentageDiscountStrategyTests
{
    [Theory]
    [InlineData(10, 0.1, 1)]
    [InlineData(10, 0.2, 2)]
    public void CalculateDiscount_WhenCalled_ShouldBeDiscounted(decimal price, decimal percentage, decimal expectedPrice)
    {
        IDiscountStrategy sut = new PercentageDiscountStrategy(percentage);

        var result = sut.CalculateDiscount(price);

        Assert.Equal(expectedPrice, result);
    }
}
