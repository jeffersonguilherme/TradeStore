using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) :IRequest<ResponseModel<ProductDetailDto?>>;