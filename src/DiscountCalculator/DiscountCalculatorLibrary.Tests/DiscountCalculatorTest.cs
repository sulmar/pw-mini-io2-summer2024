namespace DiscountCalculatorLibrary.Tests;

public class DiscountCalculatorTest
{
    [Fact]
    public void CalculateDiscount_EmptyDiscountCode_ShouldBeOriginalPrice()
    {
        DiscountCalculator discountCalculator = new DiscountCalculator();

        var result = discountCalculator.CalculateDiscount(1, string.Empty);

        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateDiscount_SAVE10NOWDiscountCode_ShouldBeDiscountedBy10PercentPrice()
    {
        Assert.Fail();
    }

    [Fact]
    public void CalculateDiscount_DISCOUNT20OFFDiscountCode_ShouldBeDiscountedBy20PercentPrice()
    {
        Assert.Fail();
    }

    [Fact]
    public void CalculateDiscount_PriceBelowZero_ShouldThrowArgumentExceptionWithMessage()
    {
        Assert.Fail();
    }

    [Fact]
    public void CalculateDiscount_InvalidDiscountCode_ShouldThrowArgumentExceptionWithMessage()
    {
        Assert.Fail();
    }


}