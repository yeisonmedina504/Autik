using Autik.Application.Interfaces;
using Autik.Domain.Entities;
using Autik.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Autik.Infrastructure.Repositories;

public class TalleresRepository: ITallerRepository
{
    public readonly AutikDbContext _context;
    public TalleresRepository(AutikDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Taller>> GetAllAsync()
    {
        return await _context.talleres.ToListAsync();
    }
}