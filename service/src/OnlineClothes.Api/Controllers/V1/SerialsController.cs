using OnlineClothes.Application.Features.Serial.Commands.Create;
using OnlineClothes.Application.Features.Serial.Commands.Delete;
using OnlineClothes.Application.Features.Serial.Commands.Edit;
using OnlineClothes.Application.Features.Serial.Queries.Paging;
using OnlineClothes.Application.Features.Serial.Queries.Single;

namespace OnlineClothes.Api.Controllers.V1;

public class SerialsController : ApiV1ControllerBase
{
	public SerialsController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetSingle(int id)
	{
		return HandleApiResponse(await Mediator.Send(new GetSingleSerialQuery(id)));
	}

	[HttpGet]
	public async Task<IActionResult> GetPaging([FromQuery] PagingRequest pagingRequest)
	{
		return HandleApiResponse(await Mediator.Send(new GetPagingSerialQuery(pagingRequest)));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateSerialCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpPut]
	public async Task<IActionResult> Edit([FromBody] EditSerialCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		return HandleApiResponse(await Mediator.Send(new DeleteSerialCommand(id)));
	}
}
