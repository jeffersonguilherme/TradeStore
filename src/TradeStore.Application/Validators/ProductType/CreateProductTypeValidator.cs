using FluentValidation;
using TradeStore.Application.DTOs.ProductTypes;

namespace TradeStore.Application.Validators.ProductType;

public class CreateProductTypeValidator : AbstractValidator<CreateProductTypeDto>
{
    public CreateProductTypeValidator()
    {
        RuleFor(x => x.NameType)
        .NotEmpty().WithMessage("Name Product is required.")
        .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
    }
}