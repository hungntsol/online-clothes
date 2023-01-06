using FluentValidation;
using OnlineClothes.Application.Persistence.Schemas.Products;

namespace OnlineClothes.Application.Features.Products.Commands.UpdateInfo;

public class EditProductCommand : PutProductInRepoObject, IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public int Id { get; set; }
}

public sealed class UpdateProductCommandValidation : AbstractValidator<EditProductCommand>
{
	public UpdateProductCommandValidation()
	{
		RuleFor(q => q.Name)
			.NotEmpty().WithMessage("Tên sản phẩm không được để trống");
		RuleFor(q => q.Price)
			.GreaterThanOrEqualTo(0);
		RuleFor(q => q.InStock)
			.GreaterThanOrEqualTo(0);
	}
}
