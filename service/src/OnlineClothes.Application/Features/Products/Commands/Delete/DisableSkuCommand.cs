namespace OnlineClothes.Application.Features.Products.Commands.Delete;

public class DisableSkuCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public DisableSkuCommand(string sku)
	{
		Sku = sku;
	}

	public string Sku { get; set; }
}
