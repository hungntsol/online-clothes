using System.Reflection;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineClothes.Infrastructure.Repositories;
using OnlineClothes.Infrastructure.Repositories.Abstracts;
using OnlineClothes.Infrastructure.Services.Auth;
using OnlineClothes.Infrastructure.Services.Auth.Abstracts;
using OnlineClothes.Infrastructure.Services.Mailing;
using OnlineClothes.Infrastructure.Services.Mailing.Abstracts;
using OnlineClothes.Infrastructure.Services.Mailing.Engine;
using OnlineClothes.Infrastructure.Services.Storage.Abstracts;
using OnlineClothes.Infrastructure.Services.Storage.AwsS3;
using OnlineClothes.Infrastructure.Services.UserContext;
using OnlineClothes.Infrastructure.Services.UserContext.Abstracts;
using OnlineClothes.Infrastructure.StandaloneConfigurations;

namespace OnlineClothes.Infrastructure;

public static class DependencyInjection
{
	public static void RegisterInfrastructureLayer(this IServiceCollection services,
		IConfiguration configuration,
		Assembly? assembly = null)
	{
		services.RegisterRepositories();
		services.RegisterServices(configuration);

		services.Configure<AppDomainConfiguration>(configuration.GetSection("AppDomain"));
	}

	public static void RegisterRepositories(this IServiceCollection services)
	{
		services.AddTransient<IAccountRepository, AccountRepository>();
		services.AddTransient<IAccountTokenCodeRepository, AccountTokenCodeRepository>();
		services.AddTransient<IProductRepository, ProductRepository>();
		services.AddTransient<ICartRepository, CartRepository>();
		services.AddTransient<IOrderRepository, OrderRepository>();
	}

	public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
	{
		// auth
		services.AddTransient<IAuthService, AuthService>();

		// mailing
		services.AddSingleton<IMailingProviderConnection, MailingProviderConnection>();
		services.AddTransient<IMailingService, MailingService>();
		services.Configure<MailingProviderConfiguration>(configuration.GetSection("Mailing"));
		services.AddTransient<RazorEngineRenderer>();
		services.CacheEmailTemplateInMemory();

		// context
		services.AddTransient<IUserContext, UserContext>();

		// account activate
		services.Configure<AccountActivationConfiguration>(configuration.GetSection("AccountActivation"));

		// amazon s3
		services.AddAWSService<IAmazonS3>();
		services.AddTransient<IObjectFileStorage, AwsObjectStorage>();
		services.Configure<AwsS3Configuration>(configuration.GetSection("AwsS3"));
	}

	/// <summary>
	///     Cache raw html email template to memory
	/// </summary>
	/// <param name="services"></param>
	private static void CacheEmailTemplateInMemory(this IServiceCollection services)
	{
		var scope = services.BuildServiceProvider().CreateScope();
		var renderer = scope.ServiceProvider.GetRequiredService<RazorEngineRenderer>();
		renderer.LoadTemplateToMemory();
	}
}