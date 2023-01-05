using MapsterMapper;
using OnlineClothes.Application.Mapping.Dto;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Serial.Queries.Single;

public class
	GetSingleSerialQueryHandler : IRequestHandler<GetSingleSerialQuery,
		JsonApiResponse<SerialDto>>
{
	private readonly IMapper _mapper;
	private readonly ISerialRepository _serialRepository;

	public GetSingleSerialQueryHandler(ISerialRepository serialRepository, IMapper mapper)
	{
		_serialRepository = serialRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<SerialDto>> Handle(GetSingleSerialQuery request,
		CancellationToken cancellationToken)
	{
		var entry = await _serialRepository.GetByIntKey(request.Id, cancellationToken);

		var viewModel = _mapper.Map<Domain.Entities.Aggregate.Serial, SerialDto>(entry);

		return JsonApiResponse<SerialDto>.Success(
			data: viewModel);
	}
}
