using FluentValidation;
using TradeStore.Application.DTOs.Locations;

namespace TradeStore.Application.Validators.Location;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.LocationsName)
        .NotEmpty().WithMessage("Name Location is required")
        .MaximumLength(100).WithMessage("Name Location must not exceed 100 characters.");
    }
}