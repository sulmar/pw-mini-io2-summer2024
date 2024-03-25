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
    public void Create_WhenInvalidCode_ShouldThrowArgumentExceptionWithMessage()
    {
        const string InvalidDiscountCode = "A";
        DiscountStrategyFactory sut = new DiscountStrategyFactory();

        var exception = Assert.Throws<ArgumentException>(() => sut.Create(InvalidDiscountCode));

        Assert.Equal("Invalid discount code", exception.Message);
    }





}