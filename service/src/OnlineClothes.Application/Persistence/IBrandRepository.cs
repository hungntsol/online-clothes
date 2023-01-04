using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Application.Persistence;

public interface IBrandRepository : IEfCoreRepository<ClotheBrand, string>
{
}
