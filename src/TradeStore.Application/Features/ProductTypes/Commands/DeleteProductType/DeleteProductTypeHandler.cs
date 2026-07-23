using MediatR;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Commands.DeleteProductType;

public class DeleteProductTypeHandler : IRequestHandler<DeleteProductTypeCommand, bool>
{
    private readonly IProductTypeRepository _repository;

    public DeleteProductTypeHandler(IProductTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
    {
        var productType = await _repository.GetByIdAsync(request.Id);

        if(productType is null) return false;

        await _repository.DeleteAsync(request.Id);
        return true;
    }
}