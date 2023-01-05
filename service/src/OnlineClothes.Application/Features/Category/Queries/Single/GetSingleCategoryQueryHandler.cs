using AutoMapper;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Category.Queries.Single;

public class
	GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, JsonApiResponse<CategoryDto>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public GetSingleCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<CategoryDto>> Handle(GetSingleCategoryQuery request,
		CancellationToken cancellationToken)
	{
		var entry = await _categoryRepository.GetByIntKey(request.Id, cancellationToken);
		return JsonApiResponse<CategoryDto>.Success(data: _mapper.Map<CategoryDto>(entry));
	}
}
