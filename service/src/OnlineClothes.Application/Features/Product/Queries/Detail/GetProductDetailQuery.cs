using OnlineClothes.Application.Mapping.ViewModels;

namespace OnlineClothes.Application.Features.Product.Queries.Detail;

public class GetProductDetailQuery : IRequest<JsonApiResponse<ProductViewModel>>
{
	public GetProductDetailQuery(int productId)
	{
		ProductId = productId;
	}

	public int ProductId { get; set; }
}
