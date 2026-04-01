using Aeropuerto.Backend.Models.RRHH;
using Aeropuerto.Backend.Models.Finanzas;
using Aeropuerto.Backend.Models.Estadisticas;
using Aeropuerto.Backend.Models.Lealtad;
using Aeropuerto.Backend.Models.Carga;
using Aeropuerto.Backend.Models.Mantenimiento;

namespace Aeropuerto.Backend.Interfaces
{
    // -------------------------------------------------------
    // MODULO 15 - RRHH
    // -------------------------------------------------------
    public interface IRRHHService
    {
        Task<List<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento?> GetDepartamentoByIdAsync(int id);
        Task InsertDepartamentoAsync(Departamento departamento);
        Task UpdateDepartamentoAsync(Departamento departamento);
        Task DeleteDepartamentoAsync(int id);

        Task<List<PuestoTrabajo>> GetAllPuestosAsync();
        Task<PuestoTrabajo?> GetPuestoByIdAsync(int id);
        Task InsertPuestoAsync(PuestoTrabajo puesto);
        Task UpdatePuestoAsync(PuestoTrabajo puesto);
        Task DeletePuestoAsync(int id);

        Task<List<Empleado>> GetAllEmpleadosAsync();
        Task<Empleado?> GetEmpleadoByIdAsync(int id);
        Task InsertEmpleadoAsync(Empleado empleado);
        Task UpdateEmpleadoAsync(Empleado empleado);
        Task DeleteEmpleadoAsync(int id);

        Task<List<Capacitacion>> GetAllCapacitacionesAsync();
        Task<Capacitacion?> GetCapacitacionByIdAsync(int id);
        Task InsertCapacitacionAsync(Capacitacion capacitacion);
        Task UpdateCapacitacionAsync(Capacitacion capacitacion);
        Task DeleteCapacitacionAsync(int id);
    }

    // -------------------------------------------------------
    // MODULO 16 - FINANZAS
    // -------------------------------------------------------
    public interface IFinanzasService
    {
        Task<List<Proveedor>> GetAllProveedoresAsync();
        Task<Proveedor?> GetProveedorByIdAsync(int id);
        Task InsertProveedorAsync(Proveedor proveedor);
        Task UpdateProveedorAsync(Proveedor proveedor);
        Task DeleteProveedorAsync(int id);

        Task<List<TasaAeroportuaria>> GetAllTasasAsync();
        Task<TasaAeroportuaria?> GetTasaByIdAsync(int id);
        Task InsertTasaAsync(TasaAeroportuaria tasa);
        Task UpdateTasaAsync(TasaAeroportuaria tasa);
        Task DeleteTasaAsync(int id);

        Task<List<CuentaBancaria>> GetAllCuentasAsync();
        Task<CuentaBancaria?> GetCuentaByIdAsync(int id);
        Task InsertCuentaAsync(CuentaBancaria cuenta);
        Task UpdateCuentaAsync(CuentaBancaria cuenta);
        Task DeleteCuentaAsync(int id);
    }

    // -------------------------------------------------------
    // MODULO 17 - ESTADISTICAS
    // -------------------------------------------------------
    public interface IEstadisticasService
    {
        Task<List<EstadisticaVuelo>> GetAllEstadisticasAsync();
        Task<EstadisticaVuelo?> GetEstadisticaByIdAsync(int id);
        Task InsertEstadisticaAsync(EstadisticaVuelo estadistica);
        Task UpdateEstadisticaAsync(EstadisticaVuelo estadistica);
        Task DeleteEstadisticaAsync(int id);

        Task<List<ReporteOperacional>> GetAllReportesAsync();
        Task<ReporteOperacional?> GetReporteByIdAsync(int id);
        Task InsertReporteAsync(ReporteOperacional reporte);
        Task UpdateReporteAsync(ReporteOperacional reporte);
        Task DeleteReporteAsync(int id);
    }

    // -------------------------------------------------------
    // MODULO 18 - LEALTAD
    // -------------------------------------------------------
    public interface ILealtadService
    {
        Task<List<ProgramaLealtad>> GetAllProgramasAsync();
        Task<ProgramaLealtad?> GetProgramaByIdAsync(int id);
        Task InsertProgramaAsync(ProgramaLealtad programa);
        Task UpdateProgramaAsync(ProgramaLealtad programa);
        Task DeleteProgramaAsync(int id);

        Task<List<MiembroLealtad>> GetAllMiembrosAsync();
        Task<MiembroLealtad?> GetMiembroByIdAsync(int id);
        Task InsertMiembroAsync(MiembroLealtad miembro);
        Task UpdateMiembroAsync(MiembroLealtad miembro);
        Task DeleteMiembroAsync(int id);
    }

    // -------------------------------------------------------
    // MODULO 19 - CARGA
    // -------------------------------------------------------
    public interface ICargaService
    {
        Task<List<TipoCarga>> GetAllTiposCargaAsync();
        Task<TipoCarga?> GetTipoCargaByIdAsync(int id);
        Task InsertTipoCargaAsync(TipoCarga tipoCarga);
        Task UpdateTipoCargaAsync(TipoCarga tipoCarga);
        Task DeleteTipoCargaAsync(int id);

        Task<List<BodegaCarga>> GetAllBodegasAsync();
        Task<BodegaCarga?> GetBodegaByIdAsync(int id);
        Task InsertBodegaAsync(BodegaCarga bodega);
        Task UpdateBodegaAsync(BodegaCarga bodega);
        Task DeleteBodegaAsync(int id);
    }

    // -------------------------------------------------------
    // MODULO 20 - MANTENIMIENTO
    // -------------------------------------------------------
    public interface IMantenimientoService
    {
        Task<List<SensorAvion>> GetAllSensoresAsync();
        Task<SensorAvion?> GetSensorByIdAsync(int id);
        Task InsertSensorAsync(SensorAvion sensor);
        Task UpdateSensorAsync(SensorAvion sensor);
        Task DeleteSensorAsync(int id);

        Task<List<ChecklistMantenimiento>> GetAllChecklistsAsync();
        Task<ChecklistMantenimiento?> GetChecklistByIdAsync(int id);
        Task InsertChecklistAsync(ChecklistMantenimiento checklist);
        Task UpdateChecklistAsync(ChecklistMantenimiento checklist);
        Task DeleteChecklistAsync(int id);

        Task<List<PiezaReemplazo>> GetAllPiezasAsync();
        Task<PiezaReemplazo?> GetPiezaByIdAsync(int id);
        Task InsertPiezaAsync(PiezaReemplazo pieza);
        Task UpdatePiezaAsync(PiezaReemplazo pieza);
        Task DeletePiezaAsync(int id);
    }
}
