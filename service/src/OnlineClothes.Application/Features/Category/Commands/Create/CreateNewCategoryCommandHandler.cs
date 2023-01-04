﻿using System.Text.Json;
using OnlineClothes.Application.Persistence;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Application.Features.Category.Commands.Create;

public sealed class
	CreateNewCategoryCommandHandler : IRequestHandler<CreateNewCategoryCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ILogger<CreateNewCategoryCommandHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public CreateNewCategoryCommandHandler(ILogger<CreateNewCategoryCommandHandler> logger,
		ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_categoryRepository = categoryRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(CreateNewCategoryCommand request,
		CancellationToken cancellationToken)
	{
		var category = new ClotheCategory(request.Name, request.Description);
		await _categoryRepository.InsertAsync(category, cancellationToken: cancellationToken);
		var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (!save) return JsonApiResponse<EmptyUnitResponse>.Fail();

		_logger.LogInformation("Create category: {object}", JsonSerializer.Serialize(category));
		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}