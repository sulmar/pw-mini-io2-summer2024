namespace CacheExample;

// Proxy
public class CacheProductRepositoryProxy : IProductRepository
{
    private IDictionary<int, Product> products;

    private readonly IProductRepository productRepository;

    public CacheProductRepositoryProxy(IProductRepository productRepository)
    {
        products = new Dictionary<int, Product>();

        this.productRepository = productRepository;
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
        {
            // Real Subject
            product = productRepository.Get(id);

            if (product != null)
            {
                Add(product);
            }

            return product;
        }        
    }

}