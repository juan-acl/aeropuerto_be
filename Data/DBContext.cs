using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        // --- Modulo 15 RRHH
        public DbSet<Departamento> DEPARTAMENTOS { get; set; } = null!;
        public DbSet<Empleado> EMPLEADOS { get; set; } = null!;
        public DbSet<PuestoTrabajo> PUESTOS_TRABAJO { get; set; } = null!;
        public DbSet<Asistencia> ASISTENCIAS { get; set; } = null!;
        public DbSet<VacacionPermiso> VACACIONES_PERMISOS { get; set; } = null!;
        public DbSet<EvaluacionDesempeno> EVALUACIONES_DESEMPENO { get; set; } = null!;
        public DbSet<Capacitacion> CAPACITACIONES { get; set; } = null!;
        public DbSet<EmpleadoCapacitacion> EMPLEADOS_CAPACITACION { get; set; } = null!;
        public DbSet<UniformeEquipamiento> UNIFORMES_EQUIPAMIENTO { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoCapacitacion>()
                .HasKey(ec => new { ec.id_empleado, ec.id_capacitacion });

            base.OnModelCreating(modelBuilder);
        }

        // --- Modulo 16 Finanzas y Contabilidad
        public DbSet<Presupuesto> PRESUPUESTOS { get; set; } = null!;
        public DbSet<Ingreso> INGRESOS { get; set; } = null!;
        public DbSet<Gasto> GASTOS { get; set; } = null!;
        public DbSet<Proveedor> PROVEEDORES { get; set; } = null!;
        public DbSet<OrdenCompra> ORDENES_COMPRA { get; set; } = null!;
        public DbSet<OrdenDetalle> ORDENES_DETALLE { get; set; } = null!;
        public DbSet<TasaAeroportuaria> TASAS_AEROPORTUARIAS { get; set; } = null!;
        public DbSet<TasaAplicada> TASAS_APLICADAS { get; set; } = null!;
        public DbSet<CuentaBancaria> CUENTAS_BANCARIAS { get; set; } = null!;
        public DbSet<MovimientoBancario> MOVIMIENTOS_BANCARIOS { get; set; } = null!;

        // --- Modulo 18 Pasajeros menores y grupos especiales
        public DbSet<PasajeroMenor> PASAJEROS_MENORES { get; set; } = null!;
        public DbSet<AutorizacionMenor> AUTORIZACIONES_MENORES { get; set; } = null!;
        public DbSet<MenorNoAcompanado> MENORES_NO_ACOMPANADOS { get; set; } = null!;
        public DbSet<PasajeroMascota> PASAJEROS_MASCOTAS { get; set; } = null!;

        // --- Modulo 19 Gestion de carga
        public DbSet<EnvioCarga> ENVIOS_CARGA { get; set; } = null!;
        public DbSet<ManifiestoCarga> MANIFIESTOS_CARGA { get; set; } = null!;
        public DbSet<ManifiestoDetalle> MANIFIESTOS_DETALLE { get; set; } = null!;
        public DbSet<SeguimientoCarga> SEGUIMIENTO_CARGA { get; set; } = null!;
        public DbSet<AduanaCarga> ADUANAS_CARGA { get; set; } = null!;
        public DbSet<InspectorAduanas> INSPECTORES_ADUANAS { get; set; } = null!;
        public DbSet<BodegaCarga> BODEGAS_CARGA { get; set; } = null!;
        public DbSet<CargaUbicacion> CARGA_UBICACION { get; set; } = null!;

        // --- Modulo 20 Mantenimiento Predictivo
        public DbSet<PiezaReemplazo> PIEZAS_REEMPLAZO { get; set; } = null!;
        public DbSet<OrdenMantenimientoPredictivo> ORDENES_MANTENIMIENTO_PREDICTIVO { get; set; } = null!;
        public DbSet<ChecklistMantenimiento> CHECKLISTS_MANTENIMIENTO { get; set; } = null!;
        public DbSet<ChecklistEjecucion> CHECKLIST_EJECUCION { get; set; } = null!;
        public DbSet<TareaEjecutada> TAREAS_EJECUTADAS { get; set; } = null!;
        public DbSet<ProveedorRepuesto> PROVEEDORES_REPUESTOS { get; set; } = null!;
    }
}