namespace DiscountCalculatorLibrary.Tests;



public class DiscountStrategyFactoryProxyTests
{
    [Fact]
    public void Create_UseDiscountCode_ShouldReturnsPercentageDiscountStrategy()
    {
        var sut = new DiscountStrategyFactoryProxy(
            new FakeDiscountStrategyFactory(),
            ["A"]);

        var result = sut.Create("A");

        Assert.IsType<PercentageDiscountStrategy>(result);
   
    }

    [Fact]
    public void Create_UseTwiceDiscountCode_ShouldThrowArgumentExceptionWithMessage()
    {
        var sut = new DiscountCalculator(
            new DiscountStrategyFactoryProxy(new DiscountStrategyFactory(), ["A"]));

        const string ValidDiscountCode = "A";

        sut.CalculateDiscount(1, ValidDiscountCode);

        Action act = () => sut.CalculateDiscount(0, ValidDiscountCode);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid discount code", exception.Message);
    }

    [Fact]
    public void Create_UseInvalidDiscountCode_ShouldReturnsPercentageDiscountStrategy()
    {
        var sut = new DiscountStrategyFactoryProxy(
            new DiscountStrategyFactory(),
            ["A"]);

        var exception = Assert.Throws<ArgumentException>(() => sut.Create("B"));

        Assert.Equal("Invalid discount code", exception.Message);
    }
}
