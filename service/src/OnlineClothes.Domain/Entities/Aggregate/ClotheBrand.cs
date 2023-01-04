namespace OnlineClothes.Domain.Entities.Aggregate;

public class ClotheBrand : EntityBase<string>
{
	public ClotheBrand()
	{
	}

	public ClotheBrand(string id, string name, string? description, string? contactEmail)
	{
		Id = id;
		Name = name;
		Description = description;
		ContactEmail = contactEmail;
	}

	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	public string? ContactEmail { get; set; }

	public ICollection<ProductSerial> Products { get; set; } = new List<ProductSerial>();
}
