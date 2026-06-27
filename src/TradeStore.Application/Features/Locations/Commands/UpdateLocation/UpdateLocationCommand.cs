using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Locations.Commands.UpdateLocation;

public record UpdateLocationCommand(Guid Id, UpdateLocationDto Dto) : IRequest<ResponseModel<LocationResponseDto>>;