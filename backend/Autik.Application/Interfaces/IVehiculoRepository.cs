using Autik.Domain.Entities;

namespace Autik.Application.Interfaces;

public interface IVehiculoRepository
{
    public Task<IEnumerable<Vehiculo>> GetAllAsync();    
    
    public Task<Vehiculo?> GetByIdAsync(int id);
    
    public Task<Vehiculo>AddAsync(Vehiculo vehiculo);
    
    public Task<Vehiculo?>UpdateAsync(Vehiculo vehiculo);
    
    public Task<Vehiculo?> DeleteAsync(int id);
}