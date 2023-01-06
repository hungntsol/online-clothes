namespace OnlineClothes.Application.Features.Carts.Commands.RemoveItem;

public class RemoveCartItemCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public string ProductId { get; init; } = null!;
	public int Quantity { get; init; } = 1;
}
