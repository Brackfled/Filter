using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;
using WebAPI.Services.Abstract;

namespace WebAPI.Services;

public class AttiributeValueManager : IAttiributeValueService
{
    private readonly IAttiributeValueRepository _attiributeValueRepository;

    public AttiributeValueManager(IAttiributeValueRepository attiributeValueRepository)
    {
        _attiributeValueRepository = attiributeValueRepository;
    }

    public async Task<AttiributeValue> AddAsync(AttiributeValue attiributeValue)
    {
        AttiributeValue addedAttiributeValue = await _attiributeValueRepository.AddAsync(attiributeValue);
        return addedAttiributeValue;
    }

    public async Task<AttiributeValue> GetAsync(Expression<Func<AttiributeValue, bool>> predicate, Func<IQueryable<AttiributeValue>, IIncludableQueryable<AttiributeValue, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        AttiributeValue? attiributeValue = await _attiributeValueRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attiributeValue;
    }

    public async Task<AttiributeValue> UpdateAsync(AttiributeValue attiributeValue)
    {
        AttiributeValue updatedAttiributeValue = await _attiributeValueRepository.UpdateAsync(attiributeValue);
        return updatedAttiributeValue;
    }
}
