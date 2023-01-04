using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Persistence.Internal.EntityConfigurations;

public class EntityProductConfigure : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
	}
}
