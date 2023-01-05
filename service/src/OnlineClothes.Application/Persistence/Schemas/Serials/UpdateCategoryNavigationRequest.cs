namespace OnlineClothes.Application.Persistence.Schemas.Serials;

public class UpdateCategoryNavigationRequest
{
	public UpdateCategoryNavigationRequest(string name, string? brandId, ClotheType? clotheType,
		IEnumerable<int> categoryIds)
	{
		Name = name;
		BrandId = brandId;
		ClotheType = clotheType;
		CategoryIds = categoryIds;
	}

	public string Name { get; set; }
	public string? BrandId { get; set; }
	public ClotheType? ClotheType { get; set; }
	public IEnumerable<int> CategoryIds { get; set; }
}
