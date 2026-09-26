using Autik.Application.Interfaces;
using Autik.Infrastructure.Data;
using Autik.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Autik.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString) {
        
        // 1. Configuramos el acceso a PostgreSQL
        services.AddDbContext<AutikDbContext>(options =>
            options.UseNpgsql(connectionString));

        // 2. LA INYECCIÓN CLAVE (El contrato firmado por el Gerente):
        // "Cada vez que un Chef (Controlador) pida la Receta (IHabitoRepository), 
        // entrégale los datos de la Finca PostgreSQL (HabitoRepository)"
        services.AddScoped<IMantenimientoRepository,MantenimientoRepository>();
        services.AddScoped<IVehiculoRepository, VehiculoRepository>();
        services.AddScoped<ITallerRepository, TalleresRepository>();
        

        return services;
    }
}