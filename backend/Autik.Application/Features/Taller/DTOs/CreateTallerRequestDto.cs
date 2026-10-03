namespace Autik.Application.Features.Taller.DTOs;

public class CreateTallerRequestDto
{
    public string Nombre { get; set; } = string.Empty;
    public string? Telefono { get; set; }
}