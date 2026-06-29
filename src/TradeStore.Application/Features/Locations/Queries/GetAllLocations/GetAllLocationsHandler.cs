using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Locations.Queries.GetAllLocations;

public class GetAllLocationsHandler : IRequestHandler<GetAllLocationsQuery, PagedResponse<LocationResponseDto>>
{
    private readonly ILocationRepository _repository;
    private readonly IMapper _mapper;

    public GetAllLocationsHandler(ILocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<LocationResponseDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        var (items, totalItems) = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
        var locationMapper = _mapper.Map<IEnumerable<LocationResponseDto>>(items);

        return new PagedResponse<LocationResponseDto>(locationMapper, request.PageNumber, request.PageSize, totalItems);
    }
}