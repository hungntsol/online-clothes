using Mapster;
using Newtonsoft.Json;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Brand.Commands.Create;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly IBrandRepository _brandRepository;
	private readonly ILogger<CreateBrandCommandHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IBrandRepository brandRepository,
		ILogger<CreateBrandCommandHandler> logger)
	{
		_unitOfWork = unitOfWork;
		_brandRepository = brandRepository;
		_logger = logger;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(CreateBrandCommand request,
		CancellationToken cancellationToken)
	{
		var existedBrand = await _brandRepository.FindOneAsync(new object?[] { request.Id }, cancellationToken);

		if (existedBrand is not null)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail("Brand đã tồn tại");
		}

		var brand = request.Adapt<ClotheBrand>();
		await _brandRepository.InsertAsync(brand, cancellationToken: cancellationToken);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		_logger.LogInformation("Create brand: {object}", JsonConvert.SerializeObject(brand));
		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
