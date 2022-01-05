using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Persistence;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; set; }
    DbSet<Product> Products { get; set; }
    int SaveChanges();
}
