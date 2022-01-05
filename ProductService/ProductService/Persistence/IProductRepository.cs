using ProductService.Models;

namespace ProductService.Persistence;

public interface IProductRepository
{
    IEnumerable<Product> GetAll(int brandId);
    Product? GetById(int brandId, int productId);
    void Create(int brandId, Product product);
    bool SaveChanges();
}
