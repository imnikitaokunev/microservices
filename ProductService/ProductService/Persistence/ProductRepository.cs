using ProductService.Models;

namespace ProductService.Persistence;

public class ProductRepository : IProductRepository
{
    private readonly IApplicationDbContext _context;

    public ProductRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll(int brandId)
    {
        return _context.Products.Where(x => x.BrandId.Equals(brandId)).OrderBy(x => x.Brand.Name);
    }

    public Product? GetById(int brandId, int productId)
    {
        return _context.Products.FirstOrDefault(x => x.BrandId.Equals(brandId) && x.Id.Equals(productId));
    }

    public void Create(int brandId, Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        product.BrandId = brandId;
        _context.Products.Add(product);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}
