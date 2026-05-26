using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Locations.Commands.CreateLocation;

public record CreateLocationCommand(CreateLocationDto Dto) : IRequest<ResponseModel<LocationResponseDto>>;