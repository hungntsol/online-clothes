using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class ProductInMaterial
{
	public ProductInMaterial()
	{
	}

	public ProductInMaterial(int clotheDetailId, int materialId)
	{
		ClotheDetailId = clotheDetailId;
		MaterialId = materialId;
	}

	public ProductInMaterial(Product detail, ClotheMaterialType materialType)
	{
		Detail = detail;
		MaterialType = materialType;
	}

	[ForeignKey("ClotheDetailId")] public Product Detail { get; set; } = null!;
	public int ClotheDetailId { get; set; }

	[ForeignKey("MaterialId")] public ClotheMaterialType MaterialType { get; set; } = null!;
	public int MaterialId { get; set; }
}
