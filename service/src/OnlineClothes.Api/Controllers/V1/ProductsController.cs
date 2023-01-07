using Microsoft.AspNetCore.Authorization;
using OnlineClothes.Application.Features.Products.Commands.CreateNewSku;
using OnlineClothes.Application.Features.Products.Commands.Delete;
using OnlineClothes.Application.Features.Products.Commands.ImportProducts;
using OnlineClothes.Application.Features.Products.Commands.Restore;
using OnlineClothes.Application.Features.Products.Commands.UpdateInfo;
using OnlineClothes.Application.Features.Products.Commands.UploadImage;
using OnlineClothes.Application.Features.Products.Queries.Detail;
using OnlineClothes.Application.Features.Products.Queries.Paging;
using OnlineClothes.Domain.Common;

namespace OnlineClothes.Api.Controllers.V1;

public class ProductsController : ApiV1ControllerBase
{
	public ProductsController(IMediator mediator) : base(mediator)
	{
	}


	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetPaging([FromQuery] GetPagingProductQuery query)
	{
		return HandleApiResponse(await Mediator.Send(query));
	}

	[HttpGet("{sku}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetDetail(string sku)
	{
		return HandleApiResponse(await Mediator.Send(new GetSkuDetailQuery(sku)));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateSkuCommand inRepoCommand,
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
	public async Task<IActionResult> ImportStock([FromBody] ImportSkuStockCommand request)
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

	[HttpDelete("{sku}")]
	public async Task<IActionResult> Delete(string sku)
	{
		return HandleApiResponse(await Mediator.Send(new DisableSkuCommand(sku)));
	}
}
