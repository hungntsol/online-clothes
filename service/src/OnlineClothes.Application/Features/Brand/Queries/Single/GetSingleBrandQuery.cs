using OnlineClothes.Application.Mapping.ViewModels;

namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class GetSingleBrandQuery : IRequest<JsonApiResponse<BrandViewModel>>
{
	public GetSingleBrandQuery(int id)
	{
		Id = id;
	}

	public int Id { get; init; }
}
