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

        Assert.Equal("^XA\r\n^FDa\r\n^XZ\r\n", result);


    }
}