using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;

[Route("api/products/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    [HttpPost]
    public IActionResult TestConnection()
    {
        Console.WriteLine("--> Inbound POST # Product Service");
        return Ok("Inbound Test of products controller");
    }
}
