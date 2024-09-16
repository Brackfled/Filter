using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;
using WebAPI.Contexts;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Repositories;

public class ProductRepository: EfRepositoryBase<Product, int, BaseContext>, IProductRepository
{
    public ProductRepository(BaseContext context):base(context)
    {
        
    }

    public async Task<ICollection<Product>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = Query();
        if(!enableTracking)
            query = query.AsNoTracking();
        if(predicate != null)
            query = query.Where(predicate);
        if (include != null)
            query = include(query);
        if(withDeleted)
            query = query.IgnoreQueryFilters();

        return await query.ToListAsync(cancellationToken);
    }
}
