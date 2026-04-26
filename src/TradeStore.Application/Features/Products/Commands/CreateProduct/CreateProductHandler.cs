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
    private readonly IMapper _mapper;
    public CreateproductHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductSummaryDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var dimensions = _mapper.Map<Dimensions>(dto.Dimensions);

        var product = new Product(
             dto.CodTrade,
             dto.Description,
             dto.CodNcm,
             dto.CodSap,
             dto.Notes,
             dimensions,
             dto.ImgUrl,
             new List<Location>(),
             dto.CategoryId,
             dto.TypeId
        );

        await _repository.AddAsync(product);
        var productSummary = _mapper.Map<ProductSummaryDto>(product);

        return new ResponseModel<ProductSummaryDto>{
            Dados = productSummary,
            Mensagem = "Produto criado com sucesso"
        };
    }
}