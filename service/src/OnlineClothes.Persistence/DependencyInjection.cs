using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineClothes.Application.Persistence.Abstracts;
using OnlineClothes.Persistence.Context;
using OnlineClothes.Persistence.Uow;

namespace OnlineClothes.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
		{
			var connectionString = configuration.GetConnectionString("AppContext");
			options.UseNpgsql(connectionString,
				optionsBuilder =>
				{
					optionsBuilder.MigrationsAssembly("OnlineClothes.Persistence"); // TODO: remove hard-code
				});
		});

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}
