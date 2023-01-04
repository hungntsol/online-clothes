namespace OnlineClothes.Domain.Entities;

public class ClotheCategory : EntityBase
{
	public ClotheCategory()
	{
	}

	public ClotheCategory(string name, string? description)
	{
		Name = name;
		Description = description;
	}

	public string Name { get; set; } = null!;
	public string? Description { get; set; }

	public ICollection<ProductInfo> Products { get; set; } = new List<ProductInfo>();

	public void Update(string newName, string newDesc)
	{
		Name = newName;
		Description = newDesc;
	}
}
