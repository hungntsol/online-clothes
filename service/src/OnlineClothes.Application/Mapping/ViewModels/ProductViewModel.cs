using System.ComponentModel;

namespace OnlineClothes.Application.Mapping.ViewModels;

public class ProductViewModel
{
	public int Id { get; set; }
	public string Sku { get; set; } = null!;
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public double Price { get; set; }
	public int InStock { get; set; }
	public ClotheSizeType? Size { get; set; }
	public ClotheType? Type { get; set; }
	[DefaultValue(true)] public bool IsPublish { get; set; }
	public BrandDto? Brand { get; set; }
	public List<CategoryDto> Categories { get; set; } = new();
	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }
}
