namespace DiscountCalculatorLibrary.Tests;

public class DiscountCalculatorTest
{
    private readonly DiscountCalculator discountCalculator;

    public DiscountCalculatorTest()
    {
        discountCalculator = new DiscountCalculator();
    }

    [Fact]
    public void CalculateDiscount_EmptyDiscountCode_ShouldBeOriginalPrice()
    {
        var result = discountCalculator.CalculateDiscount(1, string.Empty);

        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateDiscount_SAVE10NOWDiscountCode_ShouldBeDiscountedBy10PercentPrice()
    {
        var result = discountCalculator.CalculateDiscount(10, "SAVE10NOW");

        Assert.Equal(9, result);
    }

    [Fact]
    public void CalculateDiscount_DISCOUNT20OFFDiscountCode_ShouldBeDiscountedBy20PercentPrice()
    {
        var result = discountCalculator.CalculateDiscount(10, "DISCOUNT20OFF");

        Assert.Equal(8, result);
    }

    [Fact]
    public void CalculateDiscount_PriceBelowZero_ShouldThrowArgumentExceptionWithMessage()
    {
        Action act = () => discountCalculator.CalculateDiscount(-1, string.Empty);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Negatives not allowed", exception.Message);
    }

    [Fact]
    public void CalculateDiscount_InvalidDiscountCode_ShouldThrowArgumentExceptionWithMessage()
    {
        const string InvalidDiscountCode = "A";

        Action act = () => discountCalculator.CalculateDiscount(0, InvalidDiscountCode);

        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid discount code", exception.Message);
    }


}