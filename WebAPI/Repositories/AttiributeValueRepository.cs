using Microsoft.AspNetCore.Authentication;
using NArchitecture.Core.Persistence.Repositories;
using WebAPI.Contexts;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Repositories;

public class AttiributeValueRepository: EfRepositoryBase<AttiributeValue, int, BaseContext>, IAttiributeValueRepository
{
    public AttiributeValueRepository(BaseContext context):base(context)
    {
        
    }
}
