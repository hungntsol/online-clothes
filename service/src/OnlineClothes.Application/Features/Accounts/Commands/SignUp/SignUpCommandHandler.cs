using Microsoft.AspNetCore.Http;
using OnlineClothes.Application.Helpers;
using OnlineClothes.Application.Persistence;

namespace OnlineClothes.Application.Features.Accounts.Commands.SignUp;

internal sealed class
	SignUpCommandHandler : IRequestHandler<SignUpCommand, JsonApiResponse<EmptyUnitResponse>>
{
	private readonly AccountActivationHelper _accountActivationHelper;
	private readonly IAccountRepository _accountRepository;
	private readonly ILogger<SignUpCommandHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public SignUpCommandHandler(ILogger<SignUpCommandHandler> logger,
		AccountActivationHelper accountActivationHelper,
		IUnitOfWork unitOfWork,
		IAccountRepository accountRepository)
	{
		_logger = logger;
		_accountActivationHelper = accountActivationHelper;
		_unitOfWork = unitOfWork;
		_accountRepository = accountRepository;
	}

	public async Task<JsonApiResponse<EmptyUnitResponse>> Handle(SignUpCommand request,
		CancellationToken cancellationToken)
	{
		var existingAccount = await _accountRepository.GetByEmail(request.Email, cancellationToken);

		if (existingAccount is not null)
		{
			return JsonApiResponse<EmptyUnitResponse>.Fail("Tài khoản đã tồn tại");
		}

		var newAccount = AccountUser.Create(request.Email, request.Password,
			Fullname.Create(request.FirstName, request.LastName));

		var activateResult = await _accountActivationHelper.StartNewAccount(newAccount, cancellationToken);
		await _accountRepository.AddAsync(newAccount, cancellationToken: cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		_logger.LogInformation("Create new account {Email}", newAccount.Email);

		return activateResult == AccountActivationResult.Activated
			? JsonApiResponse<EmptyUnitResponse>.Success(StatusCodes.Status201Created)
			: JsonApiResponse<EmptyUnitResponse>.Success(StatusCodes.Status201Created, "Kiểm tra email của bạn");
	}
}
