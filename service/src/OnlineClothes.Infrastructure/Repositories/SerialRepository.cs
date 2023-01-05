using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Infrastructure.Repositories;

internal class SerialRepository : EfCoreRepositoryBase<Serial, int>, ISerialRepository
{
	public SerialRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
