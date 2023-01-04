using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Persistence.MySql.Context;

namespace OnlineClothes.Persistence.MySql.Repositories;

public class TokenRepository : EfCoreRepositoryBase<AccountTokenCode, int>, ITokenRepository
{
	public TokenRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
