using Newtonsoft.Json;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Serial.Commands.Create;

public class CreateSerialCommandHandler : IRequestHandler<CreateSerialCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ILogger<CreateSerialCommandHandler> _logger;
	private readonly ISerialRepository _serialRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateSerialCommandHandler(ISerialRepository serialRepository,
		IUnitOfWork unitOfWork,
		ILogger<CreateSerialCommandHandler> logger,
		ICategoryRepository categoryRepository)
	{
		_serialRepository = serialRepository;
		_unitOfWork = unitOfWork;
		_logger = logger;
		_categoryRepository = categoryRepository;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(CreateSerialCommand request,
		CancellationToken cancellationToken)
	{
		var newSerial = new Domain.Entities.Aggregate.Serial(request.Name, request.BrandId, request.ClotheType);

		// Begin tx
		await _unitOfWork.BeginTransactionAsync(cancellationToken);

		await _serialRepository.AddAsync(newSerial, cancellationToken: cancellationToken);
		newSerial.AssignCategoryNavigation(request.CategoryIds);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);
		if (!save)
		{
			await _unitOfWork.RollbackAsync(cancellationToken);
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		// Commit tx
		await _unitOfWork.CommitAsync(cancellationToken);

		_logger.LogInformation("Create serial: {object}", JsonConvert.SerializeObject(newSerial));

		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
