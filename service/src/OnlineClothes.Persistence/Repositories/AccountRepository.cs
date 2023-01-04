using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Persistence.Context;

namespace OnlineClothes.Persistence.Repositories;

public class AccountRepository : EfCoreRepositoryBase<AccountUser, int>, IAccountRepository
{
	public AccountRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<AccountUser?> GetByEmail(string email, CancellationToken cancellationToken = default)
	{
		var entry = await DbSet.FirstOrDefaultAsync(q => q.Email.Equals(email), cancellationToken: cancellationToken);
		return entry;
	}
}
