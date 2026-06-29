using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;
using TradeStore.Domain.ValueObjects;

namespace TradeStore.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResponseModel<ProductDetailDto>>
{
    private readonly ICategoryRepository _respositoryCategory;
    private readonly ILocationRepository _respositoryLocation;
    private readonly IProducTypeRepository _repositoryType;
    private readonly IProductRepository _repositoryProduct;
    private readonly IMapper _mapper;

    public UpdateProductHandler(ICategoryRepository respositoryCategory, ILocationRepository respositoryLocation, IProducTypeRepository repositoryType, IProductRepository repositoryProduct, IMapper mapper)
    {
        _respositoryCategory = respositoryCategory;
        _respositoryLocation = respositoryLocation;
        _repositoryType = repositoryType;
        _repositoryProduct = repositoryProduct;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductDetailDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repositoryProduct.GetByIdAsync(request.Id);
        if(product is null)
        {
            return new ResponseModel<ProductDetailDto>
            {
                Mensagem = "Product not found."
            };
        }

        var codTrade = await _repositoryProduct.ExistCodTradeAsync(request.Dto.CodTrade, request.Id);
        if (codTrade)
        {
            return new ResponseModel<ProductDetailDto>
            {
                Mensagem = "Product already exists"
            };
        }

        var categoryId = await _respositoryCategory.GetByIdAsync(request.Dto.CategoryId);
        if(categoryId is null)
        {
            return new ResponseModel<ProductDetailDto>
            {
                Mensagem = "Category does not exist"
            };
        }

        var typeId = await _repositoryType.GetByIdAsync(request.Dto.TypeId);
        if(typeId is null)
        {
            return new ResponseModel<ProductDetailDto>
            {
                Mensagem = "Type does not exist"
            };
        }

        var locations = await _respositoryLocation.GetByIdsAsync(request.Dto.AllowedLocations);
        if(locations.Count != request.Dto.AllowedLocations.Count)
        {
            return new ResponseModel<ProductDetailDto>
            {
                Mensagem = "One or more Locations were not found",
                Status = false
            };
        }

        var dimensions = _mapper.Map<Dimensions>(request.Dto.Dimensions);

        product.Update(
            codTrade: request.Dto.CodTrade,
            description: request.Dto.Description,
            codNcm: request.Dto.CodNcm,
            codSap: request.Dto.CodSap,
            notes: request.Dto.Notes,
            dimensions: dimensions,
            imgUrl: request.Dto.ImgUrl,
            allowedLocations: locations,
            categoryId: request.Dto.CategoryId,
            typeId: request.Dto.TypeId
        );
        await _repositoryProduct.UpdateAsync(product);

        var productResponse = _mapper.Map<ProductDetailDto>(product);
        return new ResponseModel<ProductDetailDto>
        {
            Dados = productResponse,
            Mensagem = "Product updated successfully."
        };
    }
}