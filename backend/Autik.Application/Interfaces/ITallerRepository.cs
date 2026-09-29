using Autik.Domain.Entities;

namespace Autik.Application.Interfaces;

public interface ITallerRepository
{
    public Task<IEnumerable<Taller>> GetAllAsync();
    public Task<Taller>AddAsync(Taller taller);
}