using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineClothes.Support.Entity.Event;

namespace OnlineClothes.Domain.Entities.Aggregate;

public class ProductSku : SupportDomainEvent, IEntityDatetimeSupport, IEntity<string>
{
	[Key] public string Sku { get; set; } = null!;
	public int ProductId { get; set; }
	public int InStock { get; set; }
	public decimal AddOnPrice { get; set; }
	public ClotheSizeType Size { get; set; }

	[ForeignKey("ProductId")] public Product Product { get; set; } = null!;

	[JsonIgnore] public virtual ICollection<OrderItem> OrderItems { get; set; } = new Collection<OrderItem>();

	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }

	public bool IsAvailable()
	{
		return InStock > 0;
	}

	public void Disable()
	{
		InStock = 0;
	}

	public void ImportStock(int number)
	{
		InStock += number;
	}

	public void ExportStock(int number)
	{
		InStock -= number;
	}

	public decimal GetPrice()
	{
		return Product.Price + AddOnPrice;
	}
}
