using System.Linq.Expressions;
using AutoMapper;
using OnlineClothes.Application.Commons;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;

namespace OnlineClothes.Application.Features.Product.Queries.Paging;

public class
	GetPagingProductQueryHandler : IRequestHandler<GetPagingProductQuery,
		JsonApiResponse<PagingModel<ProductBasicDto>>>
{
	private readonly ILogger<GetPagingProductQueryHandler> _logger;
	private readonly IMapper _mapper;
	private readonly IProductRepository _productRepository;

	public GetPagingProductQueryHandler(
		IProductRepository productRepository,
		ILogger<GetPagingProductQueryHandler> logger,
		IMapper mapper)
	{
		_productRepository = productRepository;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<PagingModel<ProductBasicDto>>> Handle(GetPagingProductQuery request,
		CancellationToken cancellationToken)
	{
		var viewModel = await _productRepository.PagingAsync(
			PreSearchQueryable(request),
			new PagingRequest(request.PageIndex, request.PageSize),
			ProjectToTypeSelector(),
			PreOrderQueryable(request),
			cancellationToken);

		return JsonApiResponse<PagingModel<ProductBasicDto>>.Success(data: viewModel);
	}

	private static FilterBuilder<Domain.Entities.Aggregate.Product> PreSearchQueryable(GetPagingProductQuery request)
	{
		// default will query publish product
		var filterBuilder = new FilterBuilder<Domain.Entities.Aggregate.Product>(q => q.IsPublish && q.InStock > 0);

		AppendFilterKeyword(request, filterBuilder);
		AppendFilterCategory(request, filterBuilder);
		AppendFilterBrand(request, filterBuilder);

		return filterBuilder;
	}

	private static void AppendFilterCategory(GetPagingProductQuery request,
		FilterBuilder<Domain.Entities.Aggregate.Product> filterBuilder)
	{
		if (request.CategoryId is not null && request.CategoryId != 0)
		{
			filterBuilder.And(product => product.Categories.Any(category => category.Id == request.CategoryId));
		}
	}

	private static void AppendFilterKeyword(GetPagingProductQuery request,
		FilterBuilder<Domain.Entities.Aggregate.Product> filterBuilder)
	{
		if (!string.IsNullOrEmpty(request.Keyword))
		{
			filterBuilder.And(product => product.Name.ToLower().Contains(request.Keyword.ToLower()));
		}
	}

	private static void AppendFilterBrand(GetPagingProductQuery request,
		FilterBuilder<Domain.Entities.Aggregate.Product> filterBuilder)
	{
		if (request.BrandId is not null && request.BrandId != 0)
		{
			filterBuilder.And(product => product.BrandId == request.BrandId);
		}
	}

	private static Func<IQueryable<Domain.Entities.Aggregate.Product>, IQueryable<ProductBasicDto>>
		ProjectToTypeSelector()
	{
		return product => product.Select(q => ProductBasicDto.ToModel(q));
	}

	private static
		Func<IQueryable<Domain.Entities.Aggregate.Product>, IOrderedQueryable<Domain.Entities.Aggregate.Product>>
		PreOrderQueryable(GetPagingProductQuery request)
	{
		return Check.ShouldOrderDescending(request.OrderBy)
			? query => query.OrderByDescending(SortByDefinition(request.SortBy))
			: query => query.OrderBy(SortByDefinition(request.SortBy));
	}

	private static Expression<Func<Domain.Entities.Aggregate.Product, object>> SortByDefinition(string? sortBy)
	{
		return sortBy?.ToLower() switch
		{
			"price" => product => product.Price,
			"name" => product => product.Name,
			_ => product => product.Name
		};
	}

	// Include all check method handler
	private static class Check
	{
		// Default order behaviour (high => low)
		public static bool ShouldOrderDescending(string? orderBy)
		{
			return string.IsNullOrEmpty(orderBy) || orderBy.Equals(QuerySortOrder.Descending);
		}
	}
}
