using Autik.Application.Features.Mantenimiento.DTOs;
using FluentValidation;

namespace Autik.Application.Features.Mantenimiento.Validators;

public class CreateMantenimientoValidator: AbstractValidator<CreateMantenimientoRequestDto>
{ 
  public CreateMantenimientoValidator()
  {
      RuleFor(x => x.MarcaModelo)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .MinimumLength(3).WithMessage("{PropertyName} must contain 3 characters.")
          .MaximumLength(100).WithMessage("{PropertyName} must contain 100 characters.");
  }   
}