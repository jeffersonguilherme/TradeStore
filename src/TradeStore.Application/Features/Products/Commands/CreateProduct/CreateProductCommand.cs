using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto Dto) : IRequest<ResponseModel<ProductSummaryDto>>;