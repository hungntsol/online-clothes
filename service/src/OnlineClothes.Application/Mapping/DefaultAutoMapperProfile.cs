using AutoMapper;
using OnlineClothes.Application.Features.Brand.Commands.Create;
using OnlineClothes.Application.Features.Brand.Commands.Edit;
using OnlineClothes.Application.Features.Category.Commands.Edit;

namespace OnlineClothes.Application.Mapping;

public class DefaultAutoMapperProfile : Profile
{
	public DefaultAutoMapperProfile()
	{
		// request to model
		CreateMap<CreateBrandCommand, Brand>()
			.ForMember(q => q.Id, opt => opt.Ignore());
		CreateMap<EditBrandCommand, Brand>();
		CreateMap<EditCategoryCommand, Category>();

		// Dto
		CreateMap<Brand, BrandDto>()
			.ReverseMap();

		CreateMap<Category, CategoryDto>()
			.ReverseMap();
	}
}
