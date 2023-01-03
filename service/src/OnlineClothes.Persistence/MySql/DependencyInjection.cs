using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Persistence.MySql.Context;
using OnlineClothes.Persistence.MySql.Repositories;
using OnlineClothes.Persistence.MySql.Uow;

namespace OnlineClothes.Persistence.MySql;

public static class DependencyInjection
{
	public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
		{
			var connectionString = configuration.GetConnectionString("AppContext");
			options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 31)),
				mySqlOption =>
				{
					mySqlOption.MigrationsAssembly("OnlineClothes.Persistence"); // TODO: remove hard-code
				});
		});

		services.AddScoped<IUnitOfWork, UnitOfWork>()
			.AddTransient<IAccountUserRepository, AccountUserRepository>()
			.AddTransient<IAccountTokenRepository, AccountTokenRepository>();

		return services;
	}
}
