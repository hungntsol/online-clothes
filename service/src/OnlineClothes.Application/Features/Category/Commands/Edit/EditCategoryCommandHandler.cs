using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Category.Commands.Edit;

public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
	{
		_categoryRepository = categoryRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(EditCategoryCommand request,
		CancellationToken cancellationToken)
	{
		var existingCategory = await _categoryRepository.GetByIntKey(request.Id, cancellationToken);

		existingCategory.Update(request.Payload.Name, request.Payload.Description);
		_categoryRepository.Update(existingCategory);

		return await _unitOfWork.SaveChangesAsync(cancellationToken)
			? JsonApiResponse<EmptyUnitResponse>.Success()
			: JsonApiResponse<EmptyUnitResponse>.Fail();
	}
}
