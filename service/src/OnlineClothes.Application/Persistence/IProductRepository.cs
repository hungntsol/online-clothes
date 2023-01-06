using OnlineClothes.Application.Persistence.Schemas.Products;

namespace OnlineClothes.Application.Persistence;

public interface IProductRepository : IEfCoreRepository<Product, int>
{
	Task<Product?> CreateOneAsync(
		CreateProductObjectSchema objectSchema,
		CancellationToken cancellationToken = default);
}
