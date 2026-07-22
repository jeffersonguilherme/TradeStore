using MediatR;

namespace TradeStore.Application.Features.ProductTypes.Commands.DeleteProductType;

public record DeleteProductTypeCommand(Guid Id) : IRequest<bool>;