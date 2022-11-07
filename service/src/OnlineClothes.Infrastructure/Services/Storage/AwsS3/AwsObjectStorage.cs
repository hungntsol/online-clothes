﻿using System.Net;
using System.Net.Sockets;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineClothes.Infrastructure.Services.Storage.Abstracts;
using OnlineClothes.Infrastructure.Services.Storage.Models;
using OnlineClothes.Support.Exceptions.HttpExceptionCodes;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;

namespace OnlineClothes.Infrastructure.Services.Storage.AwsS3;

public class AwsObjectStorage : IObjectFileStorage
{
	private readonly IAmazonS3 _amazonS3;
	private readonly AsyncRetryPolicy _asyncRetryPolicy;
	private readonly AwsS3Configuration _awsS3Configuration;
	private readonly ILogger<AwsObjectStorage> _logger;

	public AwsObjectStorage(ILogger<AwsObjectStorage> logger,
		IAmazonS3 amazonS3,
		IOptions<AwsS3Configuration> awsS3ConfigurationOption)
	{
		_logger = logger;
		_amazonS3 = amazonS3;
		_awsS3Configuration = awsS3ConfigurationOption.Value;

		_asyncRetryPolicy = Policy
			.Handle<HttpRequestException>()
			.Or<SocketException>()
			.Or<Exception>()
			.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5),
				onRetry: (ex, span) => _logger.LogError(ex, "Fail attempt. Wait for {Span}. {Message} - {Trace}", span,
					ex.Message, ex.StackTrace));
	}


	public async Task<string?> UploadAsync(CloudObjectFile @object)
	{
		var putObject = new PutObjectRequest
		{
			InputStream = @object.Stream,
			BucketName = _awsS3Configuration.BucketName,
			Key = @object.IdentifierKey,
			ContentType = @object.ContentType
		};


		return await _asyncRetryPolicy.ExecuteAsync(async () =>
		{
			var httpResponse = await _amazonS3.PutObjectAsync(putObject);
			if (httpResponse.HttpStatusCode == HttpStatusCode.OK)
			{
				return putObject.Key;
			}

			_logger.LogError("Fail to upload file to bucket with key: {Key}", putObject.Key);
			throw new UnavailableServiceException("Storage service is unavailable");
		});
	}

	public async Task<Stream?> DownloadAsync(string objectIdentifier)
	{
		var getObject = new GetObjectRequest
		{
			BucketName = _awsS3Configuration.BucketName,
			Key = objectIdentifier
		};

		return await _asyncRetryPolicy.ExecuteAsync(async () =>
		{
			var httpResponse = await _amazonS3.GetObjectAsync(getObject);

			return httpResponse.HttpStatusCode == HttpStatusCode.OK ? httpResponse.ResponseStream : Stream.Null;
		});
	}

	public async Task<bool> DeleteAsync(string objectIdentifier)
	{
		var deleteObject = new DeleteObjectRequest
		{
			BucketName = _awsS3Configuration.BucketName,
			Key = objectIdentifier
		};

		return await _asyncRetryPolicy.ExecuteAsync(async () =>
		{
			var httpResponse = await _amazonS3.DeleteObjectAsync(deleteObject);
			return httpResponse.HttpStatusCode == HttpStatusCode.NoContent;
		});
	}

	public async Task<bool> DeleteManyAsync(IEnumerable<string> objectIdentifiers)
	{
		var deleteObjects = new DeleteObjectsRequest { BucketName = _awsS3Configuration.BucketName };

		using var iter = objectIdentifiers.GetEnumerator();
		while (iter.MoveNext())
		{
			deleteObjects.AddKey(iter.Current);
		}

		return await _asyncRetryPolicy.ExecuteAsync(async () =>
		{
			var httpResponse = await _amazonS3.DeleteObjectsAsync(deleteObjects);
			return httpResponse.HttpStatusCode == HttpStatusCode.NoContent;
		});
	}
}