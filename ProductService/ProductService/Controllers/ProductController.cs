using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.Persistence;

namespace ProductService.Controllers;

[Route("api/products/brands/{brandId}/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;

    public ProductController(IProductRepository productRepository, IBrandRepository brandRepository)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
    }

    [HttpGet("{brandId:int}")]
    public IActionResult GetBrandProducts(int brandId)
    {
        if (_brandRepository.GetById(brandId) == null)
        {
            return NotFound();
        }

        return Ok(_productRepository.GetAll(brandId).Adapt<IEnumerable<GetProductDto>>());
    }

    [HttpGet("{productId:int}", Name = "GetById")]
    public IActionResult GetById(int brandId, int productId)
    {
        if (_brandRepository.GetById(brandId) == null)
        {
            return NotFound();
        }

        var product = _productRepository.GetById(brandId, productId);
        return product is null ? NotFound() : Ok(product.Adapt<GetProductDto>());
    }

    [HttpPost]
    public IActionResult Create(int brandId, CreateProductDto productDto)
    {
        if (_brandRepository.GetById(brandId) == null)
        {
            return NotFound();
        }

        var product = productDto.Adapt<Product>();
        _productRepository.Create(brandId, product);
        _productRepository.SaveChanges();

        var dto = product.Adapt<GetProductDto>();
        return CreatedAtRoute(nameof(GetById), new { brandId = brandId, productId = dto.Id }, dto);
    }
}
