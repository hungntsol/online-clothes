using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

public class CartRepository : EfCoreRepositoryBase<AccountCart, int>, ICartRepository
{
	public CartRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
