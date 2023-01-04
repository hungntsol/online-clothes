using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Persistence.Internal.EntityConfigurations;

public class EntityProductInCategoryConfigure : IEntityTypeConfiguration<SerialInCategory>
{
	public void Configure(EntityTypeBuilder<SerialInCategory> builder)
	{
		builder.HasKey(q => new { q.SerialId, q.CategoryId });
	}
}
