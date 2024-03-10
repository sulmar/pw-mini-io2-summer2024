namespace ZplPrinter.Library.Tests;

public class ZplCommandBuilderTests
{
    [Fact]
    public void FieldData_ValidText_ShouldReturnsCommand()
    {
        // Arrange
        ZplCommandBuilder builder = ZplCommandBuilder.CreateLabel();
        builder
            .SetText("a");


        // Act
        var result = builder.Build();

        // Assert

        Assert.Equal("^XA\r\n^FDa\r\n^XZ", result);


    }

    [Fact]
    public void SetBarcode_ValidBarcode_ShouldReturnsZplCommand()
    {
        // Arrange
        ZplCommandBuilder sut = ZplCommandBuilder.CreateLabel();
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