using DotNetEnv;
using Autik.Infrastructure;
using Scalar.AspNetCore;
using Autik.Application;

var builder = WebApplication.CreateBuilder(args);


Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection") 
                       ?? throw new InvalidOperationException("Falta la cadena de conexión.");


builder.Services.AddApplication();
// Llamamos al método que inyecta los repositorios y la base de datos
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



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


app.MapControllers();
app.Run();
