using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResponse<CategoryResponseDto>>;