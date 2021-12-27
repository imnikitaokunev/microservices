using BrandService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandService.Persistence;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; set; }
    int SaveChanges();
}
