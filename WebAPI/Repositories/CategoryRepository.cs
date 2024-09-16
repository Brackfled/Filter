using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using WebAPI.Contexts;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Repositories;

public class CategoryRepository: EfRepositoryBase<Category, int, BaseContext>, ICategoryRepository
{
    public CategoryRepository(BaseContext context):base(context)
    {
        
    }

    public async Task<ICollection<Category>> GetAllAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Category> categories = Query();
        if (predicate != null)
            categories = categories.Where(predicate);
        if (include != null)
            categories = include(categories);
        if (withDeleted)
            categories = categories.IgnoreQueryFilters();
        
        return await categories.ToListAsync(cancellationToken);

    }
}
