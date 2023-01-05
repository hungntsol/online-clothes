using Mapster;
using OnlineClothes.Application.Mapping.Dto;

namespace OnlineClothes.Application.Mapping;

public class DefaultMappingProfile : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<Serial, SerialDto>()
			.Map(dest => dest.Categories, src => src.SerialCategories.ToList().Adapt<List<CategoryDto>>());
	}
}
