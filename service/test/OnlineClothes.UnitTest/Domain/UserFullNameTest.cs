using OnlineClothes.Domain.Entities.Common;

namespace OnlineClothes.UnitTest.Domain;

[Collection("Domain Commons")]
public class UserFullNameTest
{
	[Theory]
	[Trait("Category", "Domain_UserFullName")]
	[InlineData("nguyen", "hung")]
	[InlineData("hung", "test")]
	[InlineData("hung", "nguyen thanh")]
	public void Create_FromFirstAndLastName(string first, string last)
	{
		// arrange
		var expectedName = first + " " + last;

		// act
		var fullName = FullNameHelper.Create(first, last);

		// assert
		Assert.Equal(expectedName, fullName.FullName);
		Assert.Equal(first, fullName.FirstName);
		Assert.Equal(last, fullName.LastName);
	}

	[Theory]
	[Trait("Category", "Domain_UserFullName")]
	[InlineData("nguyen hung", "nguyen", "hung")]
	[InlineData("nguyen thanh hung", "nguyen", "thanh hung")]
	public void Create_FromFullNameString(string full, string expectedFirst, string expectedLast)
	{
		// arrange

		// act
		var fullName = FullNameHelper.Create(full);

		// assert
		Assert.Equal(expectedFirst, fullName.FirstName);
		Assert.Equal(expectedLast, fullName.LastName);
	}

	[Theory]
	[Trait("Category", "Domain_UserFullName")]
	[InlineData("hung", "")]
	[InlineData("hung", " ")]
	[InlineData("", "hung")]
	[InlineData(" ", "hung")]
	public void Create_EmptyOrWhiteSpaceFirstOrLast_ThrowException(string first, string last)
	{
		// arrange

		// act

		// assert
		var ex = Assert.Throws<InvalidOperationException>(() => FullNameHelper.Create(first, last));
		Assert.Equal("FirstName or LastName is invalid", ex.Message);
	}

	[Theory]
	[Trait("Category", "Domain_UserFullName")]
	[InlineData("hung ")]
	[InlineData(" hung")]
	[InlineData("  ")]
	[InlineData("zzz")]
	public void Create_EmptyOrWithSpaceFull_ThrowException(string full)
	{
		// arrange

		// act

		// assert
		var ex = Assert.Throws<InvalidOperationException>(() => FullNameHelper.Create(full));
		Assert.Equal("FirstName or LastName is invalid", ex.Message);
	}
}
