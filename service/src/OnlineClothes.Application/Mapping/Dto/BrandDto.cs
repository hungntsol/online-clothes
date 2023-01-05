namespace OnlineClothes.Application.Mapping.Dto;

public class BrandDto
{
	public string Id { get; init; } = null!;

	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	public string? ContactEmail { get; set; }

	public List<Serial> Serials { get; set; } = new();
}
