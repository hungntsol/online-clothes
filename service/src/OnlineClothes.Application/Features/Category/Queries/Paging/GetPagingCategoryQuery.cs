using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Category.Queries.Paging;

public class GetPagingCategoryQuery : PagingRequest, IRequest<JsonApiResponse<PagingModel<CategoryDto>>>
{
	public GetPagingCategoryQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
	{
	}

	public GetPagingCategoryQuery(PagingRequest pagingRequest) : this(pagingRequest.PageIndex, pagingRequest.PageSize)
	{
	}
}
