using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Infrastructure.Repositories;

public class CategoryRepository : EfCoreRepositoryBase<ClotheCategory, int>, ICategoryRepository
{
	public CategoryRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
