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
			.Include(q => q.ClotheCategories)
			.FirstAsync(q => q.Id.Equals(request.Id), cancellationToken: cancellationToken);
		serial.SetName(request.Name);
		serial.SetBrandId(request.BrandId);

		// Begin tx
		await _unitOfWork.BeginTransactionAsync(cancellationToken);

		var categories = await _categoryRepository.AsQueryable()
			.Where(q => request.CategoryIds.Contains(q.Id))
			.ToListAsync(cancellationToken);
		_categoryRepository.Table.AttachRange(categories);

		serial.ClotheCategories.Clear();
		serial.ClotheCategories = categories;
		_serialRepository.Update(serial);
		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		// Commit tx
		await _unitOfWork.CommitAsync(cancellationToken);

		return save ? JsonApiResponse<EmptyUnitResponse>.Success() : JsonApiResponse<EmptyUnitResponse>.Fail();
	}
}
