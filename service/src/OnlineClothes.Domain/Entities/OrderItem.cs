using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class OrderItem
{
	[ForeignKey("OrderId")] public Order Order { get; set; } = null!;
	public int OrderId { get; set; }

	[ForeignKey("ProductId")] public Product Product { get; set; } = null!;
	public int ProductId { get; set; }

	public int Quantity { get; set; }

	public double Price { get; set; }

	public double IntoMoney()
	{
		return Quantity * Price;
	}
}
