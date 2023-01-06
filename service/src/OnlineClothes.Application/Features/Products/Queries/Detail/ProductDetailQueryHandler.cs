using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Mapping.ViewModels;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Products.Queries.Detail;

public class ProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, JsonApiResponse<ProductViewModel>>
{
	private readonly IMapper _mapper;
	private readonly IProductRepository _productRepository;

	public ProductDetailQueryHandler(IProductRepository productRepository, IMapper mapper)
	{
		_productRepository = productRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<ProductViewModel>> Handle(GetProductDetailQuery request,
		CancellationToken cancellationToken)
	{
		var product = await _productRepository.AsQueryable()
			.Include(q => q.Categories)
			.Include(q => q.Brand)
			.FirstOrDefaultAsync(q => q.Id.Equals(request.ProductId), cancellationToken);


		if (product is null)
		{
			return JsonApiResponse<ProductViewModel>.Fail();
		}

		var viewModel = _mapper.Map<ProductViewModel>(product);
		return JsonApiResponse<ProductViewModel>.Success(data: viewModel);
	}
}
