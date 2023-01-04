using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class ProductInMaterial
{
	[ForeignKey("ProductSku")] public Product Product { get; set; } = null!;

	public string ProductSku { get; set; } = null!;

	[ForeignKey("MaterialId")] public MaterialType Material { get; set; } = null!;

	public int MaterialId { get; set; }
}
