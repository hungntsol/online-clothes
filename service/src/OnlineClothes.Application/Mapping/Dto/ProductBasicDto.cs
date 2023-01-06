namespace OnlineClothes.Application.Mapping.Dto;

public class ProductBasicDto
{
	public ProductBasicDto()
	{
	}

	public ProductBasicDto(int id, string sku, string name, double price, int inStock)
	{
		Id = id;
		Sku = sku;
		Name = name;
		Price = price;
		InStock = inStock;
	}

	public int Id { get; set; }
	public string Sku { get; set; } = null!;
	public string Name { get; set; } = null!;
	public double Price { get; set; }
	public int InStock { get; set; }

	//public string? ImageUrl { get; set; }

	public static ProductBasicDto ToModel(Product entity)
	{
		return new ProductBasicDto(entity.Id, entity.Sku, entity.Name, entity.Price, entity.InStock);
	}
}
