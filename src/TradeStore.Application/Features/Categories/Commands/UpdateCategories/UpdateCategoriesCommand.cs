using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Categories.Commands.UpdateCategories;

public record UpdateCategoriesCommand(Guid id, UpdateCategoryDto Dto) : IRequest<ResponseModel<CategoryResponseDto>>;