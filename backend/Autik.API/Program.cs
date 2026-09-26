using DotNetEnv;
using Autik.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection") 
                       ?? throw new InvalidOperationException("Falta la cadena de conexión.");


// Llamamos al método que inyecta los repositorios y la base de datos
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();



//App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
