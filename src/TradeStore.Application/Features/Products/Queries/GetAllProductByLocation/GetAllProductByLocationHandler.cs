using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Products.Queries.GetAllProductByLocation;

public class GetAllProductByLocationHandler : IRequestHandler<GetAllProductByLocationQuery, PagedResponse<ProductSummaryDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductByLocationHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<ProductSummaryDto>> Handle(GetAllProductByLocationQuery request, CancellationToken cancellationToken)
    {
        var (items, totalItems) = await _repository.GetByLocation(request.LocationId, request.PageNumber, request.PageSize);
        var productsResponse = _mapper.Map<IEnumerable<ProductSummaryDto>>(items);

        return new PagedResponse<ProductSummaryDto>(productsResponse, request.PageNumber, request.PageSize, totalItems);
    }
}