namespace OnlineClothes.Application.Features.Carts.Commands.AddItem;

public class AddCartItemCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public AddCartItemCommand()
	{
	}

	public AddCartItemCommand(int productId, int quantity = 1)
	{
		ProductId = productId;
		Quantity = quantity;
	}

	public int ProductId { get; init; }
	public int Quantity { get; init; } = 1;
}
