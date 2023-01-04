﻿using OnlineClothes.Domain.Paging;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Entity;

namespace OnlineClothes.Application.Persistence.Abstracts;

public interface IEfCorePagingRepository<TEntity, TKey> : IEfCoreReadOnlyRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>, new()
{
	Task<PagingModel<TProject>> PagingAsync<TProject>(FilterBuilder<TEntity> filterBuilder, PagingRequest pageRequest,
		CancellationToken cancellationToken = default);
}
