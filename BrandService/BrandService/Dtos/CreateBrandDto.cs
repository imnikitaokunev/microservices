using System.ComponentModel.DataAnnotations;

namespace BrandService.Dtos;

public class CreateBrandDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    public string Description { get; set; }
}
