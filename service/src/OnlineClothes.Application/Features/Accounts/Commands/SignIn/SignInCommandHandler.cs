using MediatR;
using OnlineClothes.Domain.Entities;
using OnlineClothes.Infrastructure.Repositories.Abstracts;
using OnlineClothes.Infrastructure.Services.Auth.Abstracts;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Commands.SignIn;

internal sealed class
	SignInCommandHandler : IRequestHandler<SignInCommand, JsonApiResponse<SignInCommandResult>>
{
	private const string ErrorLoginFailMessage = "Email hoặc mật khẩu không chính xác";
	private const string ErrorAccountNotActivateMessage = "Tài khoảng chưa được kích hoạt";
	private readonly IAccountRepository _accountRepository;

	private readonly IAuthService _authService;

	public SignInCommandHandler(IAccountRepository accountRepository, IAuthService authService)
	{
		_accountRepository = accountRepository;
		_authService = authService;
	}

	public async Task<JsonApiResponse<SignInCommandResult>> Handle(SignInCommand request,
		CancellationToken cancellationToken)
	{
		var account =
			await _accountRepository.FindOneAsync(
				FilterBuilder<AccountUser>.Where(acc => acc.Email.Equals(request.Email)), cancellationToken);

		if (account is null || !account.VerifyPassword(request.Password))
		{
			return JsonApiResponse<SignInCommandResult>.Fail(ErrorLoginFailMessage);
		}

		if (!account.IsValid())
		{
			return JsonApiResponse<SignInCommandResult>.Fail(ErrorAccountNotActivateMessage);
		}

		var responseModel = new SignInCommandResult(_authService.CreateJwtAccessToken(account));

		return JsonApiResponse<SignInCommandResult>.Success(data: responseModel);
	}
}
