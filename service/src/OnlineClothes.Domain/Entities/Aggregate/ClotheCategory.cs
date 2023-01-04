namespace OnlineClothes.Domain.Entities.Aggregate;

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

	public virtual ICollection<ProductSerial> ProductSerials { get; set; } = new List<ProductSerial>();

	public void Update(string newName, string? newDesc)
	{
		Name = newName;
		Description = newDesc;
	}
}
