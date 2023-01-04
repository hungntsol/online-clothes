using System.Security.Claims;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Application.Services.Auth;

public interface IAuthorizeService
{
	string CreateJwtAccessToken(AccountUser account);

	List<Claim> ValidateJwtToken(string jwt);
}
