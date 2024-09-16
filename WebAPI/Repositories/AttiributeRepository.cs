using Microsoft.AspNetCore.Authentication;
using NArchitecture.Core.Persistence.Repositories;
using WebAPI.Contexts;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Repositories;

public class AttiributeRepository: EfRepositoryBase<Attiribute, int, BaseContext>, IAttiributeRepository
{
    public AttiributeRepository(BaseContext context):base(context)
    {
        
    }
}
