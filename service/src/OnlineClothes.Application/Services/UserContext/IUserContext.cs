namespace OnlineClothes.Application.Services.UserContext;

public interface IUserContext
{
	string GetNameIdentifier();

	string GetAccountEmail();

	string GetRole();
}
