namespace OnlineClothes.Application.Mapping.Dto;

public class BrandDto
{
	public BrandDto()
	{
	}

	public BrandDto(string id, string name, string? description, string? contactEmail)
	{
		Id = id;
		Name = name;
		Description = description;
		ContactEmail = contactEmail;
	}

	public string Id { get; init; } = null!;
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public string? ContactEmail { get; set; }
}
