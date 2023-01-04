using MediatR;
using Microsoft.Extensions.Logging;
using OnlineClothes.Application.Apply.Persistence;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Domain.Common;
using OnlineClothes.Infrastructure.Services.UserContext.Abstracts;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Commands.ChangePassword;

internal sealed class
	ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly IAccountRepository _accountRepository;
	private readonly ILogger<ChangePasswordCommandHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContext _userContext;

	public ChangePasswordCommandHandler(ILogger<ChangePasswordCommandHandler> logger,
		IUserContext userContext,
		IUnitOfWork unitOfWork,
		IAccountRepository accountRepository)
	{
		_logger = logger;
		_userContext = userContext;
		_unitOfWork = unitOfWork;
		_accountRepository = accountRepository;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(ChangePasswordCommand request,
		CancellationToken cancellationToken)
	{
		var account =
			await _accountRepository.FindOneAsync(
				new object?[] { _userContext.GetNameIdentifier() }, cancellationToken);

		if (account != null && !account.VerifyPassword(request.CurrentPassword))
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail("Mật khẩu hiện tại không chính xác");
		}

		var newHashPassword = PasswordHasher.Hash(request.NewPassword);
		account!.HashedPassword = newHashPassword;
		_accountRepository.UpdateOneField(
			account,
			p => p.HashedPassword);

		var updatedResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

		return updatedResult
			? JsonApiResponse<EmptyUnitResponse>.Success()
			: JsonApiResponse<EmptyUnitResponse>.Fail();
	}
}
