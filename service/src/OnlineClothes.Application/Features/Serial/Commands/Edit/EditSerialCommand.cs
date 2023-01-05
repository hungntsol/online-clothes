namespace OnlineClothes.Application.Features.Serial.Commands.Edit;

public class EditSerialCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public EditSerialCommand(int id, string name, string? brandId, ClotheType type, ISet<int> categoryIds)
	{
		Id = id;
		Name = name;
		BrandId = brandId;
		Type = type;
		CategoryIds = categoryIds;
	}

	public int Id { get; set; }
	public string Name { get; set; }
	public string? BrandId { get; set; }
	public ClotheType Type { get; set; }
	public ISet<int> CategoryIds { get; set; }
}
