using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;
using WebAPI.Services.Abstract;

namespace WebAPI.Services;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> AddAsync(Category category)
    {
        Category addedCategory = await _categoryRepository.AddAsync(category);
        return addedCategory;
    }

    public async Task<ICollection<Category>> GetAllAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        ICollection<Category>? categories = await _categoryRepository.GetAllAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categories;
    }

    public async Task<Category> GetAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        Category? category = await _categoryRepository.GetAsync(predicate,include,withDeleted,enableTracking,cancellationToken);
        return category;
    }
}
