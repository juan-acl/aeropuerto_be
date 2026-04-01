// ============================================================
// AGREGAR EN Program.cs - Modulos 15 al 20
// ============================================================

// --- USINGS (agregar al inicio del archivo) ---
using Aeropuerto.Backend.Services.RRHH;
using Aeropuerto.Backend.Services.Finanzas;
using Aeropuerto.Backend.Services.Estadisticas;
using Aeropuerto.Backend.Services.Lealtad;
using Aeropuerto.Backend.Services.Carga;
using Aeropuerto.Backend.Services.Mantenimiento;

// --- REGISTRO DE SERVICIOS (agregar despues de los servicios de modulos 25-28) ---
builder.Services.AddScoped<IRRHHService, RRHHServiceMock>();           // Modulo 15
builder.Services.AddScoped<IFinanzasService, FinanzasServiceMock>();   // Modulo 16
builder.Services.AddScoped<IEstadisticasService, EstadisticasServiceMock>(); // Modulo 17
builder.Services.AddScoped<ILealtadService, LealtadServiceMock>();     // Modulo 18
builder.Services.AddScoped<ICargaService, CargaServiceMock>();         // Modulo 19
builder.Services.AddScoped<IMantenimientoService, MantenimientoServiceMock>(); // Modulo 20
