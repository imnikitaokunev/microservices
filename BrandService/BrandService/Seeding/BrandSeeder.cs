using BrandService.Models;
using BrandService.Persistence;

namespace BrandService.Seeding;

public static class BrandSeeder
{
    public static void SeedData(WebApplication app)
    {
        var context = app.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();
        if(context == null)
        {
            throw new InvalidOperationException("Cannot find implementation of db context");
        }

        SeedDataInternal(context);
    }

    private static void SeedDataInternal(IApplicationDbContext context)
    {
        if (!context.Brands.Any())
        {
            context.Brands.AddRange(new Brand()
            {
                Id = 1,
                Name = "Apple",
                Publisher = "Apple",
                Description = "Sample data"
            },
            new Brand()
            {
                Id = 2,
                Name = "Ikea",
                Publisher = "Ikea",
                Description = "Sample data"
            },
            new Brand()
            {
                Id = 3,
                Name = "SpaceX",
                Publisher = "SpaceX",
                Description = "Sample data"
            },
            new Brand()
            {
                Id = 4,
                Name = "Microsoft",
                Publisher = "Microsoft",
                Description = "Sample data"
            });

            context.SaveChanges();
        }
    }
}
