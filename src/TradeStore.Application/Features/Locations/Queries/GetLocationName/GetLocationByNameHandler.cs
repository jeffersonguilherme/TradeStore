using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Locations.Queries.GetLocationName;

public class GetLocationByNameHandler : IRequestHandler<GetLocationByNameQuery, ResponseModel<LocationResponseDto?>>
{
    private readonly ILocationRepository _respository;
    private readonly IMapper _mapper;

    public GetLocationByNameHandler(ILocationRepository respository, IMapper mapper)
    {
        _respository = respository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<LocationResponseDto?>> Handle(GetLocationByNameQuery request, CancellationToken cancellationToken)
    {
        var location = await _respository.GetByNameAsync(request.Name);

        if(location is null)
        {
            return new ResponseModel<LocationResponseDto?>
            {
                Dados = null,
                Mensagem = "Location not found.",
                Status = false
            };
        }

        var locationDto = _mapper.Map<LocationResponseDto>(location);
        return new ResponseModel<LocationResponseDto?>
        {
            Dados = locationDto,
            Mensagem = "Location successfully entered.",
            Status = true
        };
    }
}