using BrandService.Dtos;
using BrandService.Models;
using BrandService.Persistence;
using BrandService.SyncServices.Http;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BrandService.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;
    private readonly IProductClient _productClient;

    public BrandController(IBrandRepository brandRepository, IProductClient productClient)
    {
        _brandRepository = brandRepository;
        _productClient = productClient;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var brands = _brandRepository.GetAll();
        return Ok(brands.Adapt<IEnumerable<GetBrandDto>>());
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public IActionResult GetById([FromRoute] int id)
    {
        var brand = _brandRepository.GetById(id);
        if (brand is null)
        {
            return NotFound();
        }

        return Ok(brand.Adapt<GetBrandDto>());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateBrandDto dto)
    {
        var brand = dto.Adapt<Brand>();
        _brandRepository.Create(brand);
        _brandRepository.SaveChanges();

        var brandDto = brand.Adapt<GetBrandDto>();

        try
        {
            await _productClient.SendBrandToProduct(brandDto);
        }
        catch (Exception ex)
        {
            // ToDo: Add logger.
            Console.WriteLine($"Could not send synchronously: {ex.Message}");
        }

        return CreatedAtRoute(nameof(GetById), new { brandDto.Id }, brandDto);
    }
}
