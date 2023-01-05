namespace OnlineClothes.Domain.Entities.Aggregate;

public class Brand : EntityBase<string>
{
	public Brand()
	{
	}

	public Brand(string id, string name, string? description, string? contactEmail)
	{
		Id = id;
		Name = name;
		Description = description;
		ContactEmail = contactEmail;
	}

	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	public string? ContactEmail { get; set; }

	public virtual ICollection<Serial> Serials { get; set; } = new List<Serial>();
}
