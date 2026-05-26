using AutoMapper;
using MediatR;
using TradeStore.Application.DTOs.Category;
using TradeStore.Application.Responses;
using TradeStore.Domain.Repositories;
using TradeStore.Domain.Entities;


namespace TradeStore.Application.Features.Categories.Commands.CreateCategories;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ResponseModel<CategoryResponseDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CreateCategoryHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CategoryResponseDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var existingCategory = await _repository.GetByNameAsync(dto.NameCategory.Trim().ToLower());

        if(existingCategory is not null)
        {
            return new ResponseModel<CategoryResponseDto>
            {
                Mensagem = "Category already exists",
                Status = false
            };
        }

        var category = Category.Create(dto.NameCategory);

        await _repository.AddAsync(category);
        var categoryResponse = _mapper.Map<CategoryResponseDto>(category);

        return new ResponseModel<CategoryResponseDto>
        {
            Dados = categoryResponse,
            Mensagem = "Category Created"
        };
    }
}