using BrandService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BrandService.Persistence;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; set; }
    DatabaseFacade Database { get; }
    int SaveChanges();
}
