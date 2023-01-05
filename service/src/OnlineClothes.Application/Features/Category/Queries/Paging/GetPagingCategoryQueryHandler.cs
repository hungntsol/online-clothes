using AutoMapper;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;

namespace OnlineClothes.Application.Features.Category.Queries.Paging;

public class GetPagingCategoryQueryHandler : IRequestHandler<GetPagingCategoryQuery,
	JsonApiResponse<PagingModel<CategoryDto>>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public GetPagingCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<PagingModel<CategoryDto>>> Handle(
		GetPagingCategoryQuery request, CancellationToken cancellationToken)
	{
		var paging = await _categoryRepository.PagingAsync(
			FilterBuilder<Domain.Entities.Aggregate.Category>.True(),
			new PagingRequest(request.PageIndex, request.PageSize),
			SelectorFunc(),
			DefaultOrderByFunc(),
			cancellationToken);

		return JsonApiResponse<PagingModel<CategoryDto>>.Success(data: paging);
	}

	private Func<IQueryable<Domain.Entities.Aggregate.Category>, IQueryable<CategoryDto>>
		SelectorFunc()
	{
		return q => q.Select(item => _mapper.Map<CategoryDto>(item));
	}

	private static
		Func<IQueryable<Domain.Entities.Aggregate.Category>, IOrderedQueryable<Domain.Entities.Aggregate.Category>>
		DefaultOrderByFunc()
	{
		return category => category.OrderBy(q => q.Id);
	}
}
