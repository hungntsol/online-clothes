using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Brand.Commands.Edit;

public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly IBrandRepository _brandRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
	{
		_brandRepository = brandRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(EditBrandCommand request,
		CancellationToken cancellationToken)
	{
		var brand = await _brandRepository.GetByKey(request.Id, cancellationToken);

		request.PayloadContent.Map(brand);

		_brandRepository.Update(brand);

		return await _unitOfWork.SaveChangesAsync(cancellationToken)
			? JsonApiResponse<EmptyUnitResponse>.Success()
			: JsonApiResponse<EmptyUnitResponse>.Fail();
	}
}
