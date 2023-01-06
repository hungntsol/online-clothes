//using OnlineClothes.Infrastructure.Repositories.Abstracts;

using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Carts.Commands.AddItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private const string ProductNotAvailableError = "Sản phẩm đang không bày bán";
	private const string ProductInStockNotEnoughError = "Số lượng tồn kho không đủ";

	private readonly ICartRepository _cartRepository;
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddCartItemCommandHandler(
		ICartRepository cartRepository,
		IProductRepository productRepository,
		IUnitOfWork unitOfWork)
	{
		_cartRepository = cartRepository;
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(AddCartItemCommand request,
		CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByIntKey(request.ProductId, cancellationToken);

		if (!product.IsAvailable())
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail(ProductNotAvailableError);
		}

		if (product.InStock < request.Quantity)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail(ProductInStockNotEnoughError);
		}

		var cart = await _cartRepository.GetCurrentCart();

		_cartRepository.Update(cart);
		cart.IncreaseItem(request.ProductId, request.Quantity);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);
		return !save ? JsonApiResponse<EmptyUnitResponse>.Fail() : JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
