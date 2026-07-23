using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Queries.GetProductTypeByName;

public class GetProductTypeByNameHandler : IRequestHandler<GetProductTypeByNameQuery, ResponseModel<ProductTypeResponseDto?>>
{
    private readonly IProductTypeRepository _repository;
    private readonly IMapper _mappper;

    public GetProductTypeByNameHandler(IProductTypeRepository repository, IMapper mappper)
    {
        _repository = repository;
        _mappper = mappper;
    }

    public async Task<ResponseModel<ProductTypeResponseDto?>> Handle(GetProductTypeByNameQuery request, CancellationToken cancellationToken)
    {
        var productType = await _repository.GetByNameAsync(request.Name);
        if(productType is null)
        return new ResponseModel<ProductTypeResponseDto?>
        {
            Dados = null,
            Mensagem = "Product Type not found.",
            Status = false
        };

        var productTypeResponse = _mappper.Map<ProductTypeResponseDto>(productType);
        return new ResponseModel<ProductTypeResponseDto?>
        {
            Dados = productTypeResponse,
            Mensagem = "Product Type successfully entered.",
            Status = true
        };
    }
}