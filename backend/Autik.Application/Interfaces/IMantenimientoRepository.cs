using Autik.Domain.Entities;

namespace Autik.Application.Interfaces;

public interface IMantenimientoRepository
{
    public Task<IEnumerable<Mantenimiento>> GetAllAsync();
    public Task<Mantenimiento>AddAsync(Mantenimiento mantenimiento);
    
    
}