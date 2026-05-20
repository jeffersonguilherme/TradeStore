using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid CategoryId) : IRequest<ResponseModel<CategoryResponseDto?>>;