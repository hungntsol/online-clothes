using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Persistence.Context;

namespace OnlineClothes.Persistence.Repositories;

public class TokenRepository : EfCoreRepositoryBase<AccountTokenCode, int>, ITokenRepository
{
	public TokenRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
