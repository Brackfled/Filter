using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;
using WebAPI.Services.Abstract;

namespace WebAPI.Services;

public class SubCategoryManager : ISubCategoryService
{
    private readonly ISubCategoryRepository _subCategoryRepository;

    public SubCategoryManager(ISubCategoryRepository subCategoryRepository)
    {
        _subCategoryRepository = subCategoryRepository;
    }

    public async Task<SubCategory> AddAsync(SubCategory subCategory)
    {
        SubCategory addedSubCategory = await _subCategoryRepository.AddAsync(subCategory);
        return addedSubCategory;
    }

    public async Task<ICollection<SubCategory>> GetAllAsync(Expression<Func<SubCategory, bool>>? predicate = null, Func<IQueryable<SubCategory>, IIncludableQueryable<SubCategory, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        ICollection<SubCategory>? subCategories = await _subCategoryRepository.GetAllAsync(predicate,include,withDeleted,enableTracking,cancellationToken);
        return subCategories;
    }

    public async Task<SubCategory> GetAsync(Expression<Func<SubCategory, bool>> predicate, Func<IQueryable<SubCategory>, IIncludableQueryable<SubCategory, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        SubCategory? subCategory = await _subCategoryRepository.GetAsync(predicate,include,withDeleted, enableTracking,cancellationToken);
        return subCategory;
    }
}
