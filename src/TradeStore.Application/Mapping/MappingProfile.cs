using AutoMapper;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.DTOs.ValueObjects;
using TradeStore.Domain.Entities;
using TradeStore.Domain.ValueObjects;

namespace TradeStore.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Category Mapping
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, CategoryResponseDto>();

        //Location Mapping
        CreateMap<CreateLocationDto, Location>();
        CreateMap<UpdateLocationDto, Location>();
        CreateMap<Location, LocationResponseDto>();

        //Product Mapping
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, ProductDetailDto>();
        CreateMap<Product, ProductSummaryDto>();

        //ProductType Mapping
        CreateMap<CreateProductTypeDto, ProductType>();
        CreateMap<UpdateProductTypeDto, ProductType>();
        CreateMap<ProductType, ProductTypeResponseDto>();

        //Dimension Mapping
        CreateMap<DimensionsDto, Dimensions>();
        CreateMap<Dimensions, DimensionsDto>();
    }
}