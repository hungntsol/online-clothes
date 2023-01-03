using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineClothes.Domain.Entities;

public class ProductInCategory
{
	[ForeignKey("ProductId")] public ProductInfo ProductInfo { get; set; } = null!;
	public int ProductId { get; set; }

	[ForeignKey("ClotheCategoryId")] public ClotheCategory ClotheCategory { get; set; } = null!;
	public int ClotheCategoryId { get; set; }
}
