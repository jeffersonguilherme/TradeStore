using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Products.Queries.GetAllProductByCategory;

public class GetAllProductByCategoryHandler : IRequestHandler<GetAllProductByCategoryQuery, PagedResponse<ProductSummaryDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductByCategoryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<ProductSummaryDto>> Handle(GetAllProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var (items, totalItems) = await _repository.GetByCategory(request.CategoryId, request.PageNumber, request.PageSize);
        var productResponse = _mapper.Map<IEnumerable<ProductSummaryDto>>(items);

        return new PagedResponse<ProductSummaryDto>(productResponse, request.PageNumber, request.PageSize, totalItems);
    }
}