using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Locations.Queries.GetLocationById;

public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, ResponseModel<LocationResponseDto?>>
{
    private readonly ILocationRepository _respository;
    private readonly IMapper _mapper;

    public GetLocationByIdHandler(ILocationRepository respository, IMapper mapper)
    {
        _respository = respository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<LocationResponseDto?>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _respository.GetByIdAsync(request.Id);
        if(location is null)
        return new ResponseModel<LocationResponseDto?>
        {
            Dados = null,
            Mensagem = "Location no found.",
            Status = false
        };

        var locationDto = _mapper.Map<LocationResponseDto>(location);
        return new ResponseModel<LocationResponseDto?>
        {
            Dados = locationDto,
            Mensagem = "Location found successfully.",
            Status = true
        };
    }
}