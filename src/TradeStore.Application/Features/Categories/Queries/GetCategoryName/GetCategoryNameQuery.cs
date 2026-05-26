using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Categories.Queries.GetCategoryName;

public record GetCategoryNameQuery(string Name) : IRequest<ResponseModel<CategoryResponseDto?>>;