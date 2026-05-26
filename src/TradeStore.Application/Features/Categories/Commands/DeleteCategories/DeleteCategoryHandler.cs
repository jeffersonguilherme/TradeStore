using MediatR;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Categories.Commands.DeleteCategories;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if(category is null) return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}