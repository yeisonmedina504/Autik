using Autik.Application.Features.Taller.DTOs;
using FluentValidation;

namespace Autik.Application.Features.Taller.Validators;

public class CreateTallerValidator: AbstractValidator<CreateTallerRequestDto>
{
    public CreateTallerValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(10).WithMessage("{PropertyName} must contain 10 characters.")
            .MaximumLength(100).WithMessage("{PropertyName} must contain 100 characters.");
    }
}