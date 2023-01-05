using AutoMapper;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;

namespace OnlineClothes.Application.Features.Serial.Queries.Paging;

public class
	GetPagingSerialQueryHandler : IRequestHandler<GetPagingSerialQuery, JsonApiResponse<PagingModel<SerialDto>>>
{
	private readonly IMapper _mapper;
	private readonly ISerialRepository _serialRepository;

	public GetPagingSerialQueryHandler(ISerialRepository serialRepository, IMapper mapper)
	{
		_serialRepository = serialRepository;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<PagingModel<SerialDto>>> Handle(GetPagingSerialQuery request,
		CancellationToken cancellationToken)
	{
		var paging = await _serialRepository.PagingAsync(
			FilterBuilder<Domain.Entities.Aggregate.Serial>.True(),
			new PagingRequest(request.PageIndex, request.PageSize),
			SelectorFunc(),
			DefaultOrderByFunc(),
			cancellationToken);


		return JsonApiResponse<PagingModel<SerialDto>>.Success(data: paging);
	}

	private Func<IQueryable<Domain.Entities.Aggregate.Serial>, IQueryable<SerialDto>>
		SelectorFunc()
	{
		return q => q.Select(item => _mapper.Map<SerialDto>(item));
	}

	private static
		Func<IQueryable<Domain.Entities.Aggregate.Serial>, IOrderedQueryable<Domain.Entities.Aggregate.Serial>>
		DefaultOrderByFunc()
	{
		return serial => serial.OrderBy(q => q.Id);
	}
}
