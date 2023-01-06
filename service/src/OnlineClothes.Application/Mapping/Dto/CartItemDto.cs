using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Application.Mapping.Dto;

public class CartItemDto
{
	public CartItemDto()
	{
	}

	public CartItemDto(ProductBasicDto product, int quantity)
	{
		Product = product;
		Quantity = quantity;
	}

	public ProductBasicDto Product { get; set; } = null!;
	public int Quantity { get; set; }

	public static CartItemDto ToModel(CartItem entity)
	{
		return new CartItemDto
		{
			Quantity = entity.Quantity,
			Product = ProductBasicDto.ToModel(entity.Product)
		};
	}
}
