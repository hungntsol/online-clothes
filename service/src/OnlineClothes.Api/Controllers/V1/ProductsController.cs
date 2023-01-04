using Microsoft.AspNetCore.Authorization;
using OnlineClothes.Application.Features.Product.Commands.Delete;
using OnlineClothes.Application.Features.Product.Commands.ImportProducts;
using OnlineClothes.Application.Features.Product.Commands.NewProduct;
using OnlineClothes.Application.Features.Product.Commands.Restore;
using OnlineClothes.Application.Features.Product.Commands.UpdateInfo;
using OnlineClothes.Application.Features.Product.Commands.UploadImage;
using OnlineClothes.Application.Features.Product.Queries.Detail;
using OnlineClothes.Application.Features.Product.Queries.Listing;
using OnlineClothes.Domain.Common;

namespace OnlineClothes.Api.Controllers.V1;

public class ProductsController : ApiV1ControllerBase
{
	public ProductsController(IMediator mediator) : base(mediator)
	{
	}


	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> Listing([FromQuery] ListingProductQuery query)
	{
		return HandleApiResponse(await Mediator.Send(query));
	}

	[HttpGet("{productId}")]
	[AllowAnonymous]
	public async Task<IActionResult> Detail(string productId)
	{
		return HandleApiResponse(await Mediator.Send(new ProductDetailQuery { ProductId = productId }));
	}

	[HttpPost("create-new")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> CreateNew([FromBody] CreateNewClotheCommand command,
		CancellationToken cancellationToken = default)
	{
		return HandleApiResponse(await Mediator.Send(command, cancellationToken));
	}

	[HttpPut("edit/{productId}")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> Update(string productId,
		[FromBody] UpdateProductCommand.UpdateProductCommandJsonBody command)
	{
		return HandleApiResponse(await Mediator.Send(new UpdateProductCommand
		{
			ProductId = productId,
			Body = command
		}));
	}

	[HttpPut("import-stock/{productId}/{quantity}")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> ImportStock(string productId, int quantity)
	{
		return HandleApiResponse(await Mediator.Send(new ImportProductStockCommand
		{
			ProductId = productId,
			Quantity = quantity
		}));
	}

	[HttpPut("{productId}/upload-image")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> UploadImage(string productId, [FromForm] IFormFile file)
	{
		return HandleApiResponse(await Mediator.Send(new UploadProductImageCommand(productId, file)));
	}

	[HttpPut("{productId}/restore")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> Restore(string productId)
	{
		return HandleApiResponse(await Mediator.Send(new RestoreProductCommand(productId)));
	}

	[HttpDelete("{productId}")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> Delete(string productId)
	{
		return HandleApiResponse(await Mediator.Send(new DeleteProductCommand(productId)));
	}
}
