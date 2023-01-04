using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

internal class SerialRepository : EfCoreRepositoryBase<ProductSerial, int>, ISerialRepository
{
	public SerialRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
