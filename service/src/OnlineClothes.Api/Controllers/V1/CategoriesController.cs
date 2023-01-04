using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineClothes.Application.Features.Category.Commands.Delete;
using OnlineClothes.Application.Features.Category.Commands.Edit;
using OnlineClothes.Application.Features.Category.Commands.NewCategory;
using OnlineClothes.Application.Features.Category.Queries.Paging;
using OnlineClothes.Application.Features.Category.Queries.Single;
using OnlineClothes.Domain.Paging;

namespace OnlineClothes.Api.Controllers.V1;

public class CategoriesController : ApiV1ControllerBase
{
	public CategoriesController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetSingle(int id)
	{
		return HandleApiResponse(await Mediator.Send(new GetSingleCategoryQuery(id)));
	}

	[HttpGet]
	public async Task<IActionResult> Get([FromQuery] PagingRequest pageRequest)
	{
		return HandleApiResponse(await Mediator.Send(new GetPagingCategoryQuery(pageRequest)));
	}

	[HttpPost]
	public async Task<IActionResult> CreateNew([FromBody] CreateNewCategoryCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Edit([FromBody] EditCategoryCommand.Content requestContent, int id)
	{
		return HandleApiResponse(await Mediator.Send(new EditCategoryCommand(id, requestContent)));
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		return HandleApiResponse(await Mediator.Send(new DeleteCategoryCommand { Id = id }));
	}
}
