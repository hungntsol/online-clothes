using AutoMapper;
using OnlineClothes.Application.Features.Brands.Commands.Create;
using OnlineClothes.Application.Features.Brands.Commands.Edit;
using OnlineClothes.Application.Features.Categories.Commands.Edit;
using OnlineClothes.Application.Features.Products.Commands.Create;
using OnlineClothes.Application.Features.Products.Commands.UpdateInfo;
using OnlineClothes.Application.Mapping.ViewModels;
using OnlineClothes.Application.Persistence.Schemas.Products;

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

		CreateMap<CreateProductCommand, Product>();
		CreateMap<CreateProductCommand, PutProductInRepoObject>();
		CreateMap<PutProductInRepoObject, Product>()
			.ForMember(dest => dest.BrandId, opt => opt.Condition(q => q.BrandId is not null && q.BrandId != 0))
			.ForMember(dest => dest.Categories, opt => opt.Ignore());
		CreateMap<EditProductCommand, PutProductInRepoObject>();

		// Viewmodel
		CreateMap<BrandViewModel, Brand>().ReverseMap();
		CreateMap<CategoryViewModel, Category>().ReverseMap();
		CreateMap<ProductViewModel, Product>()
			.ReverseMap()
			.ForMember(dest => dest.Brand,
				opt => opt.MapFrom(src => BrandDto.ToModel(src.Brand)))
			.ForMember(dest => dest.Categories,
				opt => opt.MapFrom(src => src.Categories.Select(CategoryDto.ToModel).ToList()));

		// Dto
		CreateMap<Product, ProductBasicDto>();
	}
}
