using StockService.Infra.DB;
using StockService.Domain.Services;
using StockService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using StockService.Infra.DB.Repositories;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");


builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IProductDataAccess, ProductRepository>();

builder.Services.AddScoped<ProductServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}




app.MapGet("/products", async (ProductServices productServices) =>
{
    var products = await productServices.GetProducts(1);
    return Results.Ok(products);
})
.WithName("products");
app.MapGet("/", () =>
{
    return Results.Ok("{ok}");
})
.WithName("home");

app.Run();

