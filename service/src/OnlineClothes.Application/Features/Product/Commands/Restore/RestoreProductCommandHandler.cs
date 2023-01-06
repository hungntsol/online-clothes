﻿using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Product.Commands.Restore;

public class RestoreProductCommandHandler : IRequestHandler<RestoreProductCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ILogger<RestoreProductCommandHandler> _logger;
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RestoreProductCommandHandler(IProductRepository productRepository,
		ILogger<RestoreProductCommandHandler> logger,
		IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_logger = logger;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(RestoreProductCommand request,
		CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByIntKey(request.ProductId, cancellationToken);
		var restore = product.Restore();
		_productRepository.Update(product);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);
		if (!save && !restore)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		_logger.LogInformation("Restore product {Id} successfully", request.ProductId);
		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
