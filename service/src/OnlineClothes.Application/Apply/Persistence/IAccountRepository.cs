using OnlineClothes.Application.Apply.Repositories.Abstracts;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Application.Apply.Persistence;

public interface IAccountRepository : IEfCoreRepository<AccountUser, int>
{
	Task<AccountUser?> GetByEmail(string email, CancellationToken cancellationToken = default);
}
