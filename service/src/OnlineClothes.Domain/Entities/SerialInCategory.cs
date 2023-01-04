using OnlineClothes.Domain.Entities.Aggregate;

namespace OnlineClothes.Domain.Entities;

public class SerialInCategory
{
	[ForeignKey("SerialId")] public ProductSerial ProductSerial { get; set; } = null!;
	public int SerialId { get; set; }

	[ForeignKey("CategoryId")] public ClotheCategory Category { get; set; } = null!;
	public int CategoryId { get; set; }
}
