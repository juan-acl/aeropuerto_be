using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión a Oracle usando EF Core
builder.Services.AddDbContext<DBContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// Registro de tus servicios -- Modulo 15 RRHH
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IPuestoService, PuestoService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IVacacionesService, VacacionesService>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();
builder.Services.AddScoped<ICapacitacionService, CapacitacionService>();
builder.Services.AddScoped<IEmpCapaService, EmpCapaService>();
//modulo -- 16 finanzas y contabilidad
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();
builder.Services.AddScoped<IIngresoService, IngresoService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<IOrdenDetalleService, OrdenDetalleService>();
builder.Services.AddScoped<ITasaService, TasaService>();
builder.Services.AddScoped<ITasaAplicadaService, TasaAplicadaService>();
builder.Services.AddScoped<ICuentaBancariaService, CuentaBancariaService>();
builder.Services.AddScoped<IMovimientoBancarioService, MovimientoBancarioService>();
//modulo -- 17 pasajeros menores y grupos especiales
builder.Services.AddScoped<IPasajeroMenorService, PasajeroMenorService>();
builder.Services.AddScoped<IAutorizacionMenorService, AutorizacionMenorService>();
builder.Services.AddScoped<IMenorNoAcompanadoService, MenorNoAcompanadoService>();
builder.Services.AddScoped<IPasajeroMascotaService, PasajeroMascotaService>();
//modulo -- 19 gestion de carga
builder.Services.AddScoped<IEnvioCargaService, EnvioCargaService>();
builder.Services.AddScoped<IManifiestoCargaService, ManifiestoCargaService>();
builder.Services.AddScoped<IManifiestoDetalleService, ManifiestoDetalleService>();
builder.Services.AddScoped<ISeguimientoCargaService, SeguimientoCargaService>();
builder.Services.AddScoped<IAduanaCargaService, AduanaCargaService>();
builder.Services.AddScoped<IInspectorAduanaService, InspectorAduanaService>();
builder.Services.AddScoped<IBodegaCargaService, BodegaCargaService>();
builder.Services.AddScoped<ICargaUbicacionService, CargaUbicacionService>();
//modulo -- 20 mantenimineto predictivo
builder.Services.AddScoped<IPiezaReemplazoService, PiezaReemplazoService>();
builder.Services.AddScoped<IOrdenMantenimientoPredictivoService, OrdenMantenimientoPredictivoService>();
builder.Services.AddScoped<IChecklistMantenimientoService, ChecklistMantenimientoService>();
builder.Services.AddScoped<IChecklistEjecucionService, ChecklistEjecucionService>();
builder.Services.AddScoped<ITareaEjecutadaService, TareaEjecutadaService>();
builder.Services.AddScoped<IProveedorRepuestoService, ProveedorRepuestoService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();