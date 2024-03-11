namespace DiscountCalculatorLibrary.Tests;

public class DiscountCalculatorTest
{
    [Fact]
    public void CalculateDiscount_EmptyDiscountCode_ShouldBeOriginalPrice()
    {
        Assert.Fail();
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