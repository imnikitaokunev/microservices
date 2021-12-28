using BrandService.Dtos;

namespace BrandService.SyncServices.Http;

public interface IProductClient
{
    Task SendBrandToProduct(GetBrandDto brand);
}
