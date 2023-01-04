using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class ClotheMaterialType : EntityBase
{
	public ClotheMaterialType()
	{
	}

	public ClotheMaterialType(string materialName)
	{
		MaterialName = materialName;
	}

	public string MaterialName { get; set; } = null!;

	public ICollection<Product> ProductDetails { get; set; } = new List<Product>();

	public void Rename(string newName)
	{
		MaterialName = newName;
	}
}
