using OnlineClothes.Application.Features.Category.Queries.Single;
using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Category.Queries.Paging;

public class GetPagingCategoryQuery : PagingRequest,
	IRequest<JsonApiResponse<PagingModel<GetSingleCategoryQueryResultModel>>>
{
	public GetPagingCategoryQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
	{
	}

	public GetPagingCategoryQuery(PagingRequest pagingRequest) : this(pagingRequest.PageIndex, pagingRequest.PageSize)
	{
	}
}
