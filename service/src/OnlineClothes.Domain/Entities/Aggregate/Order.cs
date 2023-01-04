namespace OnlineClothes.Domain.Entities.Aggregate;

public class Order : EntityBase
{
	[ForeignKey("AccountId")] public AccountUser Account { get; set; } = null!;
	public int AccountId { get; set; }

	public OrderState State { get; set; }

	public double TotalPaid { get; set; }

	public bool IsPaid { get; set; }

	public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
