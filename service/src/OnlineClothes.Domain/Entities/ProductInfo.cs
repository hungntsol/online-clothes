using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineClothes.Domain.Common;
using OnlineClothes.Support.Entity;

namespace OnlineClothes.Domain.Entities;

public class ProductInfo : IEntityDatetimeSupport
{
	[Key] [Required] public string Sku { get; set; } = null!;

	public string Name { get; set; } = null!;
	public string? Description { get; set; }

	[ForeignKey("BrandId")] public ClotheBrand Brand { get; set; } = null!;
	public string BrandId { get; set; } = null!;

	public ICollection<ClotheCategory> ClotheCategories { get; set; } = new List<ClotheCategory>();

	public ClotheType Type { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime ModifiedAt { get; set; }
}
