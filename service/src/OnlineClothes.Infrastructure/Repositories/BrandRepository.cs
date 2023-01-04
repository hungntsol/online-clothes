using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Infrastructure.Repositories;

internal class BrandRepository : EfCoreRepositoryBase<ClotheBrand, string>, IBrandRepository
{
	public BrandRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
