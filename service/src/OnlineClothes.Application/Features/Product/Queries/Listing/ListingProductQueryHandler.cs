﻿using OnlineClothes.Application.Commons;
using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Product.Queries.Listing;

public class
	ListingProductQueryHandler : IRequestHandler<ListingProductQuery,
		JsonApiResponse<PagingModel<ListingProductQueryResultModel>>>
{
	//private readonly ILogger<ListingProductQueryHandler> _logger;
	//private readonly IProductRepository _productRepository;

	//public ListingProductQueryHandler(IProductRepository productRepository, ILogger<ListingProductQueryHandler> logger)
	//{
	//	_productRepository = productRepository;
	//	_logger = logger;
	//}

	public async Task<JsonApiResponse<PagingModel<ListingProductQueryResultModel>>> Handle(ListingProductQuery request,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();

		//var filterDef = PrepareSearchQuery(request);

		//var productsCursorTask = _productRepository.FindAsync(filterDef, PrepareFindOptions(request),
		//	cancellationToken);
		//var countTotalTask = _productRepository.CountAsync(filterDef, cancellationToken);

		//await Task.WhenAll(productsCursorTask, countTotalTask);

		//var data = (await productsCursorTask.Result.ToListAsync(cancellationToken))
		//	.Select(ListingProductQueryResultModel.Create).ToList();

		//var viewModel = new PagingModel<ListingProductQueryResultModel>(countTotalTask.Result, data);

		//return JsonApiResponse<PagingModel<ListingProductQueryResultModel>>.Success(data: viewModel);
	}

	//private static FilterBuilder<ProductClothe> PrepareSearchQuery(ListingProductQuery request)
	//{
	//	var filter = new FilterBuilder<ProductClothe>(q => !q.IsDeleted);
	//	if (!string.IsNullOrEmpty(request.Q))
	//	{
	//		filter.And(q => q.Name.ToLower().Contains(request.Q.ToLower()));
	//	}

	//	if (!string.IsNullOrEmpty(request.Category))
	//	{
	//		filter.And(q => q.Categories.Contains(request.Category));
	//	}

	//	return filter;
	//}

	//private static FindOptions<ProductClothe, ProductClothe> PrepareFindOptions(ListingProductQuery request)
	//{
	//	var sortField = request.SortBy;
	//	var findOptions = new FindOptions<ProductClothe, ProductClothe>
	//	{
	//		Limit = request.PageSize,
	//		Skip = (request.PageIndex - 1) * request.PageSize,
	//		Sort = new BsonDocument { { sortField, GetSortDirect(request.Sort) } }
	//	};

	//	return findOptions;
	//}

	private static int GetSortDirect(string sort)
	{
		return sort switch
		{
			QuerySortOrder.Ascending => 1, // giam dan
			QuerySortOrder.Descending => -1, // tang dan
			_ => 1
		};
	}
}
