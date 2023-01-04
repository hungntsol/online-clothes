using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

internal class BrandRepository : EfCoreRepositoryBase<ClotheBrand, string>, IBrandRepository
{
	public BrandRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
