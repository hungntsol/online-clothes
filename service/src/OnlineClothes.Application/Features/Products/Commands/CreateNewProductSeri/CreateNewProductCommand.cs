using System.ComponentModel;
using FluentValidation;

namespace OnlineClothes.Application.Features.Products.Commands.CreateNewProductSeri;

public class CreateNewProductCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public decimal Price { get; set; }
	[DefaultValue(null)] public int? BrandId { get; set; }
	public ClotheType? Type { get; set; }
	public HashSet<int> CategoryIds { get; set; } = new();
	[DefaultValue(true)] public bool IsPublish { get; set; }
}

public class CreateNewProductCommandValidation : AbstractValidator<CreateNewProductCommand>
{
	public CreateNewProductCommandValidation()
	{
		RuleFor(q => q.Name).NotEmpty();
		RuleFor(q => q.Price).GreaterThanOrEqualTo(0);
	}
}
