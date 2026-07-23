using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.ProductTypes.Queries.GetProductTypeByName;

public record GetProductTypeByNameQuery(string Name) : IRequest<ResponseModel<ProductTypeResponseDto?>>;