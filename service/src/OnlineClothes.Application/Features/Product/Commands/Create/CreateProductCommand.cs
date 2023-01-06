using FluentValidation;
using OnlineClothes.Application.Persistence.Schemas.Products;

namespace OnlineClothes.Application.Features.Product.Commands.Create;

public class CreateProductCommand : PutProductInRepoObject, IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	// TODO: image
}

public sealed class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidation()
	{
		RuleFor(q => q.Sku)
			.Matches(@"([a-zA-Z0-9.-])\w+/g").WithMessage("Sku chỉ sử dụng các kí tự [a-z], [0-9] và `-`");
		RuleFor(q => q.Name).NotEmpty();
		RuleFor(q => q.Price).GreaterThanOrEqualTo(0);
		RuleFor(q => q.InStock).GreaterThanOrEqualTo(0);
	}
}
