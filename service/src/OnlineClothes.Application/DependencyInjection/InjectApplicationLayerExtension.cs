﻿using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineClothes.Application.Middlewares;
using OnlineClothes.Application.PipelineBehaviors;

namespace OnlineClothes.Application.DependencyInjection;

public static class InjectApplicationLayerExtension
{
	public static void InjectApplicationLayer(this IServiceCollection services,
		IConfiguration configuration,
		Assembly assembly)
	{
		services.AddMediatR(Assembly.GetExecutingAssembly());
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddTransient<ExceptionHandlingMiddleware>();
	}
}
