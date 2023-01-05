namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class GetSingleBrandQuery : IRequest<JsonApiResponse<BrandDto>>
{
	public GetSingleBrandQuery(int id)
	{
		Id = id;
	}

	public int Id { get; init; }
}
