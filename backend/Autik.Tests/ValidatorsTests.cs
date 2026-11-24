using Autik.Application.Features.Mantenimiento.DTOs;
using Autik.Application.Features.Mantenimiento.Validators;
using Xunit;

namespace Autik.Tests;

public class ValidatorsTests
{
    [Fact]
    public void CreateMantenimientoValidator_rejects_short_model()
    {
        var validator = new CreateMantenimientoValidator();
        var result = validator.Validate(new CreateMantenimientoRequestDto
        {
            MarcaModelo = "AB"
        });

        Assert.False(result.IsValid);
    }

    [Fact]
    public void CreateMantenimientoValidator_accepts_valid_model()
    {
        var validator = new CreateMantenimientoValidator();
        var result = validator.Validate(new CreateMantenimientoRequestDto
        {
            MarcaModelo = "AB"
        });

        Assert.True(result.IsValid);
    }
}
