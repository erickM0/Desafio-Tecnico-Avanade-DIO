namespace StockService.API.DTOs;

public class ProductDto
{
    public required string Sku { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = "";
    public double Price { get; set; } = default;
}
