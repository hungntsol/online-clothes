using System.Linq.Expressions;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Entity;

namespace OnlineClothes.Application.Apply.Repositories.Abstracts;

public interface IEfCoreWriteRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
{
	#region Find & Delete

	/// <summary>
	/// Find and delete entity with predication definition
	/// </summary>
	/// <param name="filterBuilder"></param>
	/// <param name="notify"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<TEntity?> FindAndDelete(FilterBuilder<TEntity> filterBuilder,
		bool notify = true,
		CancellationToken cancellationToken = default);

	#endregion

	#region Insert

	/// <summary>
	/// Insert one entity async
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="notify"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<TEntity?> InsertAsync(TEntity entity,
		bool notify = true,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Insert multiple entity
	/// </summary>
	/// <param name="entities"></param>
	/// <param name="notify"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> InsertBatchAsync(IList<TEntity> entities, bool notify = true,
		CancellationToken cancellationToken = default);

	#endregion

	#region Update

	/// <summary>
	/// Update an entity
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="notify"></param>
	/// <returns></returns>
	bool Update(TEntity entity,
		bool notify = true);

	/// <summary>
	/// Update only one field of record
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="updateDef"></param>
	/// <param name="notify"></param>
	/// <returns></returns>
	bool UpdateOneField(
		TEntity entity,
		Expression<Func<TEntity, object>> updateDef,
		bool notify = true);

	#endregion

	#region Delete

	/// <summary>
	/// Delete entity async
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="notify"></param>
	/// <returns></returns>
	bool Delete(TEntity entity,
		bool notify = true);

	/// <summary>
	/// Delete multiple entity
	/// </summary>
	/// <param name="filterBuilder"></param>
	/// <param name="notify"></param>
	/// <returns></returns>
	bool DeleteBatch(FilterBuilder<TEntity> filterBuilder,
		bool notify = true);

	#endregion
}
