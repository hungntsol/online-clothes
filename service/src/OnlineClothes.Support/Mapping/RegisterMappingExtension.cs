using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineClothes.Support.Mapping;

public static class RegisterMappingExtension
{
	public static IServiceCollection AddMapping(this IServiceCollection services)
	{
		var config = new TypeAdapterConfig
		{
			RequireExplicitMapping = false,
			RequireDestinationMemberSource = false,
			Compiler = exp => exp.Compile()
		};

		config.Scan();

		services.AddSingleton(config);
		services.AddTransient<IMapper, ServiceMapper>();

		return services;
	}
}
