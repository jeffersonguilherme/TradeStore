using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;
using TradeStore.Domain.Entities;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Commands.CreateProductType;

public class CreateProductTypeHandler : IRequestHandler<CreateProductTypeCommand, ResponseModel<ProductTypeResponseDto>>
{
    private readonly IProductTypeRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductTypeHandler(IProductTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductTypeResponseDto>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        var requestDto = request.Dto;

        var existingProducType = await _repository.ExistsAsync(requestDto.NameType.Trim().ToLower());

        if (existingProducType)
        {
            return new ResponseModel<ProductTypeResponseDto>
            {
                Mensagem = "Product Type already exists",
                Status = false
            };
        }

        var productType = ProductType.Create(requestDto.NameType);
        await _repository.AddAsync(productType);
        var productTypeResponse = _mapper.Map<ProductTypeResponseDto>(productType);

        return new ResponseModel<ProductTypeResponseDto>
        {
            Dados = productTypeResponse,
            Mensagem = "Product Type Created"
        };
    }
}