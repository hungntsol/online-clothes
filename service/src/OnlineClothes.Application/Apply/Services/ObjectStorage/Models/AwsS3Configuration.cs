using OnlineClothes.Infrastructure.StandaloneConfigurations;

namespace OnlineClothes.Application.Apply.Services.ObjectStorage.Models;

public class AwsS3Configuration
{
	public AwsCredential Credential { get; init; } = null!;
	public string BucketName { get; init; } = null!;
	public string Region { get; init; } = null!;
	public string Endpoint { get; init; } = null!;
}
