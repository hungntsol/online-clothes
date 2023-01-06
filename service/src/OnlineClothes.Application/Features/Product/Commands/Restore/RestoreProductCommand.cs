namespace OnlineClothes.Application.Features.Product.Commands.Restore;

public class RestoreProductCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public RestoreProductCommand(int productId)
	{
		ProductId = productId;
	}

	public int ProductId { get; set; }
}
