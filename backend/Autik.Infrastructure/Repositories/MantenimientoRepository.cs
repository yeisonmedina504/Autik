using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Autik.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Autik.Infrastructure.Repositories;

public class MantenimientoRepository: IMantenimientoRepository
{
    private readonly AutikDbContext  _context;

    public MantenimientoRepository(AutikDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mantenimiento>> GetAllAsync()
    {
        return await _context.mantenimientos.ToListAsync();
    }
    
    public async Task<Mantenimiento> AddAsync(Mantenimiento mantenimiento)
    {
        await _context.mantenimientos.AddAsync(mantenimiento);
        
        await _context.SaveChangesAsync();

        return mantenimiento;
    }

    public async Task<Mantenimiento?> GetByIdAsync(int id)
    {
        return await _context.mantenimientos.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Mantenimiento?> DeleteAsync(int id)
    {
        var mantenimiento = await _context.mantenimientos.FindAsync(id);
        if  (mantenimiento == null)
            return null;
        _context.mantenimientos.Remove(mantenimiento);
        await _context.SaveChangesAsync();
        return mantenimiento;
    }
    
    public async Task<Mantenimiento?> UpdateAsync(Mantenimiento mantenimiento)
    {
        var existente = await _context.mantenimientos.FindAsync(mantenimiento.Id);
        if (existente == null)
            return null;

        existente.Tipo = mantenimiento.Tipo;
        existente.MarcaModelo = mantenimiento.MarcaModelo;
        existente.Placa = mantenimiento.Placa;
        existente.Anio = mantenimiento.Anio;

        await _context.SaveChangesAsync();
        return existente;
    }
}