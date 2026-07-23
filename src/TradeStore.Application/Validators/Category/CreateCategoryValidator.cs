using FluentValidation;
using TradeStore.Application.DTOs.Category;

namespace TradeStore.Application.Validators.Category;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.NameCategory)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(100).WithMessage("Name Category must not exceed 100 characters.");
    }
}