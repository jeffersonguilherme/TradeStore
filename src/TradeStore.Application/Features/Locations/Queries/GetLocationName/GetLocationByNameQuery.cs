using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Locations.Queries.GetLocationName;

public record GetLocationByNameQuery(string Name) : IRequest<ResponseModel<LocationResponseDto?>>;