using Microsoft.AspNetCore.Authorization;
using OnlineClothes.Application.Features.Carts.Commands.AddItem;
using OnlineClothes.Application.Features.Carts.Commands.RemoveItem;
using OnlineClothes.Application.Features.Carts.Queries.GetInfo;

namespace OnlineClothes.Api.Controllers.V1;

[Authorize]
public class CartsController : ApiV1ControllerBase
{
	public CartsController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		return HandleApiResponse(await Mediator.Send(new GetCartInfoQuery()));
	}

	[HttpPut("{productId:int}/add-item/{quantity:int}")]
	public async Task<IActionResult> AddItem(int productId, int quantity = 1)
	{
		return HandleApiResponse(await Mediator.Send(new AddCartItemCommand
		{
			ProductId = productId,
			Quantity = quantity
		}));
	}

	[HttpPut("{productId}/remove-item/{quantity}")]
	public async Task<IActionResult> RemoveItem(string productId, int quantity)
	{
		return HandleApiResponse(await Mediator.Send(new RemoveCartItemCommand
		{
			ProductId = productId,
			Quantity = quantity
		}));
	}
}
