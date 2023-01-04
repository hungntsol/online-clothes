using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Persistence.Internal.EntityConfigurations;

public class EntityProductInMaterialConfigure : IEntityTypeConfiguration<ProductInMaterial>
{
	public void Configure(EntityTypeBuilder<ProductInMaterial> builder)
	{
		builder.HasKey(q => new { q.MaterialId, q.ProductSku });
	}
}
