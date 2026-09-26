using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Autik.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Autik.Infrastructure.Repositories;

public class MantenimientoRepository: IMantenimientoRepository
{
    public readonly AutikDbContext  _context;

    public MantenimientoRepository(AutikDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mantenimiento>> GetAllAsync()
    {
        return await _context.mantenimientos.ToListAsync();
    }
}