using StockService.Domain.Entities;
using StockService.API.DTOs;

namespace StockService.API.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async (int? page, ProductServices productServices) =>
        {
            int pagination = page ?? 1;
            var products = await productServices.GetProducts(pagination);
            return Results.Ok(products);
        })
        .WithName("products");

        app.MapGet("/products/{sku}", async (string sku, ProductServices productServices) =>
        {
            var products = await productServices.GetBySku(sku);
            return Results.Ok(products);
        })
        .WithName("products");

        app.MapPost("/products", async (ProductDto productDto, ProductServices productServices) =>
        {
            var product = new Product
            {
                Sku = productDto.Sku,
                Name = productDto.Name,
                Description = productDto.Description
            };

            return Result.OK(productServices.Create(product));
        }).
        WithName("products");
    }
}
