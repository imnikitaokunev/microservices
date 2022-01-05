using System.ComponentModel.DataAnnotations;

namespace ProductService.Models;

public class Brand
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int ExternalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
