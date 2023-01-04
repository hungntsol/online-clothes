using FluentValidation;

namespace OnlineClothes.Application.Features.Product.Commands.NewProduct;

public class CreateNewClotheCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public string Sku { get; init; } = null!;
	public string Name { get; init; } = null!;
	public string Description { get; init; } = null!;
	public HashSet<string> Categories { get; init; } = new();
}

internal sealed class CreateNewClotheCommandValidation : AbstractValidator<CreateNewClotheCommand>
{
}
