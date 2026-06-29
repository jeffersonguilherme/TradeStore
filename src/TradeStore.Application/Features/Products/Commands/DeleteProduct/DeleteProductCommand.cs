using MediatR;

namespace TradeStore.Application.Features.Products.Commands.DeleterProduc;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;