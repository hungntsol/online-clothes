using OnlineClothes.Application.Commons;
using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Product.Queries.Listing;

public class ListingProductQuery : PagingRequest,
	IRequest<JsonApiResponse<PagingModel<ListingProductQueryResultModel>>>
{
	public ListingProductQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
	{
	}

	// search query
	public string? Q { get; set; }

	// sort order
	public string Sort { get; set; } = QuerySortOrder.Ascending;

	// sort by
	public string SortBy { get; set; } = "name";

	public string? Category { get; set; }
}
