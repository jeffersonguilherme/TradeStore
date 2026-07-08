using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.ProductTypes.Commands.CreateProductType;

public record CreateProductTypeCommand(CreateProductTypeDto Dto) : IRequest<ResponseModel<ProductTypeResponseDto>>;