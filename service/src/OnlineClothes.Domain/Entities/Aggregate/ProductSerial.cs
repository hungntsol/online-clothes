using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineClothes.Domain.Entities.Aggregate;

public class ProductSerial : EntityBase
{
	public ProductSerial()
	{
	}

	public ProductSerial(string name, string? brandId, ClotheType? type)
	{
		Name = name;
		BrandId = string.IsNullOrEmpty(brandId?.Trim()) ? null : brandId;
		Type = type;
	}

	[Required] public string Name { get; set; } = null!;

	[ForeignKey("BrandId")] public ClotheBrand? Brand { get; set; } = null!;
	public string? BrandId { get; set; }

	public ClotheType? Type { get; set; }

	[JsonIgnore] public virtual ICollection<ClotheCategory> ClotheCategories { get; set; } = new List<ClotheCategory>();

	public void SetName(string name)
	{
		Name = name;
	}

	public void SetBrandId(string? brandId = null)
	{
		BrandId = string.IsNullOrEmpty(brandId?.Trim()) ? null : brandId;
	}
}
