using FluentValidation;

namespace OnlineClothes.Application.Features.Category.Queries.Single;

public class GetSingleCategoryQuery : IRequest<JsonApiResponse<CategoryDto>>
{
	public GetSingleCategoryQuery(int id)
	{
		Id = id;
	}

	public int Id { get; init; }
}

public sealed class GetSingleCategoryQueryValidation : AbstractValidator<GetSingleCategoryQuery>
{
	public GetSingleCategoryQueryValidation()
	{
		RuleFor(q => q.Id).NotEmpty();
	}
}
