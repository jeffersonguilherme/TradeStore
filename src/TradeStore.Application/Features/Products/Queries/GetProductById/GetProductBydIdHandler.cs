using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ResponseModel<ProductDetailDto?>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductDetailDto?>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if(product is null)
        {
            return new ResponseModel<ProductDetailDto?>
            {
                Dados = null,
                Mensagem = "Product not found.",
                Status = false
            };
        }

        var productDto = _mapper.Map<ProductDetailDto>(product);
        return new ResponseModel<ProductDetailDto?>
        {
            Dados = productDto,
            Mensagem = "Product retrieved successfully.",
            Status = true
        };
    }
}