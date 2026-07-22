using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.ProductTypes;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.ProductTypes.Commands.UpdateProductType;

public class UpdateProductTypeHandler : IRequestHandler<UpdateProductTypeCommand, ResponseModel<ProductTypeResponseDto>>
{
    private readonly IProductTypeRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductTypeHandler(IProductTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ProductTypeResponseDto>> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
    {
       var productType = await _repository.GetByIdAsync(request.Id);
       if(productType is null)
            return new ResponseModel<ProductTypeResponseDto>
            {
                Mensagem = "Product Type not found.",
                Status = false
            };

        productType.Update(request.Dto.NameType);
        await _repository.UpdateAsync(productType);

        var productTypeResponse = _mapper.Map<ProductTypeResponseDto>(productType);

        return new ResponseModel<ProductTypeResponseDto>
        {
            Dados = productTypeResponse,
            Mensagem = "Product Type updated successfully."
        };
    }
}