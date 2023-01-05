using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Persistence.Schemas.Serials;

namespace OnlineClothes.Application.Features.Serial.Commands.Edit;

public class EditSerialCommandHandler : IRequestHandler<EditSerialCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ISerialRepository _serialRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditSerialCommandHandler(ISerialRepository serialRepository, ICategoryRepository categoryRepository,
		IUnitOfWork unitOfWork)
	{
		_serialRepository = serialRepository;
		_categoryRepository = categoryRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(EditSerialCommand request,
		CancellationToken cancellationToken)
	{
		// Begin tx
		await _unitOfWork.BeginTransactionAsync(cancellationToken);

		var serial = await _serialRepository.UpdateCategoryNavigationAsync(request.Id,
			new UpdateCategoryNavigationRequest(request.Name, request.BrandId, request.Type, request.CategoryIds));

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save)
		{
			await _unitOfWork.RollbackAsync(cancellationToken);
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		// Commit tx
		await _unitOfWork.CommitAsync(cancellationToken);

		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
