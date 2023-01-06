using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Persistence.Schemas.Products;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Utilities.Extensions;

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

	public async Task<Product> GetBySkuAsync(string sku, CancellationToken cancellationToken = default)
	{
		return await AsQueryable()
			.FirstAsync(q => q.Sku.Equals(sku), cancellationToken: cancellationToken);
	}

	public async Task<Product?> CreateOneAsync(
		PutProductInRepoObject @object,
		CancellationToken cancellationToken = default)
	{
		var product = _mapper.Map<PutProductInRepoObject, Product>(@object);

		var navigationCategories = await _categoryRepository.FindAsync(
			FilterBuilder<Category>.Where(q => @object.CategoryIds.Contains(q.Id)),
			cancellationToken: cancellationToken);

		_categoryRepository.Table.AttachRange(navigationCategories);

		product.Categories = navigationCategories;
		await AddAsync(product, cancellationToken: cancellationToken);

		return product;
	}

	public async Task EditOneAsync(
		int id,
		PutProductInRepoObject @object,
		CancellationToken cancellationToken = default)
	{
		var product = await AsQueryable()
			.Include(q => q.Categories)
			.FirstAsync(q => q.Id == id, cancellationToken);

		var currentProductCategoryIds = product.Categories.SelectList(q => q.Id);
		var newIncomeCategoryIds = @object.CategoryIds.Except(currentProductCategoryIds).ToList();

		Update(product);
		_mapper.Map(@object, product);

		if (newIncomeCategoryIds.Count == 0)
		{
			return; // skip if no category change
		}

		var navigationCategories = await _categoryRepository.FindAsync(
			FilterBuilder<Category>.Where(q => newIncomeCategoryIds.Contains(q.Id)),
			cancellationToken: cancellationToken);

		var productCategoriesList = product.Categories.ToList();
		productCategoriesList.RemoveAll(q => !@object.CategoryIds.Contains(q.Id));
		productCategoriesList.AddRange(navigationCategories);

		// re-assign
		product.Categories = productCategoriesList;
	}
}
