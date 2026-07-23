using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Products.Queries.GetBydProductCodTrade;

public class GetByProductCodTradeHandler : IRequestHandler<GetByProductCodTradeQuery, ResponseModel<ProductDetailDto?>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetByProductCodTradeHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductDetailDto?>> Handle(GetByProductCodTradeQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByCodTrade(request.CodTrade);
        if(product is null)
        return new ResponseModel<ProductDetailDto?>
        {
            Dados = null,
            Mensagem = "Product not found.",
            Status = false
        };

        var productResponse = _mapper.Map<ProductDetailDto>(product);
        return new ResponseModel<ProductDetailDto?>
        {
            Dados = productResponse,
            Mensagem = "Product retrieved successfully.",
        };
    }
}