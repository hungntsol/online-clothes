using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Persistence.MySql.Context;

namespace OnlineClothes.Persistence.MySql.Repositories;

public class AccountUserRepository : EfCoreRepositoryBase<AccountUser, int>, IAccountUserRepository
{
	public AccountUserRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<AccountUser?> GetByEmail(string email, CancellationToken cancellationToken = default)
	{
		var entry = await DbSet.FirstOrDefaultAsync(q => q.Email.Equals(email), cancellationToken: cancellationToken);
		return entry;
	}
}
