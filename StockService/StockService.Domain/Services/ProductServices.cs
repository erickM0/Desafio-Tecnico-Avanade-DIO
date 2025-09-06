using StockService.Domain.Entities;
using StockService.Domain.Interfaces;

namespace StockService.Domain.Services;

public class ProductServices
{

    private readonly IProductDataAccess _dataAccess;

    public ProductServices(IProductDataAccess productDataAccess)
    {
        _dataAccess = productDataAccess;
    }

    public async Task<Product?> GetBySku(string sku)
    {
        return await _dataAccess.GetBySku(sku);
    }

    public async Task<List<Product>> GetProducts(int? page)
    {
        return await _dataAccess.GetList(page);
    } 
    

    

    

}