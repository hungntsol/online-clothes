using OnlineClothes.Application.Persistence.Abstracts;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Application.Persistence;

public interface IAccountRepository : IEfCoreRepository<AccountUser, int>
{
	Task<AccountUser?> GetByEmail(string email, CancellationToken cancellationToken = default);
}
