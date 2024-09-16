using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Services.Abstract;

public interface IAttiributeValueService
{
    Task<AttiributeValue> AddAsync(AttiributeValue attiributeValue);
    Task<AttiributeValue> UpdateAsync(AttiributeValue attiributeValue);
    Task<AttiributeValue> GetAsync(Expression<Func<AttiributeValue, bool>> predicate, Func<IQueryable<AttiributeValue>, IIncludableQueryable<AttiributeValue, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
}
