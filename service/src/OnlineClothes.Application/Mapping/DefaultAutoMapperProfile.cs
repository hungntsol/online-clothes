using AutoMapper;
using OnlineClothes.Application.Features.Brand.Commands.Create;
using OnlineClothes.Application.Features.Brand.Commands.Edit;
using OnlineClothes.Application.Features.Category.Commands.Edit;
using OnlineClothes.Application.Features.Product.Commands.Create;

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
		CreateMap<CreateProductCommand, Product>()
			.ForMember(dest => dest.BrandId, opt => opt.Condition(q => q.BrandId is not null && q.BrandId != 0));

		// Dto
		CreateMap<Brand, BrandDto>()
			.ReverseMap();

		CreateMap<Category, CategoryDto>()
			.ReverseMap();
	}
}
