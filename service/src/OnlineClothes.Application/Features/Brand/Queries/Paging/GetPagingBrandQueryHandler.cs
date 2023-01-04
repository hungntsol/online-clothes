using OnlineClothes.Application.Features.Brand.Queries.Single;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;

namespace OnlineClothes.Application.Features.Brand.Queries.Paging;

public class GetPagingBrandQueryHandler : IRequestHandler<GetPagingBrandQuery,
	JsonApiResponse<PagingModel<GetSingleBrandQueryResultModel>>>
{
	private readonly IBrandRepository _brandRepository;

	public GetPagingBrandQueryHandler(IBrandRepository brandRepository)
	{
		_brandRepository = brandRepository;
	}

	public async Task<JsonApiResponse<PagingModel<GetSingleBrandQueryResultModel>>> Handle(GetPagingBrandQuery request,
		CancellationToken cancellationToken)
	{
		var pagingModel = await _brandRepository.PagingAsync<GetSingleBrandQueryResultModel>(
			FilterBuilder<ClotheBrand>.True(),
			new PagingRequest(request),
			DefaultOrderByFunc(),
			cancellationToken);

		return JsonApiResponse<PagingModel<GetSingleBrandQueryResultModel>>.Fail(data: pagingModel);
	}

	private static Func<IQueryable<ClotheBrand>, IOrderedQueryable<ClotheBrand>> DefaultOrderByFunc()
	{
		return brands => brands.OrderBy(q => q.Id);
	}
}
