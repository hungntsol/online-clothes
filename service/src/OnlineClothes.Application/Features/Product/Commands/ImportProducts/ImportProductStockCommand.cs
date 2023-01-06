using FluentValidation;

namespace OnlineClothes.Application.Features.Product.Commands.ImportProducts;

public class ImportProductStockCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public int ProductId { get; set; }
	public int Quantity { get; set; }
}

public class ImportProductsCommandValidation : AbstractValidator<ImportProductStockCommand>
{
	public ImportProductsCommandValidation()
	{
		RuleFor(q => q.ProductId)
			.NotEmpty().WithMessage("Mã sản phẩm không được trống");
		RuleFor(q => q.Quantity)
			.GreaterThanOrEqualTo(0);
	}
}
