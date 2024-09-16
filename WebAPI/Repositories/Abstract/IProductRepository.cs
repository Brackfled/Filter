using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Repositories.Abstract;

public interface IProductRepository: IAsyncRepository<Product, int>, IRepository<Product, int>
{
    Task<ICollection<Product>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
}
