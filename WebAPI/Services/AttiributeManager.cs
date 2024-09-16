using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;
using WebAPI.Services.Abstract;

namespace WebAPI.Services;

public class AttiributeManager : IAttiributeService
{
    private readonly IAttiributeRepository _attiributeRepository;

    public AttiributeManager(IAttiributeRepository attiributeRepository)
    {
        _attiributeRepository = attiributeRepository;
    }

    public async Task<Attiribute> AddAsync(Attiribute attiribute)
    {
        Attiribute addedAttiribute = await _attiributeRepository.AddAsync(attiribute);
        return addedAttiribute;
    }

    public async Task<Attiribute> GetAsync(Expression<Func<Attiribute, bool>> predicate, Func<IQueryable<Attiribute>, IIncludableQueryable<Attiribute, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        Attiribute? attiribute = await _attiributeRepository.GetAsync(predicate,include,withDeleted,enableTracking,cancellationToken);
        return attiribute;
    }
}
