using MediatR;
using TradeStore.Application.DTOs.Product;
using TradeStore.Application.Responses;

namespace TradeStore.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Guid Id, UpdateProductDto Dto) : IRequest<ResponseModel<ProductDetailDto>>;