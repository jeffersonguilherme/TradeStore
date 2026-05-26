using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PagedResponse<CategoryResponseDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<CategoryResponseDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var (items, totalItems) = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
        var mapped = _mapper.Map<IEnumerable<CategoryResponseDto>>(items);

        return new PagedResponse<CategoryResponseDto>(mapped, request.PageNumber, request.PageSize, totalItems);
    }
}