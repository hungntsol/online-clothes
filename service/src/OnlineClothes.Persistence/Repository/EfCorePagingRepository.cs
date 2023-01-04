using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineClothes.Application.Persistence.Abstracts;
using OnlineClothes.Domain.Paging;
using OnlineClothes.Persistence.Context;
using OnlineClothes.Support.Builders.Predicate;
using OnlineClothes.Support.Entity;

namespace OnlineClothes.Persistence.Repository;

public class EfCorePagingRepository<TEntity, TKey> : EfCoreReadOnlyRepositoryBase<TEntity, TKey>,
	IEfCorePagingRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>, new()
{
	public EfCorePagingRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public virtual async Task<PagingModel<TProject>> PagingAsync<TProject>(
		FilterBuilder<TEntity> filterBuilder,
		PagingRequest pageRequest,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderFunc,
		CancellationToken cancellationToken = default)
	{
		var offset = (pageRequest.PageIndex - 1) * pageRequest.PageSize;

		var total = await CountAsync(filterBuilder, cancellationToken);

		var query = DbSet.Where(filterBuilder.Statement);

		if (orderFunc is not null)
		{
			query = orderFunc(query);
		}

		var entries = await query
			.Skip(offset)
			.Take(pageRequest.PageSize)
			.AsQueryable()
			.ProjectToType<TProject>()
			.ToListAsync(cancellationToken);

		//var entries = await DbSet
		//	.AsNoTracking()
		//	.Where(filterBuilder.Statement)
		//	.AsEnumerable()
		//	.OrderBy(orderSelector)
		//	.Skip(offset)
		//	.Take(pageRequest.PageSize)
		//	.AsQueryable()
		//	.ProjectToType<TProject>()
		//	.ToListAsync(cancellationToken);


		return PagingModel<TProject>.ToPages(total, entries, pageRequest.PageIndex);
	}
}
