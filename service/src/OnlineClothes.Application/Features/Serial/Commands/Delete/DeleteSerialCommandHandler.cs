using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Serial.Commands.Delete;

public class DeleteSerialCommandHandler : IRequestHandler<DeleteSerialCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ILogger<DeleteSerialCommandHandler> _logger;
	private readonly ISerialRepository _serialRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteSerialCommandHandler(ISerialRepository serialRepository, IUnitOfWork unitOfWork,
		ILogger<DeleteSerialCommandHandler> logger)
	{
		_serialRepository = serialRepository;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(DeleteSerialCommand request,
		CancellationToken cancellationToken)
	{
		var serial = await _serialRepository.GetByIntKey(request.Id, cancellationToken);

		_serialRepository.Delete(serial);

		// delete categories of serial
		serial.SerialCategories.Clear();

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		_logger.LogInformation("Delete Serial: Id={id}", serial.Id);
		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
