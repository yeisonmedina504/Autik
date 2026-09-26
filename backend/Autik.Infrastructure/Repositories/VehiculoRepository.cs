using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Autik.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Autik.Infrastructure.Repositories;

public class VehiculoRepository:  IVehiculoRepository
{
    public readonly AutikDbContext _context;

    public VehiculoRepository(AutikDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehiculo>> GetAllAsync()
    {
        return await _context.vehiculos.ToListAsync();
    }
}