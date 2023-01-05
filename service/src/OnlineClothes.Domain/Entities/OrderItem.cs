using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class OrderItem
{
	public int OrderId { get; set; }
	public string ProductSku { get; set; } = null!;
	public int Quantity { get; set; }
	public double Price { get; set; }

	[ForeignKey("OrderId")] public Order Order { get; set; } = null!;
	[ForeignKey("ProductSku")] public Product Product { get; set; } = null!;

	public double IntoMoney()
	{
		return Quantity * Price;
	}
}
