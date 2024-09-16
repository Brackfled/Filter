using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Services.Abstract;

public interface ISubCategoryService
{
    Task<SubCategory> AddAsync(SubCategory subCategory);
    Task<SubCategory> GetAsync(Expression<Func<SubCategory, bool>> predicate, Func<IQueryable<SubCategory>, IIncludableQueryable<SubCategory, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
    Task<ICollection<SubCategory>> GetAllAsync(Expression<Func<SubCategory, bool>>? predicate = null, Func<IQueryable<SubCategory>, IIncludableQueryable<SubCategory, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
}
