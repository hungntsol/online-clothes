using Newtonsoft.Json;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Serial.Commands.Create;

public class CreateSerialCommandHandler : IRequestHandler<CreateSerialCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ILogger<CreateSerialCommandHandler> _logger;
	private readonly ISerialRepository _serialRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateSerialCommandHandler(ISerialRepository serialRepository, IUnitOfWork unitOfWork,
		ILogger<CreateSerialCommandHandler> logger)
	{
		_serialRepository = serialRepository;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(CreateSerialCommand request,
		CancellationToken cancellationToken)
	{
		var newSerial = new ProductSerial(request.Name, request.BrandId, request.ClotheType)
		{
			ClotheCategories = request.CategoryIds.Select(q => new ClotheCategory { Id = q, Name = string.Empty })
				.ToList()
		};

		await _serialRepository.InsertAsync(newSerial, cancellationToken: cancellationToken);
		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		_logger.LogInformation("Create serial: {object}", JsonConvert.SerializeObject(newSerial));
		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
