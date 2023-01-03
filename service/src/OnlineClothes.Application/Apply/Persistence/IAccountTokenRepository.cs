using OnlineClothes.Application.Apply.Repositories.Abstracts;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Application.Apply.Persistence;

public interface IAccountTokenRepository : IEfCoreRepository<AccountTokenCode, int>
{
}
