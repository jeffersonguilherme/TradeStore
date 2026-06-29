using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Products.Queries.GetProductsPaged;

public class GetproductAllHandler : IRequestHandler<GetProductAllQuery, PagedResponse<ProductSummaryDto?>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetproductAllHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<ProductSummaryDto?>> Handle(GetProductAllQuery request, CancellationToken cancellationToken)
    {
        var (items, totalItems)  = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
        var productMapper = _mapper.Map<IEnumerable<ProductSummaryDto>>(items);

        return new PagedResponse<ProductSummaryDto?>(productMapper, request.PageNumber, request.PageSize, totalItems);
    }
}