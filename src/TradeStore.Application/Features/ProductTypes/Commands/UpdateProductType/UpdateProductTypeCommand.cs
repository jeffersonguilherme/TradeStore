using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.ProductTypes.Commands.UpdateProductType;

public record UpdateProductTypeCommand(Guid Id, UpdateProductTypeDto Dto) : IRequest<ResponseModel<ProductTypeResponseDto>>;