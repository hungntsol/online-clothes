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
	public async Task<IActionResult> GetSingle(string id)
	{
		return HandleApiResponse(await Mediator.Send(new GetSingleBrandQuery(id)));
	}

	[HttpGet]
	public async Task<IActionResult> Get([FromQuery] PagingRequest pageRequest)
	{
		return HandleApiResponse(await Mediator.Send(new GetPagingBrandQuery(pageRequest)));
	}

	[HttpPost]
	public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> EditBrand(string id, [FromBody] EditBrandCommand.Content requestContent)
	{
		return HandleApiResponse(await Mediator.Send(new EditBrandCommand(id, requestContent)));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBrand(string id)
	{
		return HandleApiResponse(await Mediator.Send(new DeleteBrandCommand(id)));
	}
}
