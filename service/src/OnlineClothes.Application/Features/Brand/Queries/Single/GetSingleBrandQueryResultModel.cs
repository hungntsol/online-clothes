namespace OnlineClothes.Application.Features.Brand.Queries.Single;

public class GetSingleBrandQueryResultModel
{
	public GetSingleBrandQueryResultModel(string id, string name, string description, string contactEmail)
	{
		Id = id;
		Name = name;
		Description = description;
		ContactEmail = contactEmail;
	}

	public string Id { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
	public string ContactEmail { get; init; }
}
