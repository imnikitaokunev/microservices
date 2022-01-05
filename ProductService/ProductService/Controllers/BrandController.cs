using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductService.Dtos;
using ProductService.Persistence;

namespace ProductService.Controllers;

[Route("api/products/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;

    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    [HttpGet]
    public IActionResult GetBrands()
    {
        return Ok(_brandRepository.GetAll().Adapt<IEnumerable<GetBrandDto>>());
    }

    [HttpPost]
    public IActionResult TestConnection()
    {
        Console.WriteLine("--> Inbound POST # Product Service");
        return Ok("Inbound Test of products controller");
    }
}
