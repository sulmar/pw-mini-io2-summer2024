namespace CacheExample;

public class ProductsController
{
    private readonly DbProductRepository productRepository;
    private readonly CacheProductRepository cacheProductRepository;

    public ProductsController(
        DbProductRepository productRepository, 
        CacheProductRepository cacheProductRepository)
    {
        this.productRepository = productRepository;
        this.cacheProductRepository = cacheProductRepository;
    }

    public Product Get(int id)
    {
        Product product = cacheProductRepository.Get(id);

        if (product == null)
        {
            product = productRepository.Get(id);

            if (product != null)
            {
                cacheProductRepository.Add(product);
            }
        }

        return product;
    }
}