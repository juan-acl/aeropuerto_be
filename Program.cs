using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data; // Conexión con tu carpeta Data
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS ---

// Configuración de Controladores + Evitar cambios de nombres en JSON
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAeropuertoService, AeropuertoService>();

// CORS: Definimos el nombre de la política para reusarla
const string MiAppReact = "AllowReactApp";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MiAppReact,
        policy => {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

//Conexión a Orcale
builder.Services.AddDbContext<DBContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

var app = builder.Build();

// --- 2. CONFIGURACIÓN DEL PIPELINE (Middleware) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS debe ir antes de Authorization y MapControllers
app.UseCors(MiAppReact);

app.UseAuthorization();

app.MapControllers();

app.Run();