using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Application.Features.Serial.Queries.Paging;

public class GetPagingSerialQuery : PagingRequest, IRequest<JsonApiResponse<PagingModel<SerialDto>>>
{
	public GetPagingSerialQuery(PagingRequest page) : base(page)
	{
	}
}
