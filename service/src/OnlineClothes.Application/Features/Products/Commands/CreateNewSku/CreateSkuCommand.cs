using FluentValidation;

namespace OnlineClothes.Application.Features.Products.Commands.CreateNewSku;

public class CreateSkuCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public int ProductId { get; set; }
	public string Sku { get; set; } = null!;
	public decimal AddOnPrice { get; set; }
	public int InStock { get; set; }

	public ClotheSizeType Size { get; set; }
	// TODO: image
}

public sealed class CreateProductCommandValidation : AbstractValidator<CreateSkuCommand>
{
	public CreateProductCommandValidation()
	{
		RuleFor(q => q.Sku)
			.Matches(@"([a-zA-Z0-9.-])\w+/g").WithMessage("Sku chỉ sử dụng các kí tự [a-z], [0-9] và `-`");
		RuleFor(q => q.AddOnPrice).GreaterThanOrEqualTo(0);
		RuleFor(q => q.InStock).GreaterThanOrEqualTo(0);
		RuleFor(q => q.ProductId).GreaterThanOrEqualTo(0);
	}
}
