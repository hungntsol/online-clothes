using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

public class ProductRepository : EfCoreRepositoryBase<Product, int>, IProductRepository
{
	public ProductRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
