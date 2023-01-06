using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class CartItem
{
	public CartItem()
	{
	}

	public CartItem(int productId, int quantity = 1) : this()
	{
		ProductId = productId;
		Quantity = quantity;
	}

	public CartItem(int cartId, int productId, int quantity = 1) : this(productId, quantity)
	{
		CartId = cartId;
	}

	public CartItem(AccountCart cart, int productId, int quantity = 1) : this(productId, quantity)
	{
		Cart = cart;
	}

	public int CartId { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; }

	[ForeignKey("CartId")] public AccountCart Cart { get; set; } = null!;
	[ForeignKey("ProductId")] public Product Product { get; set; } = null!;

	public void Increase(int number)
	{
		Quantity += number;
	}

	public void Decrease(int number)
	{
		Quantity -= number;
	}
}
