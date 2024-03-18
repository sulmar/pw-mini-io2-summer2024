using System.Diagnostics.SymbolStore;

namespace DiscountCalculatorLibrary.Tests;

public class FixedDiscountStrategyTests
{
    [Theory]
    [InlineData(10, 1, 1)]
    [InlineData(10, 2, 2)]
    public void CalculateDiscount_WhenCalled_ShouldBeDiscounted(decimal price, decimal amount, decimal expectedPrice)
    {
        IDiscountStrategy sut = new FixedDiscountStrategy(amount);

        var result = sut.CalculateDiscount(price);

        Assert.Equal(expectedPrice, result);
    }
}
