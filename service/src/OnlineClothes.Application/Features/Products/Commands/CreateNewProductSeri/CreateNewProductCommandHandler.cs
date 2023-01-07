using AutoMapper;
using Newtonsoft.Json;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Products.Commands.CreateNewProductSeri;

public class
	CreateNewProductCommandHandler : IRequestHandler<CreateNewProductCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ILogger<CreateNewProductCommandHandler> _logger;
	private readonly IMapper _mapper;
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateNewProductCommandHandler(
		ILogger<CreateNewProductCommandHandler> logger,
		IProductRepository productRepository,
		IUnitOfWork unitOfWork,
		IMapper mapper)
	{
		_logger = logger;
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(CreateNewProductCommand request,
		CancellationToken cancellationToken)
	{
		var product = _mapper.Map<CreateNewProductCommand, Product>(request);

		await _productRepository.AddAsync(product, cancellationToken: cancellationToken);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		_logger.LogError("Create new product seri: {object}", JsonConvert.SerializeObject(product));
		return JsonApiResponse<EmptyUnitResponse>.Created("Tạo dòng sản phẩm thành công");
	}
}
