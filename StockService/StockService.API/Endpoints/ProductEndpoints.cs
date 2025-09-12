using StockService.Domain.Services;
using StockService.Domain.Entities;
using StockService.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace StockService.API.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async ([FromQuery]int? page, [FromServices]ProductServices productServices) =>
        {
            int pagination = page ?? 1;
            List<Product> products = await productServices.GetProducts(pagination);
            var productDtoList = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                Sku = p.Sku,
                Description = p.Description,
            }).ToList();
            return Results.Ok(productDtoList);
        })
        .WithName("products");


        app.MapPost("/products", async ([FromBody]ProductDto productDto, [FromServices]ProductServices productServices) =>
        {
            var product = new Product
            {
                Sku = productDto.Sku,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
            };
            bool response = await productServices.Create(product);

            return Results.Ok(response);
        }).
        WithName("Create product");
    }
}
