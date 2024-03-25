namespace CacheExample.Library.Tests;

public class ProductsControllerTests
{
    private ProductsController productsController;

    public ProductsControllerTests()
    {
        productsController = new ProductsController(
            new CacheProductRepositoryProxy( 
                new DbProductRepository()));
    }
    
    [Fact]
    public void Get_FirstCall_ShouldCacheHitEqualZero()
    {
        // Arrange
        int productId = 1;

        // Act
        var request = productsController.Get(productId);

        // Assert
        Assert.Equal(0, request.CacheHit);
        Assert.Equal(1, request.Id);
        Assert.Equal("Product 1", request.Name);
    }
    
    [Fact]
    public void Get_TwiceCalls_ShouldCacheHitEqualOne()
    {
        // Arrange
        int productId = 1;

        // Act
        productsController.Get(productId);
            
        var request = productsController.Get(productId);

        // Assert
        Assert.NotNull(request); 
        Assert.Equal(1, request.CacheHit);
        Assert.Equal(1, request.Id);
        Assert.Equal("Product 1", request.Name);
    }
    
    [Fact]
    public void Get_ManyCalls_ShouldCacheHitAboveZero()
    {
        // Arrange
        int productId = 1;

        // Act
        productsController.Get(productId);
        productsController.Get(productId);
        productsController.Get(productId);

        var request = productsController.Get(productId);

        // Assert
        Assert.NotNull(request);
        Assert.Equal(3, request.CacheHit);
        Assert.Equal(1, request.Id);
        Assert.Equal("Product 1", request.Name);
    }
    
    [Fact]
    public void Get_NotFound_ShouldReturnsEmpty()
    {
        // Arrange
        int productId = -1;

        // Act
        var request = productsController.Get(productId);

        // Assert
        Assert.Null(request);
    }
}