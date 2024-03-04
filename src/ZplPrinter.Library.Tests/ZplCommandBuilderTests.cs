namespace ZplPrinter.Library.Tests;

public class ZplCommandBuilderTests
{
    [Fact]
    public void FieldData_ValidText_ShouldReturnsCommand()
    {
        // Arrange
        ZplCommandBuilder builder = new ZplCommandBuilder();
        builder
            .SetText("a")
            .SetText("b")
            .SetText("c");


        // Act
        var result = builder.Build();

        // Assert

        Assert.Equal("^XA\r\n^FDa\r\n^XZ\r\n", result);


    }
}