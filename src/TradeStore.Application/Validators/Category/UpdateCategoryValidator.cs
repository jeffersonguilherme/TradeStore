using FluentValidation;
using TradeStore.Application.DTOs.Category;

namespace TradeStore.Application.Validators.Category;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.NameCategory)
        .NotEmpty().WithMessage("Name is required")
        .MaximumLength(100).WithMessage("Name Category not exceed 100 characters.");
    }
}