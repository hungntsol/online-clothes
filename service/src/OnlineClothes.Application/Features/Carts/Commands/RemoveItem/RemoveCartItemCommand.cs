namespace OnlineClothes.Application.Features.Carts.Commands.RemoveItem;

public class RemoveCartItemCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public RemoveCartItemCommand()
	{
	}

	public RemoveCartItemCommand(int productId, int quantity)
	{
		ProductId = productId;
		Quantity = quantity;
	}

	public int ProductId { get; init; }
	public int Quantity { get; init; } = 1;
}
