using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Products.Queries.GetAllProductByLocation;

public record GetAllProductByLocationQuery(Guid LocationId, int PageNumber = 1, int PageSize = 10) : IRequest<PagedResponse<ProductSummaryDto>>;