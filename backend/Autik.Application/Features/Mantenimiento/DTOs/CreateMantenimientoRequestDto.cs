namespace Autik.Application.Features.Mantenimiento.DTOs;

public class CreateMantenimientoRequestDto
{
    public string Tipo { get; set; } = string.Empty;
    public string MarcaModelo { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public int? Anio { get; set; }
}