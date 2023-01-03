﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineClothes.Domain.Entities;

public abstract class RootDocumentBase
{
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime ModifiedAt { get; set; }

	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
}
