using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Categories.Commands.UpdateCategories;

public record UpdateCategoriesCommand(Guid Id, UpdateCategoryDto Dto) : IRequest<ResponseModel<CategoryResponseDto>>;