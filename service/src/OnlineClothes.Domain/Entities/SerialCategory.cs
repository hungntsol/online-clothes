using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class SerialCategory
{
	public int SerialId { get; set; }
	[ForeignKey("SerialId")] public Serial Serial { get; set; } = null!;

	public int CategoryId { get; set; }
	[ForeignKey("CategoryId")] public Category Category { get; set; } = null!;

	public static SerialCategory ToModel(int serialId, int categoryId)
	{
		return new SerialCategory { SerialId = serialId, CategoryId = categoryId };
	}

	public static SerialCategory ToModel(int categoryId)
	{
		return new SerialCategory { CategoryId = categoryId };
	}
}
