using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Application.Helpers;
using OnlineClothes.Domain.Common;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Commands.SignUp;

internal sealed class
	SignUpCommandHandler : IRequestHandler<SignUpCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly AccountActivationHelper _accountActivationHelper;
	private readonly ILogger<SignUpCommandHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public SignUpCommandHandler(ILogger<SignUpCommandHandler> logger,
		AccountActivationHelper accountActivationHelper,
		IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_accountActivationHelper = accountActivationHelper;
		_unitOfWork = unitOfWork;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(SignUpCommand request,
		CancellationToken cancellationToken)
	{
		var existingAccount =
			await _unitOfWork.AccountUserRepository.FindOneAsync(
				FilterBuilder<AccountUser>.Where(p => p.Email == request.Email),
				cancellationToken);

		if (existingAccount is not null)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail("Tài khoản đã tồn tại");
		}

		var newAccount = AccountUser.Create(request.Email, request.Password,
			Fullname.Create(request.FirstName, request.LastName));

		var activateResult = await _accountActivationHelper.StartNewAccount(newAccount, cancellationToken);
		await _unitOfWork.AccountUserRepository.InsertAsync(newAccount, cancellationToken: cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		_logger.LogInformation("Create new account {Email}", newAccount.Email);

		return activateResult == AccountActivationResult.Activated
			? JsonApiResponse<EmptyUnitResponse>.Success(StatusCodes.Status201Created)
			: JsonApiResponse<EmptyUnitResponse>.Success(StatusCodes.Status201Created, "Kiểm tra email của bạn");
	}
}
