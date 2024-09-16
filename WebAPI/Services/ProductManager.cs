using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Entities.Dtos;
using WebAPI.Repositories.Abstract;
using WebAPI.Services.Abstract;

namespace WebAPI.Services;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IAttiributeService _attiributeService;
    private readonly IAttiributeValueService _attiributeValueService;

    public ProductManager(IProductRepository productRepository, IAttiributeService attiributeService, IAttiributeValueService attiributeValueService)
    {
        _productRepository = productRepository;
        _attiributeService = attiributeService;
        _attiributeValueService = attiributeValueService;
    }

    public async Task<Product> CreateProductAsync(CreateProductDto createProductDto)
    {
        Product product = new()
        {
            CategoryId = createProductDto.CategoryId,
            SubCategoryId = createProductDto.SubCategoryId,
            Name = createProductDto.Name,
            AttiributeValues = new List<AttiributeValue>()
        };

        Product addedProduct = await _productRepository.AddAsync(product);

        foreach (CreateProductWithAttiributeDto dto in createProductDto.CreateProductWithAttiributeDtos)
        {
            Attiribute attiribute = new();
            AttiributeValue attiributeValue = new();

            if(dto.AttiributeId == null && dto.AttiributeName != null)
            {
                attiribute = await _attiributeService.AddAsync(new Attiribute 
                {
                    Name = dto.AttiributeName
                });
            } else if (dto.AttiributeId != null)
            {
                attiribute = await _attiributeService.GetAsync(a => a.Id == dto.AttiributeId);
            }

            if(dto.AttiributeValueId == null && dto.Value != null)
            {
                attiributeValue = await _attiributeValueService.AddAsync(new AttiributeValue
                {
                    AttiributeId = attiribute.Id,
                    Value = dto.Value,
                    Products = new List<Product>()
                });
            } else if(dto.AttiributeValueId != null)
            {
                attiributeValue = await _attiributeValueService.GetAsync(av => av.Id == dto.AttiributeValueId);
            }

            addedProduct.AttiributeValues.Add(attiributeValue);
            await _productRepository.UpdateAsync(addedProduct);

            attiributeValue.Products.Add(addedProduct);
            await _attiributeValueService.UpdateAsync(attiributeValue);
        }

        return addedProduct;
    }

    public async Task<ICollection<Product>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        ICollection<Product>? products = await _productRepository.GetAllAsync(predicate,include,withDeleted,enableTracking,cancellationToken);
        return products;
    }

    public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        Product? product = await _productRepository.GetAsync(predicate,include,withDeleted,enableTracking,cancellationToken);
        return product;
    }
}
