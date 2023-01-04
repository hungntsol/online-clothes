using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class OrderItem
{
	[ForeignKey("OrderId")] public Order Order { get; set; } = null!;
	public int OrderId { get; set; }

	[ForeignKey("ProductSku")] public Product Product { get; set; } = null!;
	public string ProductSku { get; set; } = null!;

	public int Quantity { get; set; }

	public double Price { get; set; }

	public double IntoMoney()
	{
		return Quantity * Price;
	}
}
