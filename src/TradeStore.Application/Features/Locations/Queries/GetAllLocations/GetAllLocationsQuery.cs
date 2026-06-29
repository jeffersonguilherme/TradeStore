using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Locations.Queries.GetAllLocations;

public record GetAllLocationsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResponse<LocationResponseDto>>;