namespace OnlineClothes.Application.Services.UserContext;

public interface IUserContext
{
	int GetNameIdentifier();

	string GetAccountEmail();

	string GetRole();
}
