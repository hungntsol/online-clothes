using System.Linq.Expressions;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Entity;

namespace OnlineClothes.Application.Apply.Repositories.Abstracts;

public interface IEfCoreReadOnlyRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
{
	IQueryable AsQueryable(bool noTracking = true);

	#region FindOne

	Task<TEntity?> FindOneAsync(object?[]? keyValues, CancellationToken cancellationToken = default);

	Task<TEntity?> FindOneAsync(FilterBuilder<TEntity> filterBuilder,
		CancellationToken cancellationToken = default);

	Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate,
		CancellationToken cancellationToken = default);

	Task<TEntity?> FindOneAsync(
		FilterBuilder<TEntity> filterBuilder,
		List<string> includes,
		CancellationToken cancellationToken = default);

	Task<TEntity?> FindOneAsync(
		FilterBuilder<TEntity> filterBuilder,
		List<string> includes,
		bool asTracking,
		CancellationToken cancellationToken = default);

	Task<TEntity?> FindOneAsync(
		FilterBuilder<TEntity> filterBuilder,
		List<string> includes,
		bool asTracking,
		bool ignoreQueryFilters = true,
		CancellationToken cancellationToken = default);

	Task<TProject?> FindOneAsync<TProject>(
		FilterBuilder<TEntity> filterBuilder,
		Expression<Func<TEntity, TProject>> selector,
		List<string> includes,
		bool asTracking,
		bool ignoreQueryFilters = true,
		CancellationToken cancellationToken = default);

	#endregion

	#region Count

	Task<long> CountAsync(CancellationToken cancellationToken = default);

	Task<long> CountAsync(FilterBuilder<TEntity> filterBuilder, CancellationToken cancellationToken = default);

	#endregion
}
