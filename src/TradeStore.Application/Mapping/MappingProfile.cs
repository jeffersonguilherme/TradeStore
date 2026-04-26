using AutoMapper;
using TradeStore.Application.DTOs.Product;
using TradeStore.Domain.Entities;

namespace TradeStore.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, ProductSummaryDto>();
    }
}