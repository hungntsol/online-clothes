using MapsterMapper;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Category.Queries.Single;

public class
	GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery,
		JsonApiResponse<GetSingleCategoryQueryResultModel>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public GetSingleCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<GetSingleCategoryQueryResultModel>> Handle(GetSingleCategoryQuery request,
		CancellationToken cancellationToken)
	{
		var entry = await _categoryRepository.GetByIntKey(request.Id, cancellationToken);
		return JsonApiResponse<GetSingleCategoryQueryResultModel>.Success(
			data: _mapper.Map<GetSingleCategoryQueryResultModel>(entry));
	}
}
