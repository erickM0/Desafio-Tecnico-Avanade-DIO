
namespace StockService.Domain.DTO;

public class ProductDto
{
    public required string SKU { get; set; }
    public required string Name { get; set; }
    public required bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModifiedAt { get; set; }
}