using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Application.Persistence;

public interface ICategoryRepository : IEfCoreRepository<ClotheCategory, int>
{
}
