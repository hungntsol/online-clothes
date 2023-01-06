using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Services.UserContext;

namespace OnlineClothes.Infrastructure.Repositories;

public class CartRepository : EfCoreRepositoryBase<AccountCart, int>, ICartRepository
{
	private readonly IUserContext _userContext;

	public CartRepository(AppDbContext dbContext, IUserContext userContext) : base(dbContext)
	{
		_userContext = userContext;
	}

	public async Task<AccountCart> GetCurrentCart()
	{
		var cart = await AsQueryable()
			.Include(q => q.Items)
			.ThenInclude(q => q.Product)
			.FirstAsync(q => q.AccountId.Equals(_userContext.GetNameIdentifier()));

		return cart;
	}
}
