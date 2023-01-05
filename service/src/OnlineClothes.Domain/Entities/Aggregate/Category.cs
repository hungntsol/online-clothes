using Newtonsoft.Json;

namespace OnlineClothes.Domain.Entities.Aggregate;

public class Category : EntityBase
{
	public Category()
	{
	}

	public Category(string name, string? description)
	{
		Name = name;
		Description = description;
	}

	public string Name { get; set; } = null!;
	public string? Description { get; set; }

	[JsonIgnore] public virtual ICollection<SerialCategory> SerialCategories { get; set; } = new List<SerialCategory>();

	public void Update(string newName, string? newDesc)
	{
		Name = newName;
		Description = newDesc;
	}
}
