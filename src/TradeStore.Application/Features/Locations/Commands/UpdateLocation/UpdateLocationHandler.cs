using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Locations.Commands.UpdateLocation;

public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, ResponseModel<LocationResponseDto>>
{
    private readonly ILocationRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLocationHandler(ILocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<LocationResponseDto>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
       var location = await _repository.GetByIdAsync(request.Id);

       if(location is null)
       return new ResponseModel<LocationResponseDto>
       {
           Mensagem = "Location not found.",
           Status = false
       };

       location.Update(request.Dto.LocationsName);
       await _repository.UpdateAsync(location);

       var locationResponse = _mapper.Map<LocationResponseDto>(location);

       return new ResponseModel<LocationResponseDto>
       {
           Dados = locationResponse,
           Mensagem = "Location updated successfully."
       };
    }
}