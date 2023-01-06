using System.ComponentModel;
using FluentValidation;

namespace OnlineClothes.Application.Features.Product.Commands.Create;

public class CreateProductCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public string Sku { get; set; } = null!;
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public double Price { get; set; }
	public int InStock { get; set; }
	public ClotheSizeType? SizeType { get; set; }
	public ClotheType? Type { get; set; }
	public int? BrandId { get; set; }
	[DefaultValue(true)] public bool IsPublish { get; set; }

	// TODO: categories, image
}

internal sealed class CreateNewClotheCommandValidation : AbstractValidator<CreateProductCommand>
{
	public CreateNewClotheCommandValidation()
	{
		RuleFor(q => q.Name).NotEmpty();
		RuleFor(q => q.Price).GreaterThan(0);
		RuleFor(q => q.InStock).GreaterThan(0);
	}
}
