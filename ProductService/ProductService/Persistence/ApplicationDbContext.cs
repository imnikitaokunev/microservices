using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
