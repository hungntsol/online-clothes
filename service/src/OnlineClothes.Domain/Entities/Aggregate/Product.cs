using System.ComponentModel;
using Newtonsoft.Json;

namespace OnlineClothes.Domain.Entities.Aggregate;

public class Product : EntityBase
{
	public Product()
	{
	}

	public Product(string sku, string name, double price, int inStock, bool isPublish = false)
	{
		Sku = sku;
		Name = name;
		Price = price;
		InStock = inStock;
		IsPublish = isPublish;
	}

	public Product(
		string sku,
		string name,
		string? description,
		double price,
		int inStock,
		int? brandId,
		ClotheSizeType? size,
		ClotheType? type,
		bool isDeleted = false) : this(sku, name, price, inStock, isDeleted)
	{
		Description = description;
		BrandId = brandId;
		Size = size;
		Type = type;
	}


	public string Sku { get; set; } = null!;
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public double Price { get; set; }
	public int InStock { get; set; }
	[DefaultValue(null)] public int? BrandId { get; set; }
	public ClotheSizeType? Size { get; set; }
	public ClotheType? Type { get; set; }
	[DefaultValue(true)] public bool IsPublish { get; set; }

	[ForeignKey("BrandId")] public Brand? Brand { get; set; }

	[JsonIgnore] public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
	[JsonIgnore] public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

	public bool IsAvailable()
	{
		return IsPublish && InStock > 0;
	}


	public void ImportStock(int number)
	{
		InStock += number;
	}

	public void ExportStock(int number)
	{
		InStock -= number;
	}

	public bool Delete()
	{
		if (!IsPublish)
		{
			return false;
		}

		IsPublish = false;
		return true;
	}

	public bool Restore()
	{
		if (IsPublish)
		{
			return false;
		}

		IsPublish = true;
		return true;
	}
}
