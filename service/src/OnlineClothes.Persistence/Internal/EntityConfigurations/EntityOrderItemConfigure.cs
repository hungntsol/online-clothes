using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Persistence.Internal.EntityConfigurations;

public class EntityOrderItemConfigure : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.HasKey(q => new { q.OrderId, q.ProductSku });
		builder.HasOne(orderItem => orderItem.Product)
			.WithMany(product => product.OrderItems)
			.HasForeignKey(orderItem => orderItem.ProductSku)
			.HasPrincipalKey(product => product.Sku);
	}
}
