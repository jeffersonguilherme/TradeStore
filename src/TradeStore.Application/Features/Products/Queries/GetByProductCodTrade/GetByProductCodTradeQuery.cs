using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Products.Queries.GetBydProductCodTrade;

public record GetByProductCodTradeQuery(string CodTrade) : IRequest<ResponseModel<ProductDetailDto?>>;