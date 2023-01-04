﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineClothes.Application.Features.Cart.Commands.AddItem;
using OnlineClothes.Application.Features.Cart.Commands.RemoveItem;
using OnlineClothes.Application.Features.Cart.Queries.GetInfo;

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

	[HttpPut("{productId}/add-item/{quantity}")]
	public async Task<IActionResult> AddItem(string productId, int quantity)
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
