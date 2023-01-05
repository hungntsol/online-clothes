using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineClothes.Domain.Entities;

namespace OnlineClothes.Persistence.Internal.EntityConfigurations;

public class EntitySerialInCategoryConfiguration : IEntityTypeConfiguration<SerialCategory>
{
	public void Configure(EntityTypeBuilder<SerialCategory> builder)
	{
		builder.HasKey(q => new { q.SerialId, q.CategoryId });

		builder.HasOne(q => q.Serial)
			.WithMany(serial => serial.SerialCategories)
			.HasForeignKey(q => q.SerialId);

		builder.HasOne(q => q.Category)
			.WithMany(category => category.SerialCategories)
			.HasForeignKey(q => q.CategoryId);
	}
}
