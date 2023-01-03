using OnlineClothes.Application.Apply.Repositories.Abstracts;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Application.Apply.Persistence;

public interface IAccountUserRepository : IEfCoreRepository<AccountUser, int>
{
	Task<AccountUser?> GetByEmail(string email, CancellationToken cancellationToken = default);
}
