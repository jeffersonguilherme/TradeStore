using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.ProductTypes.Queries.GetProductTypeById;

public record GetProductTypeByIdQuery(Guid Id) : IRequest<ResponseModel<ProductTypeResponseDto?>>;