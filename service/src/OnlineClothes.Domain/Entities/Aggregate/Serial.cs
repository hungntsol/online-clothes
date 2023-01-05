using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineClothes.Domain.Entities.Aggregate;

public class Serial : EntityBase
{
	public Serial()
	{
	}

	public Serial(string name, string? brandId, ClotheType? type)
	{
		Name = name;
		BrandId = string.IsNullOrEmpty(brandId?.Trim()) ? null : brandId;
		Type = type;
	}

	[Required] public string Name { get; set; } = null!;

	[ForeignKey("BrandId")] public Brand? Brand { get; set; } = null!;
	public string? BrandId { get; set; }

	public ClotheType? Type { get; set; }

	[JsonIgnore] public virtual ICollection<SerialCategory> SerialCategories { get; set; } = new List<SerialCategory>();

	public void SetName(string name)
	{
		Name = name;
	}

	public void SetBrandId(string? brandId = null)
	{
		BrandId = string.IsNullOrEmpty(brandId?.Trim()) ? null : brandId;
	}

	public void AssignCategoryNavigation(IEnumerable<int> categoryIds)
	{
		SerialCategories.Clear();
		var navigation = categoryIds
			.Select(q => SerialCategory.ToModel(Id, q))
			.ToList();
		SerialCategories = navigation;
	}
}
