using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, ResponseModel<CategoryResponseDto?>>
{
    
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    async Task<ResponseModel<CategoryResponseDto?>> IRequestHandler<GetCategoryByIdQuery, ResponseModel<CategoryResponseDto?>>.Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.CategoryId);

        if(category is null)
        {
            return new ResponseModel<CategoryResponseDto?>
            {
                Dados = null,
                Mensagem = "Categoria não encontrada",
                Status = false
            };

        }

        var categoryDto = _mapper.Map<CategoryResponseDto>(category);
        return new ResponseModel<CategoryResponseDto?>
        {
          Dados = categoryDto,
          Mensagem = "Categoria encontrada com sucesso",
          Status = true  
        };
    }
}