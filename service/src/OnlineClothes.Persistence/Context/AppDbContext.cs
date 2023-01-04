using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineClothes.Domain.Entities;
using OnlineClothes.Domain.Entities.Aggregate;
using OnlineClothes.Support.Entity;

namespace OnlineClothes.Persistence.Context;

public class AppDbContext : DbContext
{
	// TODO: logger executing time
	private static readonly ILoggerFactory LoggerFactInstance = LoggerFactory.Create(
		builder =>
		{
			builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
				.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Warning)
				.AddConsole();
		});

	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

		optionsBuilder.UseLoggerFactory(LoggerFactInstance)
			.EnableSensitiveDataLogging();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
		CancellationToken cancellationToken = new())
	{
		foreach (var entityEntry in ChangeTracker.Entries<IEntityDatetimeSupport>())
		{
			switch (entityEntry.State)
			{
				case EntityState.Added:
					entityEntry.Entity.CreatedAt = DateTime.UtcNow;
					break;

				case EntityState.Deleted:
				case EntityState.Modified:
					entityEntry.Entity.ModifiedAt = DateTime.UtcNow;
					break;
			}
		}


		return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

	#region Dbset

	public DbSet<AccountUser> AccountUsers { get; set; } = null!;
	public DbSet<AccountTokenCode> AccountTokens { get; set; } = null!;
	public DbSet<AccountCart> AccountCarts { get; set; } = null!;
	public DbSet<CartItem> CartItems { get; set; } = null!;
	public DbSet<ClotheBrand> ClotheBrands { get; set; } = null!;
	public DbSet<ClotheCategory> ClotheCategories { get; set; } = null!;
	public DbSet<Product> Products { get; set; }
	public DbSet<ProductSerial> ProductSerials { get; set; }
	public DbSet<SerialInCategory> SerialInCategories { get; set; } = null!;

	#endregion
}
