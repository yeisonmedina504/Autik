namespace Autik.Application.Features.Vehiculo.DTOs;

public class CreateVehiculoRequestDto
{
    public int VehiculoId { get; set; }
    public int TallerId { get; set; }
    public DateTime Fecha { get; set; }
    public int Kilometraje { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Costo { get; set; }
}