using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Application.Persistence.Schemas.Products;

namespace OnlineClothes.Application.Features.Product.Commands.Create;

public sealed class
	CreateProductCommandHandler : IRequestHandler<CreateProductCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly IBrandRepository _brandRepository;
	private readonly ICategoryRepository _categoryRepository;
	private readonly ILogger<CreateProductCommandHandler> _logger;
	private readonly IMapper _mapper;
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductCommandHandler(
		ILogger<CreateProductCommandHandler> logger,
		IProductRepository productRepository,
		IUnitOfWork unitOfWork,
		IBrandRepository brandRepository,
		IMapper mapper,
		ICategoryRepository categoryRepository)
	{
		_logger = logger;
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
		_brandRepository = brandRepository;
		_mapper = mapper;
		_categoryRepository = categoryRepository;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(CreateProductCommand request,
		CancellationToken cancellationToken)
	{
		// Begin tx
		await _unitOfWork.BeginTransactionAsync(cancellationToken);

		var product =
			await _productRepository.CreateOneAsync(
				_mapper.Map<CreateProductCommand, CreateProductObjectSchema>(request), cancellationToken);

		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		// Commit tx
		await _unitOfWork.CommitAsync(cancellationToken);

		_logger.LogInformation("Create product: {model}", JsonConvert.SerializeObject(product));

		return JsonApiResponse<EmptyUnitResponse>.Success(StatusCodes.Status201Created, "Thêm sản phẩm thành công");
	}
}
