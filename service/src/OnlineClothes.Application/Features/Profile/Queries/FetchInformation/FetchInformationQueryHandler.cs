﻿namespace OnlineClothes.Application.Features.Profile.Queries.FetchInformation;

internal sealed class
	FetchInformationQueryHandler : IRequestHandler<FetchInformationQuery, JsonApiResponse<FetchInformationQueryResult>>
{
	//private readonly IAccountRepository _accountRepository;
	//private readonly IUserContext _userContext;

	//public FetchInformationQueryHandler(IUserContext userContext, IAccountRepository accountRepository)
	//{
	//	_userContext = userContext;
	//	_accountRepository = accountRepository;
	//}

	public async Task<JsonApiResponse<FetchInformationQueryResult>> Handle(FetchInformationQuery request,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();

		//var account = await _accountRepository.GetOneAsync(_userContext.GetNameIdentifier(), cancellationToken);

		//var responseModel = FetchInformationQueryResult.Create(account);

		//return JsonApiResponse<FetchInformationQueryResult>.Success(data: responseModel);
	}
}
