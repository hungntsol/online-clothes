using Microsoft.AspNetCore.Authorization;
using OnlineClothes.Application.Features.Product.Commands.Create;
using OnlineClothes.Application.Features.Product.Commands.Delete;
using OnlineClothes.Application.Features.Product.Commands.ImportProducts;
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

	[HttpGet("{id:int}")]
	[AllowAnonymous]
	public async Task<IActionResult> Detail(int id)
	{
		return HandleApiResponse(await Mediator.Send(new GetProductDetailQuery(id)));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateProductCommand inRepoCommand,
		CancellationToken cancellationToken = default)
	{
		return HandleApiResponse(await Mediator.Send(inRepoCommand, cancellationToken));
	}

	[HttpPut("edit")]
	public async Task<IActionResult> Update([FromBody] EditProductCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpPut("import-stock")]
	public async Task<IActionResult> ImportStock([FromBody] ImportProductStockCommand request)
	{
		return HandleApiResponse(await Mediator.Send(request));
	}

	[HttpPut("{id}/upload-image")]
	[Authorize(Roles = nameof(AccountRole.Admin))]
	public async Task<IActionResult> UploadImage(string id, [FromForm] IFormFile file)
	{
		return HandleApiResponse(await Mediator.Send(new UploadProductImageCommand(id, file)));
	}

	[HttpPut("{id:int}/restore")]
	public async Task<IActionResult> Restore(int id)
	{
		return HandleApiResponse(await Mediator.Send(new RestoreProductCommand(id)));
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		return HandleApiResponse(await Mediator.Send(new DeleteProductCommand(id)));
	}
}
