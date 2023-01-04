using Mapster;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class
	GetSingleBrandQueryHandler : IRequestHandler<GetSingleBrandQuery, JsonApiResponse<GetSingleBrandQueryResultModel>>
{
	private readonly IBrandRepository _brandRepository;

	public GetSingleBrandQueryHandler(IBrandRepository brandRepository)
	{
		_brandRepository = brandRepository;
	}

	public async Task<JsonApiResponse<GetSingleBrandQueryResultModel>> Handle(GetSingleBrandQuery request,
		CancellationToken cancellationToken)
	{
		var brand = await _brandRepository.GetByKey(request.Id, cancellationToken);

		return JsonApiResponse<GetSingleBrandQueryResultModel>.Success(
			data: brand.Adapt<GetSingleBrandQueryResultModel>());
	}
}
