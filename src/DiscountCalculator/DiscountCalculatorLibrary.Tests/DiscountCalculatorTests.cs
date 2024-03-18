namespace DiscountCalculatorLibrary.Tests;

public class DiscountCalculatorTests
{
    private DiscountCalculator sut;

    public DiscountCalculatorTests()
    {
        sut = new DiscountCalculator(new FakeDiscountStrategyFactory());
    }

    [Fact]
    public void CalculateDiscount_EmptyDiscountCode_ShouldBeOriginalPrice()
    {
        var result = sut.CalculateDiscount(1, string.Empty);

        Assert.Equal(1, result);
    }

  
    [Fact]
    public void CalculateDiscount_PriceBelowZero_ShouldThrowArgumentExceptionWithMessage()
    {
        Action act = () => sut.CalculateDiscount(-1, string.Empty);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Negatives not allowed", exception.Message);
    }

    

    [Fact]
    public void CalculateDiscount_UseDiscountCode_ShouldBeDiscountedBy50PercentPrice()
    {
        sut = new DiscountCalculator(new FakeDiscountStrategyFactory());

        var result = sut.CalculateDiscount(10, "A");

        Assert.Equal(5, result);
    }
}
