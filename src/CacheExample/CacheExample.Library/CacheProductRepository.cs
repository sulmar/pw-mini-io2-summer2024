namespace CacheExample;

public class CacheProductRepository
{
    private IDictionary<int, Product> products;

    public CacheProductRepository()
    {
        products = new Dictionary<int, Product>();
    }

    public void Add(Product product)
    {
        products.Add(product.Id, product);
    }

    public Product? Get(int id)
    {
        if (products.TryGetValue(id, out var product))
        {
            product.CacheHit++;

            return product;
        }
        else
            return null;            
    }

}