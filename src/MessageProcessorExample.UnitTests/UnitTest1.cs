namespace MessageProcessorExample.UnitTests;

public class FakeMessageRepository : IMessageRepository
{
    public bool IsCalled;
    public void Add(Message message)
    {
        IsCalled = true;
    }
}

public class ValidatorMessageHandlerTests
{
    [Fact]
    public void Handle_EmptyMessage_ShouldThrowsArgumentException()
    {
        // Arrange
        var sut = new ValidatorMessageHandler();
        var emptyMessage = new Message(string.Empty, string.Empty, string.Empty);

        // Act
        var act = () => sut.Handle(emptyMessage);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

}

public class WhitelistMessageHandlerTests
{
    [Fact]
    public void Handle_NotContainsInWhitelist_ShouldThrowsInvalidOperationException()
    {
        // Arrange
        var sut = new WhitelistMessageHandler();

        // Act
        var act = () => sut.Handle(new Message("x@domaim.com", string.Empty, string.Empty));
        
        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }
    
}

public class MessageProcessorTests
{
    
    [Fact]
    public void Process_NotContainsOrder_ShouldThrowsFormatException()
    {
        // Arrange
        var sut = new MessageProcessor(null);

        // Act
        var act = () => sut.Process(new Message("a@domain.com", "a", "b"));
        
        // Assert
        Assert.Throws<FormatException>(act);
    }
    
    [Fact]
    public void Process_ValidMessage_ShouldCallAddToRepository()
    {
        // Arrange
        var repository = new FakeMessageRepository();
        var sut = new MessageProcessor(repository);

        // Act
        var act = () => sut.Process(new Message("a@domain.com", "ORDER", "b"));
        
        // Assert
        Assert.True(repository.IsCalled);
    }
    
}