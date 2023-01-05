using FluentValidation;

namespace OnlineClothes.Application.Features.Brand.Commands.Edit;

public class EditBrandCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public EditBrandCommand(string id, Content payloadContent)
	{
		Id = id;
		PayloadContent = payloadContent;
	}

	public string Id { get; init; }

	public Content PayloadContent { get; init; }

	public class Content
	{
		public Content(string name, string description, string contactEmail)
		{
			Name = name;
			Description = description;
			ContactEmail = contactEmail;
		}

		public string Name { get; init; }
		public string Description { get; init; }
		public string ContactEmail { get; init; }

		public void Map(Domain.Entities.Aggregate.Brand brand)
		{
			brand.ContactEmail = ContactEmail;
			brand.Name = Name;
			brand.Description = Description;
		}
	}
}

public class EditBrandCommandValidation : AbstractValidator<EditBrandCommand>
{
	public EditBrandCommandValidation()
	{
		RuleFor(q => q.PayloadContent.Name).NotEmpty();
	}
}
