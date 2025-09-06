using StockService.Domain.Interfaces;
using StockService.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace StockService.Infra.DB.Repositories;

public class ProductRepository : IProductDataAccess
{
    private readonly StockDbContext _context;
    public ProductRepository(StockDbContext context)
    {
        _context = context;
    }
    public async Task<Product?> GetBySku(string sku)
    {
        return await _context.Products
                                    .Where(prod => prod.Sku == sku)
                                    .FirstOrDefaultAsync();
    }
    public async Task<List<Product>> GetList(int? page)
    {
        var query = _context.Products.AsQueryable();
        int pageInt = page ?? 1;
        int itemsPerPage = 100;

        query = query.Skip((pageInt - 1) * itemsPerPage).Take(itemsPerPage);

        return await query.ToListAsync();

    }
    public async Task<bool> Create(Product product)
    {
        _context.Products.Add(product);

        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Update(Product product)
    {
        _context.Products.Update(product);

        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if(product == null) return false;

        _context.Products.Remove(product);
        return await _context.SaveChangesAsync() > 0;
    }
}