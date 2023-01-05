using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

internal class BrandRepository : EfCoreRepositoryBase<Brand, string>, IBrandRepository
{
	public BrandRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
