using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Persistence.Schemas.Products;

namespace OnlineClothes.Infrastructure.Repositories;

public class ProductRepository : EfCoreRepositoryBase<Product, int>, IProductRepository
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;


	public ProductRepository(AppDbContext dbContext,
		ICategoryRepository categoryRepository,
		IMapper mapper) : base(dbContext)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<Product?> CreateOneAsync(CreateProductObjectSchema objectSchema,
		CancellationToken cancellationToken = default)
	{
		var product = _mapper.Map<CreateProductObjectSchema, Product>(objectSchema);
		var navigationCategories = await _categoryRepository
			.AsQueryable()
			.Where(q => objectSchema.CategoryIds.Contains(q.Id))
			.ToListAsync(cancellationToken);

		_categoryRepository.Table.AttachRange(navigationCategories);

		product.Categories = navigationCategories;
		await AddAsync(product, cancellationToken: cancellationToken);

		return product;
	}
}
