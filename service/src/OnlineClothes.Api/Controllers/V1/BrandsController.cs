using OnlineClothes.Application.Features.Brand.Commands.Create;
using OnlineClothes.Application.Features.Brand.Commands.Delete;
using OnlineClothes.Application.Features.Brand.Commands.Edit;
using OnlineClothes.Application.Features.Brand.Queries.Paging;
using OnlineClothes.Application.Features.Brand.Queries.Single;

namespace OnlineClothes.Api.Controllers.V1;

public class BrandsController : ApiV1ControllerBase
{
	public BrandsController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetSingle(int id)
	{
		return HandleApiResponse(await Mediator.Send(new GetSingleBrandQuery(id)));
	}

	[HttpGet]
	public async Task<IActionResult> GetPaging([FromQuery] PagingRequest pageRequest)
	{
		return HandleApiResponse(await Mediator.Send(new GetPagingBrandQuery(pageRequest)));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateBrandCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpPut]
	public async Task<IActionResult> Edit([FromBody] EditBrandCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		return HandleApiResponse(await Mediator.Send(new DeleteBrandCommand(id)));
	}
}
