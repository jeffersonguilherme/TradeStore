using MediatR;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Locations.Commands.DeleteLocation;

public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, bool>
{
    private readonly ILocationRepository _repository;

    public DeleteLocationHandler(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _repository.GetByIdAsync(request.Id);

        if(location is null) return false;
        
        await _repository.DeleteAsync(request.Id);
        
        return true;
    }
}