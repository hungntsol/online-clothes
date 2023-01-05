namespace OnlineClothes.Application.Mapping.Dto;

public class SerialDto
{
	public string Name { get; set; } = null!;

	public Brand? Brand { get; set; } = null!;

	public ClotheType? Type { get; set; }

	public List<CategoryDto> Categories { get; set; } = new();
}
