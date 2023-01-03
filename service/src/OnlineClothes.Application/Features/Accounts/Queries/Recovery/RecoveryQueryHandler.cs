using MediatR;
using Microsoft.Extensions.Logging;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Domain.Common;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Infrastructure.Services.Mailing.Abstracts;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Exceptions;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Queries.Recovery;

internal sealed class RecoveryQueryHandler : IRequestHandler<RecoveryQuery, JsonApiResponse<RecoveryQueryResult>>
{
	private readonly ILogger<RecoveryQueryHandler> _logger;
	private readonly IMailingService _mailingService;
	private readonly IUnitOfWork _unitOfWork;

	public RecoveryQueryHandler(ILogger<RecoveryQueryHandler> logger,
		IMailingService mailingService, IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_mailingService = mailingService;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<RecoveryQueryResult>> Handle(RecoveryQuery request,
		CancellationToken cancellationToken)
	{
		var tokenCode = await _unitOfWork.AccountTokenRepository.FindOneAsync(
			FilterBuilder<AccountTokenCode>.Where(code =>
				code.TokenCode == request.Token && code.TokenType == AccountTokenType.ResetPassword),
			cancellationToken);

		NullValueReferenceException.ThrowIfNull(tokenCode, nameof(tokenCode));

		if (!tokenCode.IsValid())
		{
			return JsonApiResponse<RecoveryQueryResult>.Fail();
		}

		var newPassword = PasswordHasher.RandomPassword(6);
		var account =
			await _unitOfWork.AccountUserRepository.FindOneAsync(q => q.Email.Equals(tokenCode.Email),
				cancellationToken);

		_unitOfWork.AccountUserRepository.Update(account!);
		var updatedResult = await _unitOfWork.SaveChangesAsync(cancellationToken);
		if (updatedResult)
		{
			return JsonApiResponse<RecoveryQueryResult>.Success(data: new RecoveryQueryResult
				{ NewPassword = newPassword });
		}

		return JsonApiResponse<RecoveryQueryResult>.Fail();
	}
}
