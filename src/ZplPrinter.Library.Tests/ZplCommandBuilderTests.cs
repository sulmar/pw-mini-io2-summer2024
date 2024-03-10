namespace ZplPrinter.Library.Tests;

public class ZplCommandBuilderTests
{
    private readonly ZplCommandBuilder sut; // sut - System Under Test

    public ZplCommandBuilderTests()
    {
        sut = ZplCommandBuilder.CreateLabel();
    }

    [Fact]
    public void FieldData_ValidText_ShouldReturnsCommand()
    {
        // Arrange
        sut.SetText("a");

        // Act
        var result = sut.Build();

        // Assert

        Assert.Equal("^XA\r\n^FDa\r\n^XZ", result);


    }

    [Fact]
    public void SetBarcode_ValidBarcode_ShouldReturnsZplCommand()
    {
        // Arrange
        sut.SetBarcode("a", "C", 1, 2);

        // Act
        var result = sut.Build();

        // Assert
        // Assert.Equal("^XA\n^BC,1,2\n^FDa\n^XZ", result);
        Assert.StartsWith("^XA", result);
        Assert.Contains("^BC,1,2", result);
        Assert.EndsWith("^XZ", result);
    }
}