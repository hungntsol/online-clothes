using MediatR;
using Microsoft.Extensions.Logging;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Exceptions;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Queries.Activate;

internal sealed class ActivateQueryHandler : IRequestHandler<ActivateQuery, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly ILogger<ActivateQueryHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public ActivateQueryHandler(ILogger<ActivateQueryHandler> logger, IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(ActivateQuery request,
		CancellationToken cancellationToken)
	{
		var tokenCode = await _unitOfWork.AccountTokenRepository.FindOneAsync(FilterBuilder<AccountTokenCode>.Where(x =>
			x.TokenCode == request.Token && x.TokenType == AccountTokenType.Verification), cancellationToken);

		NullValueReferenceException.ThrowIfNull(tokenCode, nameof(tokenCode));

		if (!tokenCode.IsValid())
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail();
		}

		var account =
			await _unitOfWork.AccountUserRepository.FindOneAsync(q => q.Email.Equals(tokenCode.Email),
				cancellationToken);

		NullValueReferenceException.ThrowIfNull(account);

		// Begin tx
		await _unitOfWork.BeginTransactionAsync(cancellationToken);

		account.Activate();
		_unitOfWork.AccountUserRepository.Update(account);

		var updateResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

		if (updateResult)
		{
			_unitOfWork.AccountTokenRepository.Delete(tokenCode);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			_logger.LogInformation("Account {Email} is activated", tokenCode.Email);
		}

		try
		{
			// Commit
			await _unitOfWork.CommitAsync(cancellationToken);
			return JsonApiResponse<EmptyUnitResponse>.Success();
		}
		catch (Exception e)
		{
			_logger.LogError(e, "{message}", e.Message);
			throw new Exception(e.Message);
		}
	}
}
