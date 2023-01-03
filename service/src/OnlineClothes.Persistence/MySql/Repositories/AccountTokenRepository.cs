using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Persistence.MySql.Context;

namespace OnlineClothes.Persistence.MySql.Repositories;

public class AccountTokenRepository : EfCoreRepositoryBase<AccountTokenCode, int>, IAccountTokenRepository
{
	public AccountTokenRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
