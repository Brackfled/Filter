using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Services.Abstract;

public interface IAttiributeService
{
    Task<Attiribute> AddAsync(Attiribute attiribute);
    Task<Attiribute> GetAsync(Expression<Func<Attiribute, bool>> predicate, Func<IQueryable<Attiribute>, IIncludableQueryable<Attiribute, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
}
