using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineClothes.Domain.Entities;

public class ProductInCategory
{
	[ForeignKey("ProductSku")] public ProductInfo ProductInfo { get; set; } = null!;
	public string ProductSku { get; set; } = null!;

	[ForeignKey("ClotheCategoryId")] public ClotheCategory ClotheCategory { get; set; } = null!;
	public int ClotheCategoryId { get; set; }
}
