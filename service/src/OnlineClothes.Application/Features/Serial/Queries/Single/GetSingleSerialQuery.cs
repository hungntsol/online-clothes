using OnlineClothes.Application.Mapping.Dto;

namespace OnlineClothes.Application.Features.Serial.Queries.Single;

public class GetSingleSerialQuery : IRequest<JsonApiResponse<SerialDto>>
{
	public GetSingleSerialQuery(int id)
	{
		Id = id;
	}

	public int Id { get; set; }
}
