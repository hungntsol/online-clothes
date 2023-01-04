namespace OnlineClothes.Domain.Entities.Aggregate;

public class MaterialType : EntityBase
{
	public MaterialType()
	{
	}

	public MaterialType(string name)
	{
		Name = name;
	}

	public string Name { get; set; } = null!;

	public void SetName(string newName)
	{
		Name = newName;
	}
}
