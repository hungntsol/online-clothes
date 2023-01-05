namespace OnlineClothes.Application.Features.Brand.Commands.Delete;

public class DeleteBrandCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public DeleteBrandCommand(int id)
	{
		Id = id;
	}

	public int Id { get; init; }
}
