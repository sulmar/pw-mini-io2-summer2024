namespace CacheExample;

public class DbProductRepository
{
    private readonly IDictionary<int, Product> products;

    public DbProductRepository()
    {
        products = new Dictionary<int, Product>()
        {
            { 1, new Product(1, "Product 1") },
            { 2, new Product(2, "Product 2") },
            { 3, new Product(3, "Product 3") },
        };
    }

    public Product? Get(int id)
    {
        if (products.TryGetValue(id, out var product))
        {
            return product;
        }
        else
            return null;
    }
}