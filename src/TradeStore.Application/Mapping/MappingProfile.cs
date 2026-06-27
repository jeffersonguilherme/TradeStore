using AutoMapper;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Domain.Entities;

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
    }
}