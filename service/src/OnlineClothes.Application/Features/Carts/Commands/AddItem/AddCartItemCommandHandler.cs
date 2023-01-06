﻿//using OnlineClothes.Infrastructure.Repositories.Abstracts;

using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Services.UserContext;

namespace OnlineClothes.Application.Features.Carts.Commands.AddItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ICartRepository _cartRepository;
	private readonly IProductRepository _productRepository;
	private readonly IUserContext _userContext;

	public AddCartItemCommandHandler(
		ICartRepository cartRepository,
		IUserContext userContext,
		IProductRepository productRepository)
	{
		_cartRepository = cartRepository;
		_userContext = userContext;
		_productRepository = productRepository;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(AddCartItemCommand request,
		CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByIntKey(request.ProductId, cancellationToken);

		if (!product.IsAvailable())
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail("Sản phẩm đang không bày bán");
		}

		if (product.InStock < request.Quantity)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail(message: "Số lượng tồn kho không đủ");
		}

		//var cart = await _cartRepository.FindOneOrInsertAsync(
		//	FilterBuilder<AccountCart>.Where(q => q.AccountId.tos == _userContext.GetNameIdentifier()),
		//	new AccountCart
		//	{
		//		AccountId = _userContext.GetNameIdentifier(),
		//		Items = new List<AccountCart.CartItem>()
		//	},
		//	selector: e => e,
		//	cancellationToken: cancellationToken);

		//cart.AddItem(product.Id, request.Quantity);
		//var updatedResult = await _cartRepository.UpdateOneAsync(
		//	cart.Id,
		//	update => update.Set(q => q.Items, cart.Items),
		//	cancellationToken: cancellationToken);

		//return updatedResult.Any()
		//	? JsonApiResponse<EmptyUnitResponse>.Success()
		//	: JsonApiResponse<EmptyUnitResponse>.Fail();

		throw new NotImplementedException();
	}
}
