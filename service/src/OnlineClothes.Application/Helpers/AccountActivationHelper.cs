using Microsoft.Extensions.Options;
using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Application.Apply.Services.Mailing.Models;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Infrastructure.Services.Mailing.Abstracts;
using OnlineClothes.Infrastructure.Services.Mailing.Models;
using OnlineClothes.Infrastructure.StandaloneConfigurations;

namespace OnlineClothes.Application.Helpers;

public class AccountActivationHelper
{
	private readonly AccountActivationConfiguration _accountActivationConfiguration;
	private readonly AppDomainConfiguration _domainConfiguration;
	private readonly IMailingService _mailingService;
	private readonly ITokenRepository _tokenRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AccountActivationHelper(IOptions<AppDomainConfiguration> domainConfigurationOption,
		IOptions<AccountActivationConfiguration> accountActivationConfigurationOption,
		IMailingService mailingService,
		IUnitOfWork unitOfWork,
		ITokenRepository tokenRepository)
	{
		_accountActivationConfiguration = accountActivationConfigurationOption.Value;
		_domainConfiguration = domainConfigurationOption.Value;
		_mailingService = mailingService;
		_unitOfWork = unitOfWork;
		_tokenRepository = tokenRepository;
	}

	public async Task<AccountActivationResult> StartNewAccount(AccountUser account,
		CancellationToken cancellationToken = default)
	{
		if (!_accountActivationConfiguration.ByEmail)
		{
			account.Activate();
			return AccountActivationResult.Activated;
		}

		var newTokenCode = await CreateVerificationTokenCode(account, cancellationToken);
		await SendActivationMail(account, cancellationToken, newTokenCode);

		return AccountActivationResult.WaitConfirm;
	}

	private async Task<AccountTokenCode> CreateVerificationTokenCode(AccountUser account,
		CancellationToken cancellationToken)
	{
		var newTokenCode = new AccountTokenCode(account.Email, AccountTokenType.Verification, TimeSpan.FromMinutes(15));
		await _tokenRepository.InsertAsync(newTokenCode, cancellationToken: cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return newTokenCode;
	}

	private async Task SendActivationMail(AccountUser account, CancellationToken cancellationToken,
		AccountTokenCode newTokenCode)
	{
		var mail = new MailingTemplate(account.Email, "Verify Account", EmailTemplateNames.VerifyAccount,
			new
			{
				ConfirmedUrl =
					$"{_domainConfiguration}/api/v1/accounts/activate?token={newTokenCode.TokenCode}"
			});

		await _mailingService.SendEmailAsync(mail, cancellationToken);
	}
}

public enum AccountActivationResult
{
	WaitConfirm,
	Activated
}
