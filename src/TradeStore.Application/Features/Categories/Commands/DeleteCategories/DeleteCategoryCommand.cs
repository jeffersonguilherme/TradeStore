using MediatR;

namespace TradeStore.Application.Features.Categories.Commands.DeleteCategories;

public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;