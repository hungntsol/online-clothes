namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class GetSingleBrandQuery : IRequest<JsonApiResponse<BrandDto>>
{
	public GetSingleBrandQuery(string id)
	{
		Id = id;
	}

	public string Id { get; init; }
}
