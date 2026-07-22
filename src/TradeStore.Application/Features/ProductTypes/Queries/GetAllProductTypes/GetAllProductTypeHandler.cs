using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Queries.GetAllProductTypes;

public class GetAllProductTypeHandler : IRequestHandler<GetAllProductTypesQuery, PagedResponse<ProductTypeResponseDto>>
{
    private readonly IProductTypeRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductTypeHandler(IProductTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<ProductTypeResponseDto>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var (items, totalItems) = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
        var productTypeResponse = _mapper.Map<IEnumerable<ProductTypeResponseDto>>(items);

        return new PagedResponse<ProductTypeResponseDto>(productTypeResponse, request.PageNumber, request.PageSize, totalItems);
    }
}