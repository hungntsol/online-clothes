using FluentValidation;

namespace OnlineClothes.Application.Features.Brand.Commands.Create;

public class CreateBrandCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public CreateBrandCommand(string id, string name, string description, string contactEmail)
	{
		Id = id;
		Name = name;
		Description = description;
		ContactEmail = contactEmail;
	}

	public string Id { get; set; }
	public string Name { get; init; }
	public string Description { get; init; }
	public string ContactEmail { get; init; }
}

public class CreateBrandCommandValidation : AbstractValidator<CreateBrandCommand>
{
	public CreateBrandCommandValidation()
	{
		RuleFor(q => q.Name).NotEmpty();
	}
}
