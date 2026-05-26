using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Entities;
using TradeStore.Domain.Repositories;
using TradeStore.Domain.ValueObjects;

namespace TradeStore.Application.Features.Products.Commands.CreateProduct;

public class CreateproductHandler : IRequestHandler<CreateProductCommand, ResponseModel<ProductSummaryDto>>
{
    private readonly IProductRepository _repository;
    private readonly ILocationRepository _locationRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProducTypeRepository _typeRepository;
    private readonly IMapper _mapper;
    public CreateproductHandler(IProductRepository repository,
                                IMapper mapper,
                                ILocationRepository locationRepository,
                                ICategoryRepository categoryRepository,
                                IProducTypeRepository typeRepository)
    {
        _repository = repository;
        _locationRepository = locationRepository;
        _categoryRepository = categoryRepository;
        _typeRepository = typeRepository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductSummaryDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
      var dto = request.Dto;

      var existingProduct = await _repository.ExistAsync(dto.CodTrade.Trim().ToLower());

      if(existingProduct)
        {
            return new ResponseModel<ProductSummaryDto>
            {
              Mensagem = "Product already exists"  
            };
        }

        var categoryExisting = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if(categoryExisting is null)
        {
            return new ResponseModel<ProductSummaryDto>
            {
                Mensagem = "Catetory not exists"
            };
        }

        var locations = await _locationRepository.GetByIdsAsync(dto.AllowedLocations);
        if(locations.Count != dto.AllowedLocations.Count)
        {
            return new ResponseModel<ProductSummaryDto>
            {
                Mensagem = "One or more locations were not found.",
                Status = false
            };
        }

        var typeIdExisting = await _typeRepository.GetByIdAsync(dto.TypeId);
        if(typeIdExisting is null)
        {
            return new ResponseModel<ProductSummaryDto>
            {
                Mensagem = "Type not exists"
            };
        }

        var dimensions = _mapper.Map<Dimensions>(dto.Dimensions);

        var product = Product.Create(
            codTrade: dto.CodTrade,
            description: dto.Description,
            codNcm: dto.CodNcm,
            codSap: dto.CodSap,
            notes: dto.Notes,
            dimensions: dimensions,
            imgUrl: dto.ImgUrl,
            allowedLocations: locations,
            categoryId: dto.CategoryId,
            typeId: dto.TypeId
            );

        await _repository.AddAsync(product);

        var result = _mapper.Map<ProductSummaryDto>(product);
        
        return new ResponseModel<ProductSummaryDto>
        {
            Dados = result,
            Mensagem = "Product successfully registered.",
            Status = true
        };
    }
}