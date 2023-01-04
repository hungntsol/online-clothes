namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class GetSingleBrandQuery : IRequest<JsonApiResponse<GetSingleBrandQueryResultModel>>
{
	public GetSingleBrandQuery(string id)
	{
		Id = id;
	}

	public string Id { get; init; }
}
