namespace OnlineClothes.Application.Features.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public DeleteProductCommand(int productId)
	{
		ProductId = productId;
	}

	public int ProductId { get; set; }
}
