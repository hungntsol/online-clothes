using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Products.Commands.ImportProducts;

public class
	ImportProductStockCommandHandler : IRequestHandler<ImportProductStockCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public ImportProductStockCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(ImportProductStockCommand request,
		CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByIntKey(request.ProductId, cancellationToken);

		product.ImportStock(request.Quantity);

		_productRepository.Update(product);


		return await _unitOfWork.SaveChangesAsync(cancellationToken)
			? JsonApiResponse<EmptyUnitResponse>.Success(message: "Thêm hàng thành công")
			: JsonApiResponse<EmptyUnitResponse>.Fail();
	}
}
