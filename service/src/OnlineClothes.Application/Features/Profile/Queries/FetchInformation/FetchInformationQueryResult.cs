using OnlineClothes.Domain.Entities;
using OnlineClothes.Domain.Entities.Common;

namespace OnlineClothes.Application.Features.Profile.Queries.FetchInformation;

public class FetchInformationQueryResult
{
	public string Email { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public DateTime LastLogin { get; set; }

	public static FetchInformationQueryResult Create(AccountUser accountUser)
	{
		return new FetchInformationQueryResult
		{
			Email = accountUser.Email,
			FirstName = accountUser.FirstName,
			LastName = accountUser.LastName,
			FullName = FullNameHelper.Create(accountUser.FirstName, accountUser.LastName).FullName,
			ImageUrl = accountUser.ImageUrl,
			LastLogin = accountUser.LastLogin
		};
	}
}
