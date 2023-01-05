namespace OnlineClothes.Domain.Entities.Aggregate;

public class AccountCart : EntityBase
{
	public AccountCart()
	{
	}

	public AccountCart(AccountUser account) : this()
	{
		Account = account;
	}

	public AccountCart(int accountId) : this()
	{
		AccountId = accountId;
	}

	public int AccountId { get; set; }

	[ForeignKey("AccountId")] public AccountUser Account { get; set; } = null!;

	public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

	public void IncreaseItem(int productId, int number)
	{
		var item = FindItemInCart(productId);

		if (item is null)
		{
			Items.Add(CartItem.Create(Id, productId, number));
			return;
		}

		item.Increase(number);
		PostCheck(item);
	}

	public void DecreaseItem(int productId, int number)
	{
		var item = FindItemInCart(productId);

		if (item is null)
		{
			return;
		}

		item.Decrease(number);
		PostCheck(item);
	}

	private CartItem? FindItemInCart(int productId)
	{
		return Items.FirstOrDefault(q => q.ProductDetailId.Equals(productId));
	}

	private void PostCheck(CartItem item)
	{
		if (item.Quantity <= 0)
		{
			Items.Remove(item);
		}
	}
}
