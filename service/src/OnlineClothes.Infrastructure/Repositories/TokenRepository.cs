using OnlineClothes.Application.Apply.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

public class TokenRepository : EfCoreRepositoryBase<AccountTokenCode, int>, ITokenRepository
{
	public TokenRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
