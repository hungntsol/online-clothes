using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Product.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ILogger<DeleteProductCommandHandler> _logger;
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteProductCommandHandler(IProductRepository productRepository,
		ILogger<DeleteProductCommandHandler> logger,
		IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_logger = logger;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(DeleteProductCommand request,
		CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByIntKey(request.ProductId, cancellationToken);
		var delete = product.Delete();
		_productRepository.Update(product);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);
		if (!save && !delete)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		_logger.LogInformation("Disable product {Id} successfully", request.ProductId);
		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
