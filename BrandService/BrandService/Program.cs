using BrandService.Persistence;
using BrandService.Seeding;
using BrandService.SyncServices.Http;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemory"));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddScoped<IApplicationDbContext>(x => x.GetRequiredService<ApplicationDbContext>());
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddHttpClient<IProductClient, HttpProductClient>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

BrandSeeder.SeedData(app, app.Environment.IsDevelopment());

app.Run();
