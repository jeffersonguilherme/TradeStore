using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Locations;
using TradeStore.Application.Responses;
using TradeStore.Domain.Entities;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Locations.Commands.CreateLocation;

public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, ResponseModel<LocationResponseDto>>
{
    private readonly ILocationRepository _repository;
    private readonly IMapper _mapper;

    public CreateLocationHandler(ILocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<LocationResponseDto>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var existingLocation = await _repository.ExistsAsync(dto.LocationsName.Trim().ToLower());

        if(existingLocation)
        {
            return new ResponseModel<LocationResponseDto>
            {
                Mensagem = "Category already exists",
                Status = false
            };
        }

        var location = Location.Create(dto.LocationsName);

        await _repository.AddAsync(location);
        var locationResponse = _mapper.Map<LocationResponseDto>(location);

        return new ResponseModel<LocationResponseDto>
        {
            Dados = locationResponse,
            Mensagem = "Location Created"
        };
    }
}