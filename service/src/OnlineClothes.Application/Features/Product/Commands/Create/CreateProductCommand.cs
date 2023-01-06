﻿using FluentValidation;
using OnlineClothes.Application.Persistence.Schemas.Products;

namespace OnlineClothes.Application.Features.Product.Commands.Create;

public class CreateProductCommand : CreateProductObjectSchema, IRequest<JsonApiResponse<EmptyUnitResponse>>
{
	// TODO: image
}

internal sealed class CreateNewClotheCommandValidation : AbstractValidator<CreateProductCommand>
{
	public CreateNewClotheCommandValidation()
	{
		RuleFor(q => q.Name).NotEmpty();
		RuleFor(q => q.Price).GreaterThan(0);
		RuleFor(q => q.InStock).GreaterThan(0);
	}
}
