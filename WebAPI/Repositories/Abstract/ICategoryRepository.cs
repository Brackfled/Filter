using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Repositories.Abstract;

public interface ICategoryRepository: IAsyncRepository<Category, int>, IRepository<Category, int>
{
    Task<ICollection<Category>> GetAllAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
}
