namespace DiscountCalculatorLibrary.Tests;

public class DiscountCalculatorTest
{
    private DiscountCalculator sut;

    public DiscountCalculatorTest()
    {
        sut = new DiscountCalculator();
    }

    [Fact]
    public void CalculateDiscount_EmptyDiscountCode_ShouldBeOriginalPrice()
    {
        var result = sut.CalculateDiscount(1, string.Empty);

        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData(10, "SAVE10NOW", 9)]
    [InlineData(10, "DISCOUNT20OFF", 8)]
    public void CalculateDiscount_DiscountCode_ShouldBeDiscounted(decimal price, string discountCode, decimal expectedPrice)
    {
        var result = sut.CalculateDiscount(price, discountCode);

        Assert.Equal(expectedPrice, result);
    }

    [Fact]
    public void CalculateDiscount_PriceBelowZero_ShouldThrowArgumentExceptionWithMessage()
    {
        Action act = () => sut.CalculateDiscount(-1, string.Empty);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Negatives not allowed", exception.Message);
    }

    [Fact]
    public void CalculateDiscount_InvalidDiscountCode_ShouldThrowArgumentExceptionWithMessage()
    {
        const string InvalidDiscountCode = "A";

        Action act = () => sut.CalculateDiscount(0, InvalidDiscountCode);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid discount code", exception.Message);
    }

    [Fact]
    public void CalculateDiscount_UseDiscountCode_ShouldBeDiscountedBy50PercentPrice()
    {
        sut = new DiscountCalculator(["A"]);

        var result = sut.CalculateDiscount(10, "A");

        Assert.Equal(5, result);
    }

    [Fact]
    public void CalculateDiscount_UseTwiceDiscountCode_ShouldThrowArgumentExceptionWithMessage()
    {
        sut = new DiscountCalculator(["A"]);

        const string ValidDiscountCode = "A";

        sut.CalculateDiscount(1, ValidDiscountCode);

        Action act = () => sut.CalculateDiscount(0, ValidDiscountCode);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid discount code", exception.Message);
    }

}