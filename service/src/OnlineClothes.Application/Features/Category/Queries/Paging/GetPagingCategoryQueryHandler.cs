using MapsterMapper;
using OnlineClothes.Application.Features.Category.Queries.Single;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Entities;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;

namespace OnlineClothes.Application.Features.Category.Queries.Paging;

public class GetPagingCategoryQueryHandler : IRequestHandler<GetPagingCategoryQuery,
	JsonApiResponse<PagingModel<GetSingleCategoryQueryResultModel>>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public GetPagingCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
	{
		_mapper = mapper;
		_categoryRepository = categoryRepository;
	}

	public async Task<JsonApiResponse<PagingModel<GetSingleCategoryQueryResultModel>>> Handle(
		GetPagingCategoryQuery request, CancellationToken cancellationToken)
	{
		var paging = await _categoryRepository.PagingAsync<GetSingleCategoryQueryResultModel>(
			FilterBuilder<ClotheCategory>.True(),
			new PagingRequest(request.PageIndex, request.PageSize),
			cancellationToken);

		return JsonApiResponse<PagingModel<GetSingleCategoryQueryResultModel>>.Success(data: paging);
	}
}
