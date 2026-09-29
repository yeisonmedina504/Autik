using Autik.Domain.Entities;

namespace Autik.Application.Interfaces;

public interface IVehiculoRepository
{
    public Task<IEnumerable<Vehiculo>> GetAllAsync();    
    public Task<Vehiculo>AddAsync(Vehiculo vehiculo);
}