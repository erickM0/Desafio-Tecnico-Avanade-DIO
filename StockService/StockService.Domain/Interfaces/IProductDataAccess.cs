using StockService.Domain.Entities;
namespace StockService.Domain.Interfaces;

public interface IProductDataAccess
{
    Task<Product?> GetBySku(string sku);
    Task<List<Product>> GetList(int? page);
    Task<bool> Create(Product product);
    Task<bool> Update(Product product);  
}