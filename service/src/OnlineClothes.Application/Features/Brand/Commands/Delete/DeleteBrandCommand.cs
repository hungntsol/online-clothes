namespace OnlineClothes.Application.Features.Brand.Commands.Delete;

public class DeleteBrandCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public DeleteBrandCommand(string id)
	{
		Id = id;
	}

	public string Id { get; init; }
}
