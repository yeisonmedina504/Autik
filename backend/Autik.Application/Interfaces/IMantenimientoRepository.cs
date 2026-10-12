using Autik.Domain.Entities;

namespace Autik.Application.Interfaces;

public interface IMantenimientoRepository
{
    public Task<IEnumerable<Mantenimiento>> GetAllAsync();
    public Task<Mantenimiento>AddAsync(Mantenimiento mantenimiento);
    
    public Task<Mantenimiento?>GetByIdAsync(int id);
    
    public Task<Mantenimiento?> DeleteAsync(int id);
    
    //updateAsync
    public Task<Mantenimiento?> UpdateAsync(Mantenimiento mantenimiento);
    
    
}