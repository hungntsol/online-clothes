using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Persistence.MySql.Internal.EntityConfigurations;

public class EntityProductInCategoryConfigure : IEntityTypeConfiguration<ProductInCategory>
{
	public void Configure(EntityTypeBuilder<ProductInCategory> builder)
	{
		builder.HasKey(q => new { ProductId = q.ProductSku, q.ClotheCategoryId });
	}
}
