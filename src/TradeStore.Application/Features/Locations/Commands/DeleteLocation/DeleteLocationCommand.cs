using MediatR;

namespace TradeStore.Application.Features.Locations.Commands.DeleteLocation;

public record DeleteLocationCommand(Guid Id) : IRequest<bool>;