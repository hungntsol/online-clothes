using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Application.Apply.Services.Mailing.Models;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Infrastructure.Services.Mailing.Abstracts;
using OnlineClothes.Infrastructure.Services.Mailing.Models;
using OnlineClothes.Infrastructure.StandaloneConfigurations;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Exceptions;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Commands.Reset;

internal sealed class ResetCommandHandler : IRequestHandler<ResetCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly AppDomainConfiguration _domainConfiguration;
	private readonly ILogger<ResetCommand> _logger;
	private readonly IMailingService _mailingService;
	private readonly IUnitOfWork _unitOfWork;

	public ResetCommandHandler(ILogger<ResetCommand> logger,
		IOptions<AppDomainConfiguration> appDomainOptions, IMailingService mailingService, IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_mailingService = mailingService;
		_unitOfWork = unitOfWork;
		_domainConfiguration = appDomainOptions.Value;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(ResetCommand request,
		CancellationToken cancellationToken)
	{
		var account = await _unitOfWork.AccountUserRepository.FindOneAsync(
			FilterBuilder<AccountUser>.Where(acc => acc.Email.Equals(request.Email)), cancellationToken);

		NullValueReferenceException.ThrowIfNull(account, nameof(account));

		var recoveryCode =
			new AccountTokenCode(account.Email, AccountTokenType.ResetPassword, TimeSpan.FromMinutes(15));

		await _unitOfWork.AccountTokenRepository.InsertAsync(recoveryCode, cancellationToken: cancellationToken);

		var mail = new MailingTemplate(account.Email, "Recovery account", EmailTemplateNames.ResetPassword,
			new
			{
				RecoveryUrl = $"{_domainConfiguration}/api/v1/accounts/recovery?token={recoveryCode.TokenCode}"
			});

		await _mailingService.SendEmailAsync(mail, cancellationToken);

		_logger.LogInformation("Account {Email} request for resetting password", account.Email);

		return JsonApiResponse<EmptyUnitResponse>.Success();
	}
}
