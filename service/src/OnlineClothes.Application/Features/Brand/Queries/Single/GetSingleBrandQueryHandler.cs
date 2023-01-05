using AutoMapper;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class
	GetSingleBrandQueryHandler : IRequestHandler<GetSingleBrandQuery, JsonApiResponse<BrandDto>>
{
	private readonly IBrandRepository _brandRepository;
	private readonly IMapper _mapper;

	public GetSingleBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
	{
		_brandRepository = brandRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<BrandDto>> Handle(GetSingleBrandQuery request,
		CancellationToken cancellationToken)
	{
		var entry = await _brandRepository.GetByIntKey(request.Id, cancellationToken);

		return JsonApiResponse<BrandDto>.Success(data: _mapper.Map<BrandDto>(entry));
	}
}
