
using Autik.Application.Features.Mantenimiento.DTOs;

namespace Autik.Application.Features.Mantenimiento.Validators;
using FluentValidation;

public class UpdateMantenimientoValidator: AbstractValidator<UpdateMantenimientoRequestDto>
{
    public UpdateMantenimientoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El id no debe estar menor o igual a 0.");
        RuleFor(x => x.MarcaModelo)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(60).WithMessage("{PropertyName} must have at least {MinLength} characters.")
            .MaximumLength(128).WithMessage("{PropertyName} must have at least {MaxLength} characters.");

    }   
}