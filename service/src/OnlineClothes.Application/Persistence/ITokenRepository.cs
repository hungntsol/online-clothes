using OnlineClothes.Application.Persistence.Abstracts;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Application.Persistence;

public interface ITokenRepository : IEfCoreRepository<AccountTokenCode, int>
{
}
