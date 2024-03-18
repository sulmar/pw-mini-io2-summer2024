namespace DiscountCalculatorLibrary.Tests;

public class DiscountStrategyFactoryTests
{
    [Theory]
    [InlineData("SAVE10NOW")]
    [InlineData("DISCOUNT20OFF")]
    public void Create_WhenSAVE10NOW_ShouldReturnsPercentageDiscountStrategy(string discountCode)
    {
        DiscountStrategyFactory sut = new DiscountStrategyFactory();

        var result = sut.Create(discountCode);

        Assert.IsType<PercentageDiscountStrategy>(result);
    }
    
    [Fact]
    public void Create_UseDiscountCode_ShouldReturnsPercentageDiscountStrategy()
    {
        var sut = new DiscountStrategyFactoryProxy(["A"], new DiscountStrategyFactory());

        var result = sut.Create("A");

        Assert.IsType<PercentageDiscountStrategy>(result);
    }

    [Fact]
    public void Create_UseTwiceDiscountCode_ShouldThrowArgumentExceptionWithMessage()
    {
        var sut = new DiscountStrategyFactoryProxy(["A"], new DiscountStrategyFactory());

        const string ValidDiscountCode = "A";

        sut.Create(ValidDiscountCode);

        Action act = () => sut.Create(ValidDiscountCode);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid discount code", exception.Message);
    }
}