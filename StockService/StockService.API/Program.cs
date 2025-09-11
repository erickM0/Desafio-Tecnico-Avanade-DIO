using StockService.Infra.DB;
using StockService.Domain.Services;
using StockService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using StockService.Infra.DB.Repositories;
using StockService.API.Endpoints;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IProductDataAccess, ProductRepository>();

builder.Services.AddScoped<ProductServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();   
}

app.MapProductEndpoints();


app.Run();

