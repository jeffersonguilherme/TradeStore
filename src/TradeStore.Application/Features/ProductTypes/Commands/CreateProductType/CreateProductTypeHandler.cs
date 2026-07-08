using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;
using TradeStore.Domain.Entities;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Commands.CreateProductType;

public class CreateProductTypeHandler : IRequestHandler<CreateProductTypeCommand, ResponseModel<ProductTypeResponseDto>>
{
    private readonly IProducTypeRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductTypeHandler(IProducTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductTypeResponseDto>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var existingProducType = await _repository.ExistsAsync(dto.NameType.Trim().ToLower());

        if (existingProducType)
        {
            return new ResponseModel<ProductTypeResponseDto>
            {
                Mensagem = "Product Type already exists",
                Status = false
            };
        }

        var productType = ProductType.Create(dto.NameType);

        await _repository.AddAsync(productType);
        var productTypeResponse = _mapper.Map<ProductTypeResponseDto>(productType);

        return new ResponseModel<ProductTypeResponseDto>
        {
            Dados = productTypeResponse,
            Mensagem = "Product Type Created"
        };
    }
}