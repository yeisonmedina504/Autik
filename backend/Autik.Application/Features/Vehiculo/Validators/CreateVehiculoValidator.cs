using System.Data;
using Autik.Application.Features.Vehiculo.DTOs;
using FluentValidation;

namespace Autik.Application.Features.Vehiculo.Validators;

public class CreateVehiculoValidator: AbstractValidator<CreateVehiculoRequestDto>
{
    public CreateVehiculoValidator()
    {
        RuleFor(x => x.Descripcion)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MinimumLength(10).WithMessage("{PropertyName} must contain 10 characters.")
            .MaximumLength(100).WithMessage("{PropertyName} must contain 100 characters.");
    }
}