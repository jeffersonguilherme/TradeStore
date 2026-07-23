using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.ProductTypes.Queries.GetAllProductTypes;

public record GetAllProductTypesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResponse<ProductTypeResponseDto>>;