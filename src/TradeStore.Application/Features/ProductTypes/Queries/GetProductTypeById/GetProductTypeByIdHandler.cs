using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Queries.GetProductTypeById;

public class GetProductTypeByIdHandler : IRequestHandler<GetProductTypeByIdQuery, ResponseModel<ProductTypeResponseDto?>>
{
    private readonly IProductTypeRepository _repository;
    private readonly IMapper _mapper;

    public GetProductTypeByIdHandler(IProductTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductTypeResponseDto?>> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var productType = await _repository.GetByIdAsync(request.Id);
        if(productType is null)
        return new ResponseModel<ProductTypeResponseDto?>
        {
            Dados = null,
            Mensagem = "Product Type no found.",
            Status = false
        };

        var productTypeResponse = _mapper.Map<ProductTypeResponseDto>(productType);
        return new ResponseModel<ProductTypeResponseDto?>
        {
            Dados = productTypeResponse,
            Mensagem = "Product Type found Successfully.",
            Status = true
        };
    }
}