using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineClothes.Persistence.MySql.Internal.EntityConfigurations;

public class EntityProductConfigure : IEntityTypeConfiguration<ProductInfo>
{
	public void Configure(EntityTypeBuilder<ProductInfo> builder)
	{
		builder.HasIndex(q => q.Sku)
			.IsUnique();
	}
}
