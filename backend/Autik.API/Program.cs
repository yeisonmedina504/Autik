using DotNetEnv;
using Autik.Infrastructure;
using Scalar.AspNetCore;
using Autik.Application;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection") 
                       ?? throw new InvalidOperationException("Falta la cadena de conexión.");

// Leemos los orígenes permitidos desde el archivo .env del Backend
var corsAllowedOrigins = Environment.GetEnvironmentVariable("CORS_ALLOWED_ORIGINS") 
                         ?? throw new InvalidOperationException("Falta la variable CORS_ALLOWED_ORIGINS en el archivo .env.");

builder.Services.AddApplication();
// Llamamos al método que inyecta los repositorios y la base de datos
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// =========================================================================
// 1. DEFINICIÓN DE LA POLÍTICA DE SEGURIDAD CORS DINÁMICA (.env + Wildcards)
// =========================================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCorsAutik", policy =>
    {
        // Separamos por coma por si existen múltiples orígenes (ej. localhost + https://*.unah.edu.hn)
        var origenes = corsAllowedOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        policy.WithOrigins(origenes)
            .SetIsOriginAllowedToAllowWildcardSubdomains() // Habilita comodines de subdominio (ej. https://*.unah.edu.hn)
            .AllowAnyHeader()                              // Autoriza encabezados JSON y futuros Tokens JWT
            .AllowAnyMethod();                             // Autoriza verbos GET y Preflights (POST, PUT, DELETE)
    });
});


//App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //genera el documento json con el contrato de la api
    app.MapOpenApi();
    
    //levanta la interfaz grafica moderna consumiendo ese json
    app.MapScalarApiReference();
}
//
app.UseCors("PoliticaCorsAutik");
app.MapControllers();
app.Run();
