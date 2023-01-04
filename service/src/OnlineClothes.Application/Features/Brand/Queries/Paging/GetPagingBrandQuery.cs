using OnlineClothes.Application.Features.Brand.Queries.Single;
using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Brand.Queries.Paging;

public class GetPagingBrandQuery : PagingRequest, IRequest<JsonApiResponse<PagingModel<GetSingleBrandQueryResultModel>>>
{
	public GetPagingBrandQuery(PagingRequest page) : base(page)
	{
	}
}
