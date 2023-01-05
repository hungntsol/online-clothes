namespace OnlineClothes.Application.Mapping.Dto;

public class SerialDto
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public Brand? Brand { get; set; } = null!;

	public ClotheType? Type { get; set; }
}
