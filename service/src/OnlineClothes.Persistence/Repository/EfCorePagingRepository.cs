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

	public virtual async Task<PagingModel<TProject>> PagingAsync<TProject>(FilterBuilder<TEntity> filterBuilder,
		PagingRequest pageRequest,
		CancellationToken cancellationToken = default)
	{
		var offset = (pageRequest.PageIndex - 1) * pageRequest.PageSize;

		var total = await CountAsync(filterBuilder, cancellationToken);

		var entries = await DbSet
			.AsNoTracking()
			.Where(filterBuilder.Statement)
			.OrderBy(q => q.Id)
			.Skip(offset)
			.Take(pageRequest.PageSize)
			.ProjectToType<TProject>()
			.ToListAsync(cancellationToken);


		return PagingModel<TProject>.ToPages(total, entries, pageRequest.PageIndex);
	}
}
