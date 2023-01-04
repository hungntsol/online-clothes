namespace OnlineClothes.Application.Features.Product.Queries.Detail;

public class
	ProductDetailQueryHandler : IRequestHandler<ProductDetailQuery, JsonApiResponse<ProductDetailQueryViewModel>>
{
	//private readonly IProductRepository _productRepository;

	//public ProductDetailQueryHandler(IProductRepository productRepository)
	//{
	//	_productRepository = productRepository;
	//}

	public async Task<JsonApiResponse<ProductDetailQueryViewModel>> Handle(ProductDetailQuery request,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();

		//var product = await _productRepository.GetOneAsync(request.ProductId, cancellationToken);
		//var viewModel = ProductDetailQueryViewModel.Create(product);
		//return JsonApiResponse<ProductDetailQueryViewModel>.Success(data: viewModel);
	}
}
