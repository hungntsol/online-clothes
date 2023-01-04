using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

internal class CategoryRepository : EfCoreRepositoryBase<ClotheCategory, int>, ICategoryRepository
{
	public CategoryRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
