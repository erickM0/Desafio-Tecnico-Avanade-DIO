namespace StockService.Domain.Services;

public class ProductServices
{
    private readonly DbContext _productsDbContext;
    public ProductServices(DbContext dbContext)
    {
        _productsDbContext = dbContext;
    }

    public  async Task<List<Product>> ListProducts(int? page)
    {
        var query = _productsDbContext.Products.AsQueryable();
        int pageInt = null ? (int)page : 1;
        int itemsPerPage = 100;

        query = query
                .Skip((pageInt - 1) * itemsPerPage)
                .Take(itemsPerPage);

        return await query.ToListAsync();

    }

    public async Task<bool> Create(Product product)
    {
        _productsDbContext.Product.AddAsync(product);

        return await _productsDbContext.SaveChangesAsync() > 0;
    }

}