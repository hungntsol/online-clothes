using System.ComponentModel.DataAnnotations;
using OnlineClothes.Support.Entity.Event;

namespace OnlineClothes.Domain.Entities.Aggregate;

public class Product : SupportDomainEvent, IEntity<string>
{
	public Product()
	{
	}

	public Product(string sku, string name, double price, int inStock, bool isDeleted = false)
	{
		Sku = sku;
		Name = name;
		Price = price;
		InStock = inStock;
		IsDeleted = isDeleted;
	}

	public Product(string sku,
		string name,
		string? description,
		int? serialId,
		double price,
		int inStock,
		ClotheSizeType? sizeType,
		bool isDeleted = false) : this(sku, name, price, inStock, isDeleted)
	{
		Description = description;
		SerialId = serialId;
		SizeType = sizeType;
	}

	[Key] [Required] public string Sku { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	[ForeignKey("SerialId")] public ProductSerial? ProductSerial { get; set; }
	public int? SerialId { get; set; }

	public double Price { get; set; }

	public int InStock { get; set; }

	public ClotheSizeType? SizeType { get; set; }

	public bool IsDeleted { get; set; }

	public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

	public DateTime CreatedAt { get; set; }

	public DateTime ModifiedAt { get; set; }
}
