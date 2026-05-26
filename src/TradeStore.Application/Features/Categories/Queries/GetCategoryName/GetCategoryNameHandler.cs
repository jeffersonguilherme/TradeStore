using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Categories.Queries.GetCategoryName;

public class GetCategoryNameHandler : IRequestHandler<GetCategoryNameQuery, ResponseModel<CategoryResponseDto?>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoryNameHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CategoryResponseDto?>> Handle(GetCategoryNameQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByNameAsync(request.Name);
        if( category is null)
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
            Mensagem = "Categoria encontrada com sucesso"
        };
    }
}