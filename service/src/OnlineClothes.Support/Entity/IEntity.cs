﻿namespace OnlineClothes.Support.Entity;

public interface IEntity<out TKey>
{
	TKey Id { get; }
}

public interface IEntity
{
	string Id { get; }
}
