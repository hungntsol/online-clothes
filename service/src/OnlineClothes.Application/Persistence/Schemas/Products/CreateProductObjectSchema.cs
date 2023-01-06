using System.ComponentModel;

namespace OnlineClothes.Application.Persistence.Schemas.Products;

public class CreateProductObjectSchema
{
	public string Sku { get; set; } = null!;
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public double Price { get; set; }
	public int InStock { get; set; }
	public ClotheSizeType? SizeType { get; set; }
	public ClotheType? Type { get; set; }
	public int? BrandId { get; set; }
	[DefaultValue(true)] public bool IsPublish { get; set; }
	public HashSet<int> CategoryIds { get; set; } = new();
}
