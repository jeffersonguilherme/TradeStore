using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Locations.Queries.GetLocationById;

public record GetLocationByIdQuery(Guid Id) : IRequest<ResponseModel<LocationResponseDto?>>;