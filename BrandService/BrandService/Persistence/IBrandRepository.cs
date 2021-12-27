using BrandService.Models;

namespace BrandService.Persistence;

public interface IBrandRepository
{
    IEnumerable<Brand> GetAll();
    Brand? GetById(int id);
    void Create(Brand brand);
    bool SaveChanges();
}
