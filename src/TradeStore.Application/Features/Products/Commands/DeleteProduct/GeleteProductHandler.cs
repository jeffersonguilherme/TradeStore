using MediatR;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Products.Commands.DeleterProduc;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetByIdAsync(request.Id);
        if(products is null) return false;

        await _repository.DeleteAsync(request.Id);
        return true;
    }
}