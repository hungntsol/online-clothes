using MediatR;
using Microsoft.Extensions.Logging;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Application.Helpers;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Queries.ResendActivation;

public sealed class
	ResendActivationQueryHandler : IRequestHandler<ResendActivationQuery, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly AccountActivationHelper _accountActivationHelper;
	private readonly ILogger<ResendActivationQueryHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public ResendActivationQueryHandler(ILogger<ResendActivationQueryHandler> logger,
		AccountActivationHelper accountActivationHelper,
		IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_accountActivationHelper = accountActivationHelper;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(ResendActivationQuery request,
		CancellationToken cancellationToken)
	{
		var account = await _unitOfWork.AccountUserRepository.GetByEmail(request.Email, cancellationToken);

		if (account is null)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		var activateResult = await _accountActivationHelper.StartNewAccount(account, cancellationToken);

		_logger.LogInformation("Resend activate account {Email}", account.Email);

		return activateResult == AccountActivationResult.Activated
			? JsonApiResponse<EmptyUnitResponse>.Success()
			: JsonApiResponse<EmptyUnitResponse>.Success(message: "Kiểm tra email của bạn");
	}
}
