using BrandService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandService.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Brand> Brands { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
