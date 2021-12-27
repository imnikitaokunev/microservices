using BrandService.Dtos;
using BrandService.Models;
using BrandService.Persistence;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BrandService.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;

    public BrandsController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
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
        if(brand is null)
        {
            return NotFound();
        }

        return Ok(brand.Adapt<GetBrandDto>());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBrandDto dto)
    {
        var brand = dto.Adapt<Brand>();
        _brandRepository.Create(brand);
        _brandRepository.SaveChanges();

        var brandDto = brand.Adapt<GetBrandDto>();
        return CreatedAtRoute(nameof(GetById), new { brandDto.Id }, brandDto);
    }
}
