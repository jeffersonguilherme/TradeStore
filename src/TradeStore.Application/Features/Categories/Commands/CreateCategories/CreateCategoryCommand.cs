using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Categories.Commands.CreateCategories;

public record CreateCategoryCommand(CreateCategoryDto Dto) : IRequest<ResponseModel<CategoryResponseDto>>;