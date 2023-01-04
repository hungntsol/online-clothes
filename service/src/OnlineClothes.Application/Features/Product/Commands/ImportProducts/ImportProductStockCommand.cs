using FluentValidation;

namespace OnlineClothes.Application.Features.Product.Commands.ImportProducts;

public class ImportProductStockCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public string ProductId { get; set; } = null!;
	public int Quantity { get; set; }
}

public class ImportProductsCommandValidation : AbstractValidator<ImportProductStockCommand>
{
	public ImportProductsCommandValidation()
	{
		RuleFor(q => q.ProductId)
			.NotEmpty().WithMessage("Mã sản phẩm không được trống");
	}
}
