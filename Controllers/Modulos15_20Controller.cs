using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models.RRHH;
using Aeropuerto.Backend.Models.Finanzas;
using Aeropuerto.Backend.Models.Estadisticas;
using Aeropuerto.Backend.Models.Lealtad;
using Aeropuerto.Backend.Models.Carga;
using Aeropuerto.Backend.Models.Mantenimiento;

// ============================================================
// MODULO 15 - RRHH
// ============================================================
namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RRHHController : ControllerBase
    {
        private readonly IRRHHService _service;
        public RRHHController(IRRHHService service) => _service = service;

        [HttpGet("departamentos")]
        public async Task<IActionResult> GetAllDepartamentos() { try { return Ok(await _service.GetAllDepartamentosAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("departamentos/{id}")]
        public async Task<IActionResult> GetDepartamento(int id) { try { var d = await _service.GetDepartamentoByIdAsync(id); if (d == null) return NotFound(new { mensaje = "Departamento no encontrado." }); return Ok(d); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("departamentos")]
        public async Task<IActionResult> InsertDepartamento([FromBody] Departamento d) { try { await _service.InsertDepartamentoAsync(d); return Created(string.Empty, new { mensaje = "Departamento registrado.", data = d }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("departamentos/{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] Departamento d) { try { d.IdDepartamento = id; await _service.UpdateDepartamentoAsync(d); return Ok(new { mensaje = "Departamento actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("departamentos/{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id) { try { await _service.DeleteDepartamentoAsync(id); return Ok(new { mensaje = "Departamento eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("puestos")]
        public async Task<IActionResult> GetAllPuestos() { try { return Ok(await _service.GetAllPuestosAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("puestos/{id}")]
        public async Task<IActionResult> GetPuesto(int id) { try { var p = await _service.GetPuestoByIdAsync(id); if (p == null) return NotFound(new { mensaje = "Puesto no encontrado." }); return Ok(p); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("puestos")]
        public async Task<IActionResult> InsertPuesto([FromBody] PuestoTrabajo p) { try { await _service.InsertPuestoAsync(p); return Created(string.Empty, new { mensaje = "Puesto registrado.", data = p }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("puestos/{id}")]
        public async Task<IActionResult> UpdatePuesto(int id, [FromBody] PuestoTrabajo p) { try { p.IdPuesto = id; await _service.UpdatePuestoAsync(p); return Ok(new { mensaje = "Puesto actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("puestos/{id}")]
        public async Task<IActionResult> DeletePuesto(int id) { try { await _service.DeletePuestoAsync(id); return Ok(new { mensaje = "Puesto eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("empleados")]
        public async Task<IActionResult> GetAllEmpleados() { try { return Ok(await _service.GetAllEmpleadosAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("empleados/{id}")]
        public async Task<IActionResult> GetEmpleado(int id) { try { var e = await _service.GetEmpleadoByIdAsync(id); if (e == null) return NotFound(new { mensaje = "Empleado no encontrado." }); return Ok(e); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("empleados")]
        public async Task<IActionResult> InsertEmpleado([FromBody] Empleado e) { try { await _service.InsertEmpleadoAsync(e); return Created(string.Empty, new { mensaje = "Empleado registrado.", data = e }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("empleados/{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, [FromBody] Empleado e) { try { e.IdEmpleado = id; await _service.UpdateEmpleadoAsync(e); return Ok(new { mensaje = "Empleado actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("empleados/{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id) { try { await _service.DeleteEmpleadoAsync(id); return Ok(new { mensaje = "Empleado eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("capacitaciones")]
        public async Task<IActionResult> GetAllCapacitaciones() { try { return Ok(await _service.GetAllCapacitacionesAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("capacitaciones/{id}")]
        public async Task<IActionResult> GetCapacitacion(int id) { try { var c = await _service.GetCapacitacionByIdAsync(id); if (c == null) return NotFound(new { mensaje = "Capacitacion no encontrada." }); return Ok(c); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("capacitaciones")]
        public async Task<IActionResult> InsertCapacitacion([FromBody] Capacitacion c) { try { await _service.InsertCapacitacionAsync(c); return Created(string.Empty, new { mensaje = "Capacitacion registrada.", data = c }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("capacitaciones/{id}")]
        public async Task<IActionResult> UpdateCapacitacion(int id, [FromBody] Capacitacion c) { try { c.IdCapacitacion = id; await _service.UpdateCapacitacionAsync(c); return Ok(new { mensaje = "Capacitacion actualizada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("capacitaciones/{id}")]
        public async Task<IActionResult> DeleteCapacitacion(int id) { try { await _service.DeleteCapacitacionAsync(id); return Ok(new { mensaje = "Capacitacion eliminada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }
    }

    // ============================================================
    // MODULO 16 - FINANZAS
    // ============================================================
    [ApiController]
    [Route("api/[controller]")]
    public class FinanzasController : ControllerBase
    {
        private readonly IFinanzasService _service;
        public FinanzasController(IFinanzasService service) => _service = service;

        [HttpGet("proveedores")]
        public async Task<IActionResult> GetAllProveedores() { try { return Ok(await _service.GetAllProveedoresAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("proveedores/{id}")]
        public async Task<IActionResult> GetProveedor(int id) { try { var p = await _service.GetProveedorByIdAsync(id); if (p == null) return NotFound(new { mensaje = "Proveedor no encontrado." }); return Ok(p); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("proveedores")]
        public async Task<IActionResult> InsertProveedor([FromBody] Proveedor p) { try { await _service.InsertProveedorAsync(p); return Created(string.Empty, new { mensaje = "Proveedor registrado.", data = p }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("proveedores/{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, [FromBody] Proveedor p) { try { p.IdProveedor = id; await _service.UpdateProveedorAsync(p); return Ok(new { mensaje = "Proveedor actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("proveedores/{id}")]
        public async Task<IActionResult> DeleteProveedor(int id) { try { await _service.DeleteProveedorAsync(id); return Ok(new { mensaje = "Proveedor eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("tasas")]
        public async Task<IActionResult> GetAllTasas() { try { return Ok(await _service.GetAllTasasAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("tasas/{id}")]
        public async Task<IActionResult> GetTasa(int id) { try { var t = await _service.GetTasaByIdAsync(id); if (t == null) return NotFound(new { mensaje = "Tasa no encontrada." }); return Ok(t); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("tasas")]
        public async Task<IActionResult> InsertTasa([FromBody] TasaAeroportuaria t) { try { await _service.InsertTasaAsync(t); return Created(string.Empty, new { mensaje = "Tasa registrada.", data = t }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("tasas/{id}")]
        public async Task<IActionResult> UpdateTasa(int id, [FromBody] TasaAeroportuaria t) { try { t.IdTasa = id; await _service.UpdateTasaAsync(t); return Ok(new { mensaje = "Tasa actualizada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("tasas/{id}")]
        public async Task<IActionResult> DeleteTasa(int id) { try { await _service.DeleteTasaAsync(id); return Ok(new { mensaje = "Tasa eliminada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("cuentas")]
        public async Task<IActionResult> GetAllCuentas() { try { return Ok(await _service.GetAllCuentasAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("cuentas/{id}")]
        public async Task<IActionResult> GetCuenta(int id) { try { var c = await _service.GetCuentaByIdAsync(id); if (c == null) return NotFound(new { mensaje = "Cuenta no encontrada." }); return Ok(c); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("cuentas")]
        public async Task<IActionResult> InsertCuenta([FromBody] CuentaBancaria c) { try { await _service.InsertCuentaAsync(c); return Created(string.Empty, new { mensaje = "Cuenta registrada.", data = c }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("cuentas/{id}")]
        public async Task<IActionResult> UpdateCuenta(int id, [FromBody] CuentaBancaria c) { try { c.IdCuenta = id; await _service.UpdateCuentaAsync(c); return Ok(new { mensaje = "Cuenta actualizada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("cuentas/{id}")]
        public async Task<IActionResult> DeleteCuenta(int id) { try { await _service.DeleteCuentaAsync(id); return Ok(new { mensaje = "Cuenta eliminada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }
    }

    // ============================================================
    // MODULO 17 - ESTADISTICAS
    // ============================================================
    [ApiController]
    [Route("api/[controller]")]
    public class EstadisticasController : ControllerBase
    {
        private readonly IEstadisticasService _service;
        public EstadisticasController(IEstadisticasService service) => _service = service;

        [HttpGet("vuelos")]
        public async Task<IActionResult> GetAllEstadisticas() { try { return Ok(await _service.GetAllEstadisticasAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("vuelos/{id}")]
        public async Task<IActionResult> GetEstadistica(int id) { try { var e = await _service.GetEstadisticaByIdAsync(id); if (e == null) return NotFound(new { mensaje = "Estadistica no encontrada." }); return Ok(e); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("vuelos")]
        public async Task<IActionResult> InsertEstadistica([FromBody] EstadisticaVuelo e) { try { await _service.InsertEstadisticaAsync(e); return Created(string.Empty, new { mensaje = "Estadistica registrada.", data = e }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("vuelos/{id}")]
        public async Task<IActionResult> UpdateEstadistica(int id, [FromBody] EstadisticaVuelo e) { try { e.IdEstadistica = id; await _service.UpdateEstadisticaAsync(e); return Ok(new { mensaje = "Estadistica actualizada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("vuelos/{id}")]
        public async Task<IActionResult> DeleteEstadistica(int id) { try { await _service.DeleteEstadisticaAsync(id); return Ok(new { mensaje = "Estadistica eliminada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("reportes")]
        public async Task<IActionResult> GetAllReportes() { try { return Ok(await _service.GetAllReportesAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("reportes/{id}")]
        public async Task<IActionResult> GetReporte(int id) { try { var r = await _service.GetReporteByIdAsync(id); if (r == null) return NotFound(new { mensaje = "Reporte no encontrado." }); return Ok(r); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("reportes")]
        public async Task<IActionResult> InsertReporte([FromBody] ReporteOperacional r) { try { await _service.InsertReporteAsync(r); return Created(string.Empty, new { mensaje = "Reporte registrado.", data = r }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("reportes/{id}")]
        public async Task<IActionResult> UpdateReporte(int id, [FromBody] ReporteOperacional r) { try { r.IdReporte = id; await _service.UpdateReporteAsync(r); return Ok(new { mensaje = "Reporte actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("reportes/{id}")]
        public async Task<IActionResult> DeleteReporte(int id) { try { await _service.DeleteReporteAsync(id); return Ok(new { mensaje = "Reporte eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }
    }

    // ============================================================
    // MODULO 18 - LEALTAD
    // ============================================================
    [ApiController]
    [Route("api/[controller]")]
    public class LealtadController : ControllerBase
    {
        private readonly ILealtadService _service;
        public LealtadController(ILealtadService service) => _service = service;

        [HttpGet("programas")]
        public async Task<IActionResult> GetAllProgramas() { try { return Ok(await _service.GetAllProgramasAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("programas/{id}")]
        public async Task<IActionResult> GetPrograma(int id) { try { var p = await _service.GetProgramaByIdAsync(id); if (p == null) return NotFound(new { mensaje = "Programa no encontrado." }); return Ok(p); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("programas")]
        public async Task<IActionResult> InsertPrograma([FromBody] ProgramaLealtad p) { try { await _service.InsertProgramaAsync(p); return Created(string.Empty, new { mensaje = "Programa registrado.", data = p }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("programas/{id}")]
        public async Task<IActionResult> UpdatePrograma(int id, [FromBody] ProgramaLealtad p) { try { p.IdPrograma = id; await _service.UpdateProgramaAsync(p); return Ok(new { mensaje = "Programa actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("programas/{id}")]
        public async Task<IActionResult> DeletePrograma(int id) { try { await _service.DeleteProgramaAsync(id); return Ok(new { mensaje = "Programa eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("miembros")]
        public async Task<IActionResult> GetAllMiembros() { try { return Ok(await _service.GetAllMiembrosAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("miembros/{id}")]
        public async Task<IActionResult> GetMiembro(int id) { try { var m = await _service.GetMiembroByIdAsync(id); if (m == null) return NotFound(new { mensaje = "Miembro no encontrado." }); return Ok(m); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("miembros")]
        public async Task<IActionResult> InsertMiembro([FromBody] MiembroLealtad m) { try { await _service.InsertMiembroAsync(m); return Created(string.Empty, new { mensaje = "Miembro registrado.", data = m }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("miembros/{id}")]
        public async Task<IActionResult> UpdateMiembro(int id, [FromBody] MiembroLealtad m) { try { m.IdMiembro = id; await _service.UpdateMiembroAsync(m); return Ok(new { mensaje = "Miembro actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("miembros/{id}")]
        public async Task<IActionResult> DeleteMiembro(int id) { try { await _service.DeleteMiembroAsync(id); return Ok(new { mensaje = "Miembro eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }
    }

    // ============================================================
    // MODULO 19 - CARGA
    // ============================================================
    [ApiController]
    [Route("api/[controller]")]
    public class CargaController : ControllerBase
    {
        private readonly ICargaService _service;
        public CargaController(ICargaService service) => _service = service;

        [HttpGet("tipos")]
        public async Task<IActionResult> GetAllTipos() { try { return Ok(await _service.GetAllTiposCargaAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("tipos/{id}")]
        public async Task<IActionResult> GetTipo(int id) { try { var t = await _service.GetTipoCargaByIdAsync(id); if (t == null) return NotFound(new { mensaje = "Tipo de carga no encontrado." }); return Ok(t); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("tipos")]
        public async Task<IActionResult> InsertTipo([FromBody] TipoCarga t) { try { await _service.InsertTipoCargaAsync(t); return Created(string.Empty, new { mensaje = "Tipo registrado.", data = t }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("tipos/{id}")]
        public async Task<IActionResult> UpdateTipo(int id, [FromBody] TipoCarga t) { try { t.IdTipoCarga = id; await _service.UpdateTipoCargaAsync(t); return Ok(new { mensaje = "Tipo actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("tipos/{id}")]
        public async Task<IActionResult> DeleteTipo(int id) { try { await _service.DeleteTipoCargaAsync(id); return Ok(new { mensaje = "Tipo eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("bodegas")]
        public async Task<IActionResult> GetAllBodegas() { try { return Ok(await _service.GetAllBodegasAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("bodegas/{id}")]
        public async Task<IActionResult> GetBodega(int id) { try { var b = await _service.GetBodegaByIdAsync(id); if (b == null) return NotFound(new { mensaje = "Bodega no encontrada." }); return Ok(b); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("bodegas")]
        public async Task<IActionResult> InsertBodega([FromBody] BodegaCarga b) { try { await _service.InsertBodegaAsync(b); return Created(string.Empty, new { mensaje = "Bodega registrada.", data = b }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("bodegas/{id}")]
        public async Task<IActionResult> UpdateBodega(int id, [FromBody] BodegaCarga b) { try { b.IdBodega = id; await _service.UpdateBodegaAsync(b); return Ok(new { mensaje = "Bodega actualizada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("bodegas/{id}")]
        public async Task<IActionResult> DeleteBodega(int id) { try { await _service.DeleteBodegaAsync(id); return Ok(new { mensaje = "Bodega eliminada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }
    }

    // ============================================================
    // MODULO 20 - MANTENIMIENTO
    // ============================================================
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimientoService _service;
        public MantenimientoController(IMantenimientoService service) => _service = service;

        [HttpGet("sensores")]
        public async Task<IActionResult> GetAllSensores() { try { return Ok(await _service.GetAllSensoresAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("sensores/{id}")]
        public async Task<IActionResult> GetSensor(int id) { try { var s = await _service.GetSensorByIdAsync(id); if (s == null) return NotFound(new { mensaje = "Sensor no encontrado." }); return Ok(s); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("sensores")]
        public async Task<IActionResult> InsertSensor([FromBody] SensorAvion s) { try { await _service.InsertSensorAsync(s); return Created(string.Empty, new { mensaje = "Sensor registrado.", data = s }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("sensores/{id}")]
        public async Task<IActionResult> UpdateSensor(int id, [FromBody] SensorAvion s) { try { s.IdSensor = id; await _service.UpdateSensorAsync(s); return Ok(new { mensaje = "Sensor actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("sensores/{id}")]
        public async Task<IActionResult> DeleteSensor(int id) { try { await _service.DeleteSensorAsync(id); return Ok(new { mensaje = "Sensor eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("checklists")]
        public async Task<IActionResult> GetAllChecklists() { try { return Ok(await _service.GetAllChecklistsAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("checklists/{id}")]
        public async Task<IActionResult> GetChecklist(int id) { try { var c = await _service.GetChecklistByIdAsync(id); if (c == null) return NotFound(new { mensaje = "Checklist no encontrado." }); return Ok(c); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("checklists")]
        public async Task<IActionResult> InsertChecklist([FromBody] ChecklistMantenimiento c) { try { await _service.InsertChecklistAsync(c); return Created(string.Empty, new { mensaje = "Checklist registrado.", data = c }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("checklists/{id}")]
        public async Task<IActionResult> UpdateChecklist(int id, [FromBody] ChecklistMantenimiento c) { try { c.IdChecklist = id; await _service.UpdateChecklistAsync(c); return Ok(new { mensaje = "Checklist actualizado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("checklists/{id}")]
        public async Task<IActionResult> DeleteChecklist(int id) { try { await _service.DeleteChecklistAsync(id); return Ok(new { mensaje = "Checklist eliminado." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("piezas")]
        public async Task<IActionResult> GetAllPiezas() { try { return Ok(await _service.GetAllPiezasAsync()); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpGet("piezas/{id}")]
        public async Task<IActionResult> GetPieza(int id) { try { var p = await _service.GetPiezaByIdAsync(id); if (p == null) return NotFound(new { mensaje = "Pieza no encontrada." }); return Ok(p); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPost("piezas")]
        public async Task<IActionResult> InsertPieza([FromBody] PiezaReemplazo p) { try { await _service.InsertPiezaAsync(p); return Created(string.Empty, new { mensaje = "Pieza registrada.", data = p }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpPut("piezas/{id}")]
        public async Task<IActionResult> UpdatePieza(int id, [FromBody] PiezaReemplazo p) { try { p.IdPieza = id; await _service.UpdatePiezaAsync(p); return Ok(new { mensaje = "Pieza actualizada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }

        [HttpDelete("piezas/{id}")]
        public async Task<IActionResult> DeletePieza(int id) { try { await _service.DeletePiezaAsync(id); return Ok(new { mensaje = "Pieza eliminada." }); } catch (Exception ex) { return StatusCode(500, new { mensaje = ex.Message }); } }
    }
}
