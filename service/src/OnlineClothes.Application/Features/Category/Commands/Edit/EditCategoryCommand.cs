using FluentValidation;

namespace OnlineClothes.Application.Features.Category.Commands.Edit;

public class EditCategoryCommand : IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	public EditCategoryCommand(int id, Content payload)
	{
		Id = id;
		Payload = payload;
	}

	public int Id { get; init; }
	public Content Payload { get; init; }

	public class Content
	{
		public Content(string name, string? description)
		{
			Name = name;
			Description = description;
		}

		public string Name { get; init; }
		public string? Description { get; init; }
	}
}

public sealed class EditCategoryCommandValidation : AbstractValidator<EditCategoryCommand>
{
	public EditCategoryCommandValidation()
	{
		RuleFor(q => q.Id)
			.NotEmpty();
		RuleFor(q => q.Payload.Name)
			.NotEmpty().WithMessage("Tên không được trống");
	}
}
