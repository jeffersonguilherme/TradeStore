using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;

namespace TradeStore.Application.Features.Categories.Commands.UpdateCategories;

public class UpdateCategoriesHandler : IRequestHandler<UpdateCategoriesCommand, ResponseModel<CategoryResponseDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCategoriesHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CategoryResponseDto>> Handle(UpdateCategoriesCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.id);

        if(category is null)
            return new ResponseModel<CategoryResponseDto>
            {
                Mensagem = "Categoria não encontrada"
            };
        
        category.Update(request.Dto.NameCategory);
        await _repository.UpdateAsync(category);

        var categoryResponse = _mapper.Map<CategoryResponseDto>(category);

        return new ResponseModel<CategoryResponseDto>
        {
            Dados = categoryResponse,
            Mensagem = "Categoria autalizada com sucesso"
        };
    }
}