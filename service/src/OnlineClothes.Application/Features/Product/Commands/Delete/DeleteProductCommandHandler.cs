namespace OnlineClothes.Application.Features.Product.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, JsonApiResponse<EmptyUnitResponse>>
{
	//private readonly ILogger<DeleteProductCommandHandler> _logger;
	//private readonly IProductRepository _productRepository;

	//public DeleteProductCommandHandler(IProductRepository productRepository,
	//	ILogger<DeleteProductCommandHandler> logger)
	//{
	//	_productRepository = productRepository;
	//	_logger = logger;
	//}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(DeleteProductCommand request,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();

		//var isProductExisted = await _productRepository.IsExistAsync(request.ProductId, cancellationToken);
		//if (!isProductExisted)
		//{
		//	return JsonApiResponse<EmptyUnitResponse>.Fail();
		//}

		//var deleteResult = await _productRepository.UpdateOneAsync(
		//	request.ProductId,
		//	update => update.Set(q => q.IsDeleted, true), cancellationToken: cancellationToken);

		//if (!deleteResult.Any())
		//{
		//	return JsonApiResponse<EmptyUnitResponse>.Fail();
		//}

		//_logger.LogInformation("Disable product {Id} successfully", request.ProductId);
		//return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
