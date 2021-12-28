using System.Text;
using System.Text.Json;
using BrandService.Dtos;

namespace BrandService.SyncServices.Http;

public class HttpProductClient : IProductClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _congiguration;

    public HttpProductClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _congiguration = configuration;
    }

    public async Task SendBrandToProduct(GetBrandDto brand)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(brand),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync($"{_congiguration["ProductService"]}/api/products/brands", httpContent);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Sync POST to Product service is Success");
        }
        else
        {
            Console.WriteLine("Sync POST to Product service is Failed");
        }
    }
}
