using MediatR;
using OnlineClothes.Application.Apply.Persistence.Abstracts;
using OnlineClothes.Application.Apply.Services.Auth;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.HttpResponse;

namespace OnlineClothes.Application.Features.Accounts.Commands.SignIn;

internal sealed class
	SignInCommandHandler : IRequestHandler<SignInCommand, JsonApiResponse<SignInCommandResult>>
{
	private const string ErrorLoginFailMessage = "Email hoặc mật khẩu không chính xác";
	private const string ErrorAccountNotActivateMessage = "Tài khoảng chưa được kích hoạt";

	private readonly IAuthorizeService _authorizeService;
	private readonly IUnitOfWork _unitOfWork;

	public SignInCommandHandler(IAuthorizeService authorizeService, IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
		_authorizeService = authorizeService;
	}

	public async Task<JsonApiResponse<SignInCommandResult>> Handle(SignInCommand request,
		CancellationToken cancellationToken)
	{
		var account =
			await _unitOfWork.AccountUserRepository.FindOneAsync(
				FilterBuilder<AccountUser>.Where(q => q.Email.Equals(request.Email)), cancellationToken);

		if (account is null || !account.VerifyPassword(request.Password))
		{
			return JsonApiResponse<SignInCommandResult>.Fail(ErrorLoginFailMessage);
		}

		if (!account.IsValid())
		{
			return JsonApiResponse<SignInCommandResult>.Fail(ErrorAccountNotActivateMessage);
		}

		var responseModel = new SignInCommandResult(_authorizeService.CreateJwtAccessToken(account));

		return JsonApiResponse<SignInCommandResult>.Success(data: responseModel);
	}
}
