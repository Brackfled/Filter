using NArchitecture.Core.Persistence.Repositories;
using WebAPI.Entities;

namespace WebAPI.Repositories.Abstract;

public interface IAttiributeValueRepository: IAsyncRepository<AttiributeValue, int>, IRepository<AttiributeValue, int>
{
}
