﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Apply.Repositories.Abstracts;
using OnlineClothes.Persistence.MySql.Context;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Entity;
using OnlineClothes.Support.Utilities.Extensions;

namespace OnlineClothes.Persistence.MySql.Repositories;

public abstract class EfCoreReadOnlyRepositoryBase<TEntity, TKey> : IEfCoreReadOnlyRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>, new()
{
	protected readonly AppDbContext DbContext;
	protected readonly DbSet<TEntity> DbSet;

	protected EfCoreReadOnlyRepositoryBase(AppDbContext dbContext)
	{
		DbContext = dbContext;
		DbSet = dbContext.Set<TEntity>();
	}

	public IQueryable AsQueryable(bool noTracking = true)
	{
		return noTracking ? DbSet.AsNoTracking() : DbSet.AsQueryable();
	}

	public virtual async Task<TEntity?> FindOneAsync(object?[]? keyValues,
		CancellationToken cancellationToken = default)
	{
		return await DbSet.FindAsync(keyValues, cancellationToken)
			.ConfigureAwait(false);
	}

	public virtual Task<TEntity?> FindOneAsync(FilterBuilder<TEntity> filterBuilder,
		CancellationToken cancellationToken = default)
	{
		return FindOneAsync(filterBuilder.Statement, cancellationToken);
	}

	public virtual async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate,
		CancellationToken cancellationToken = default)
	{
		return await DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
	}

	public virtual Task<TEntity?> FindOneAsync(FilterBuilder<TEntity> filterBuilder,
		List<string> includes,
		CancellationToken cancellationToken = default)
	{
		return FindOneAsync(filterBuilder, includes, true, cancellationToken);
	}

	public virtual Task<TEntity?> FindOneAsync(FilterBuilder<TEntity> filterBuilder,
		List<string> includes,
		bool asTracking,
		CancellationToken cancellationToken = default)
	{
		return FindOneAsync(filterBuilder, includes, asTracking, default, cancellationToken);
	}

	public virtual Task<TEntity?> FindOneAsync(FilterBuilder<TEntity> filterBuilder,
		List<string> includes,
		bool asTracking,
		bool ignoreQueryFilters = true,
		CancellationToken cancellationToken = default)
	{
		return FindOneAsync(filterBuilder, p => p, includes, asTracking, ignoreQueryFilters, cancellationToken);
	}

	public virtual async Task<TProject?> FindOneAsync<TProject>(FilterBuilder<TEntity> filterBuilder,
		Expression<Func<TEntity, TProject>> selector,
		List<string> includes,
		bool asTracking,
		bool ignoreQueryFilters = true,
		CancellationToken cancellationToken = default)
	{
		return await BuildIQueryable(DbSet, includes, asTracking, ignoreQueryFilters)
			.Where(filterBuilder.Statement)
			.Select(selector)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public virtual async Task<long> CountAsync(CancellationToken cancellationToken = default)
	{
		return await DbSet.LongCountAsync(cancellationToken);
	}

	public virtual async Task<long> CountAsync(FilterBuilder<TEntity> filterBuilder,
		CancellationToken cancellationToken = default)
	{
		return await DbSet.LongCountAsync(filterBuilder.Statement, cancellationToken);
	}

	private static IQueryable<TEntity> BuildIQueryable(
		IQueryable<TEntity> queryable,
		List<string> includes,
		bool asTracking,
		bool ignoreFilter
	)
	{
		// tracking
		if (!asTracking)
		{
			queryable = queryable.AsNoTracking();
		}

		// include
		if (!includes.IsEmpty())
		{
			foreach (var include in includes)
			{
				queryable = queryable.Include(include);
			}
		}

		// ignoreFilter
		if (ignoreFilter)
		{
			queryable = queryable.IgnoreQueryFilters();
		}

		return queryable;
	}
}
