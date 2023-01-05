namespace OnlineClothes.Application.Features.Serial.Commands.Delete;

public class DeleteSerialCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public DeleteSerialCommand(int id)
	{
		Id = id;
	}

	public int Id { get; set; }
}
