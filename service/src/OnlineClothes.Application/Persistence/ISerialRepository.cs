using OnlineClothes.Application.Persistence.Schemas.Serials;

namespace OnlineClothes.Application.Persistence;

public interface ISerialRepository : IEfCoreRepository<Serial, int>
{
	Task<Serial> UpdateCategoryNavigationAsync(int id, UpdateCategoryNavigationRequest request);
}
