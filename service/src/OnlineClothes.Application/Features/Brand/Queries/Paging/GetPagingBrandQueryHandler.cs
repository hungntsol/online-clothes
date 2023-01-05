using AutoMapper;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;

namespace OnlineClothes.Application.Features.Brand.Queries.Paging;

public class GetPagingBrandQueryHandler : IRequestHandler<GetPagingBrandQuery,
	JsonApiResponse<PagingModel<BrandDto>>>
{
	private readonly IBrandRepository _brandRepository;
	private readonly IMapper _mapper;

	public GetPagingBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
	{
		_brandRepository = brandRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<PagingModel<BrandDto>>> Handle(GetPagingBrandQuery request,
		CancellationToken cancellationToken)
	{
		var pagingModel = await _brandRepository.PagingAsync(
			FilterBuilder<Domain.Entities.Aggregate.Brand>.True(),
			new PagingRequest(request),
			SelectorFunc(),
			DefaultOrderByFunc(),
			cancellationToken);

		return JsonApiResponse<PagingModel<BrandDto>>.Fail(data: pagingModel);
	}

	private Func<IQueryable<Domain.Entities.Aggregate.Brand>, IQueryable<BrandDto>>
		SelectorFunc()
	{
		return q => q.Select(item => _mapper.Map<BrandDto>(item));
	}

	private static Func<IQueryable<Domain.Entities.Aggregate.Brand>, IOrderedQueryable<Domain.Entities.Aggregate.Brand>>
		DefaultOrderByFunc()
	{
		return brands => brands.OrderBy(q => q.Id);
	}
}
