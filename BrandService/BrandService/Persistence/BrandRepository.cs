using BrandService.Models;

namespace BrandService.Persistence;

public class BrandRepository : IBrandRepository
{
    private readonly IApplicationDbContext _context;

    public BrandRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Brand> GetAll()
    {
        return _context.Brands.ToList();
    }

    public Brand? GetById(int id)
    {
        return _context.Brands.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Brand brand)
    {
        if (brand == null)
        {
            throw new ArgumentNullException(nameof(brand));
        }

        _context.Brands.Add(brand);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}
