using NArchitecture.Core.Persistence.Repositories;
using WebAPI.Entities;

namespace WebAPI.Repositories.Abstract;

public interface IAttiributeRepository: IAsyncRepository<Attiribute, int>, IRepository<Attiribute, int>
{
}
