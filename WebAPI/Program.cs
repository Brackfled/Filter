
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.DependencyInjection;
using NArchitecture.Core.Persistence.WebApi;
using WebAPI.Contexts;
using WebAPI.Repositories;
using WebAPI.Repositories.Abstract;
using WebAPI.Services;
using WebAPI.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FilterDb")));
builder.Services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseContext>());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAttiributeRepository, AttiributeRepository>();
builder.Services.AddScoped<IAttiributeValueRepository, AttiributeValueRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IAttiributeService, AttiributeManager>();
builder.Services.AddScoped<IAttiributeValueService, AttiributeValueManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDbMigrationApplier();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
