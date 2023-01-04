using OnlineClothes.Application.Features.Serial.Commands.Create;

namespace OnlineClothes.Api.Controllers.V1;

public class SerialsController : ApiV1ControllerBase
{
	public SerialsController(IMediator mediator) : base(mediator)
	{
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateSerialCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}
}
