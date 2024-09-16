using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;
using WebAPI.Contexts;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Repositories;

public class SubCategoryRepository: EfRepositoryBase<SubCategory, int, BaseContext>, ISubCategoryRepository
{
    public SubCategoryRepository(BaseContext context):base(context)
    {
        
    }

    public async Task<ICollection<SubCategory>> GetAllAsync(Expression<Func<SubCategory, bool>>? predicate = null, Func<IQueryable<SubCategory>, IIncludableQueryable<SubCategory, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<SubCategory> subCategories = Query();

        if (!enableTracking)
            subCategories = subCategories.AsNoTracking();
        if(predicate != null)
            subCategories = subCategories.Where(predicate);
        if (include != null)
            subCategories = include(subCategories);
        if(withDeleted)
            subCategories = subCategories.IgnoreQueryFilters();

        return await subCategories.ToListAsync();
    }
}
