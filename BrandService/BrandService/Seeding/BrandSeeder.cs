using BrandService.Models;
using BrandService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BrandService.Seeding;

public static class BrandSeeder
{
    public static void SeedData(WebApplication app, bool isDevelopment)
    {
        var context = app.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();
        if (context == null)
        {
            throw new InvalidOperationException("Cannot find implementation of db context");
        }

        SeedDataInternal(context, isDevelopment);
    }

    private static void SeedDataInternal(IApplicationDbContext context, bool isDevelopment)
    {
        if (!isDevelopment)
        {
            // ToDo: Add logging.
            Console.WriteLine("Applying migrations...");

            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not apply migrations: {ex.Message}");
            }
        }

        if (!context.Brands.Any())
        {
            context.Brands.AddRange(new Brand()
            {
                Name = "Apple",
                Publisher = "Apple",
                Description = "Sample data"
            },
            new Brand()
            {
                Name = "Ikea",
                Publisher = "Ikea",
                Description = "Sample data"
            },
            new Brand()
            {
                Name = "SpaceX",
                Publisher = "SpaceX",
                Description = "Sample data"
            },
            new Brand()
            {
                Name = "Microsoft",
                Publisher = "Microsoft",
                Description = "Sample data"
            });

            context.SaveChanges();
        }
    }
}
