using AutoMapper;
using OnlineClothes.Application.Features.Brand.Commands.Create;

namespace OnlineClothes.Application.Mapping;

public class DefaultAutoMapperProfile : Profile
{
	public DefaultAutoMapperProfile()
	{
		// request to model
		CreateMap<CreateBrandCommand, Brand>();

		// Dto
		CreateMap<Brand, BrandDto>()
			.ReverseMap();

		CreateMap<Category, CategoryDto>()
			.ReverseMap();

		CreateMap<Serial, SerialDto>()
			.ReverseMap();
	}
}
