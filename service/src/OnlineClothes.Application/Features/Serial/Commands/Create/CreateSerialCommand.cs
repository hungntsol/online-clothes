namespace OnlineClothes.Application.Features.Serial.Commands.Create;

public class CreateSerialCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public CreateSerialCommand(string name, string brandId, ClotheType clotheType, IList<int> categoryIds)
	{
		Name = name;
		BrandId = brandId;
		ClotheType = clotheType;
		CategoryIds = categoryIds;
	}

	public string Name { get; set; }

	public string? BrandId { get; init; }

	public ClotheType? ClotheType { get; init; }

	public ICollection<int> CategoryIds { get; init; }
}
