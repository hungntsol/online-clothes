using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Persistence.Schemas.Serials;

namespace OnlineClothes.Infrastructure.Repositories;

internal class SerialRepository : EfCoreRepositoryBase<Serial, int>, ISerialRepository
{
	public SerialRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public override async Task<Serial> GetByIntKey(int key, CancellationToken cancellationToken = default)
	{
		var entry = await AsQueryable()
			.Include(serial => serial.SerialCategories)
			.ThenInclude(sc => sc.Category)
			.FirstAsync(q => q.Id.Equals(key), cancellationToken);

		return entry;
	}

	public async Task<Serial> UpdateCategoryNavigationAsync(int id, UpdateCategoryNavigationRequest request)
	{
		var serial = await AsQueryable()
			.Include(q => q.SerialCategories)
			.FirstAsync(q => q.Id.Equals(id));

		Update(serial);

		EditSerial(request, serial);

		return serial;
	}

	private static void EditSerial(UpdateCategoryNavigationRequest request, Serial serial)
	{
		serial.AssignCategoryNavigation(request.CategoryIds);
		serial.SetName(request.Name);
		serial.SetBrandId(request.BrandId);
		serial.Type = request.ClotheType;
	}
}
