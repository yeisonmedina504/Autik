using Autik.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autik.Infrastructure.Data;

public class AutikDbContext: DbContext
{
    public  AutikDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Mantenimiento> mantenimientos { get; set; }
    public DbSet<Taller> talleres { get; set; }
    public DbSet<Vehiculo> vehiculos { get; set; }
}