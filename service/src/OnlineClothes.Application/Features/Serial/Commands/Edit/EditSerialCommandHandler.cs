using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Persistence;

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
		var serial = await _serialRepository
			.AsQueryable()
			.Include(q => q.SerialCategories)
			.FirstAsync(q => q.Id.Equals(request.Id), cancellationToken: cancellationToken);

		_serialRepository.Update(serial);

		// Begin tx
		await _unitOfWork.BeginTransactionAsync(cancellationToken);

		serial.AssignCategoryNavigation(request.CategoryIds);
		serial.SetName(request.Name);
		serial.SetBrandId(request.BrandId);

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
