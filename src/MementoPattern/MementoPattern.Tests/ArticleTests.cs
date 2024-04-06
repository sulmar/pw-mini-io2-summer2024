namespace MementoPattern.Tests
{
    public class ArticleTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var article = new Article();
            article.Content = "a";
            article.Content = "b";
            article.Content = "c";

            // Act
            // TODO: Undo

            // Assert
            Assert.Fail();

        }
    }
}