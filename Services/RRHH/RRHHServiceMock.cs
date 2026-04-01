using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models.RRHH;

namespace Aeropuerto.Backend.Services.RRHH
{
    public class RRHHServiceMock : IRRHHService
    {
        private readonly List<Departamento> _departamentos = new()
        {
            new() { IdDepartamento = 1, NombreDepartamento = "Operaciones", Descripcion = "Control de operaciones aeroportuarias", Responsable = "Carlos Mendez", Activo = 1 },
            new() { IdDepartamento = 2, NombreDepartamento = "Seguridad", Descripcion = "Control y seguridad del aeropuerto", Responsable = "Maria Lopez", Activo = 1 },
            new() { IdDepartamento = 3, NombreDepartamento = "Mantenimiento", Descripcion = "Mantenimiento de instalaciones y equipos", Responsable = "Roberto Garcia", Activo = 1 },
            new() { IdDepartamento = 4, NombreDepartamento = "Atencion al Cliente", Descripcion = "Servicio y atencion a pasajeros", Responsable = "Ana Fuentes", Activo = 1 },
            new() { IdDepartamento = 5, NombreDepartamento = "Finanzas", Descripcion = "Gestion financiera y contable", Responsable = "Luis Ramirez", Activo = 1 }
        };

        private readonly List<PuestoTrabajo> _puestos = new()
        {
            new() { IdPuesto = 1, NombrePuesto = "Controlador de Trafico Aereo", Descripcion = "Control de trafico en pista y torre", SalarioBase = 18000, IdDepartamento = 1, NombreDepartamento = "Operaciones", Activo = 1 },
            new() { IdPuesto = 2, NombrePuesto = "Agente de Seguridad", Descripcion = "Control de acceso y seguridad perimetral", SalarioBase = 7500, IdDepartamento = 2, NombreDepartamento = "Seguridad", Activo = 1 },
            new() { IdPuesto = 3, NombrePuesto = "Tecnico de Mantenimiento", Descripcion = "Mantenimiento preventivo y correctivo", SalarioBase = 9000, IdDepartamento = 3, NombreDepartamento = "Mantenimiento", Activo = 1 },
            new() { IdPuesto = 4, NombrePuesto = "Agente de Check-in", Descripcion = "Atencion en mostradores de facturacion", SalarioBase = 6500, IdDepartamento = 4, NombreDepartamento = "Atencion al Cliente", Activo = 1 }
        };

        private readonly List<Empleado> _empleados = new()
        {
            new() { IdEmpleado = 1, Nombres = "Juan Carlos", Apellidos = "Alvarez Perez", Dpi = "1234567890101", FechaNacimiento = new DateTime(1985, 3, 15), Email = "jalvarez@aeropuerto.gt", Telefono = "5500-1234", FechaIngreso = new DateTime(2018, 6, 1), IdPuesto = 1, NombrePuesto = "Controlador de Trafico Aereo", IdDepartamento = 1, NombreDepartamento = "Operaciones", Estado = "Activo", Activo = 1 },
            new() { IdEmpleado = 2, Nombres = "Sofia", Apellidos = "Martinez Ruiz", Dpi = "2345678901202", FechaNacimiento = new DateTime(1990, 7, 22), Email = "smartinez@aeropuerto.gt", Telefono = "5500-2345", FechaIngreso = new DateTime(2020, 2, 15), IdPuesto = 4, NombrePuesto = "Agente de Check-in", IdDepartamento = 4, NombreDepartamento = "Atencion al Cliente", Estado = "Activo", Activo = 1 },
            new() { IdEmpleado = 3, Nombres = "Pedro", Apellidos = "Cifuentes Lopez", Dpi = "3456789012303", FechaNacimiento = new DateTime(1982, 11, 5), Email = "pcifuentes@aeropuerto.gt", Telefono = "5500-3456", FechaIngreso = new DateTime(2015, 9, 1), IdPuesto = 3, NombrePuesto = "Tecnico de Mantenimiento", IdDepartamento = 3, NombreDepartamento = "Mantenimiento", Estado = "Activo", Activo = 1 }
        };

        private readonly List<Capacitacion> _capacitaciones = new()
        {
            new() { IdCapacitacion = 1, NombreCapacitacion = "Control de Trafico Aereo - Nivel Avanzado", Descripcion = "Actualizacion de procedimientos ATC", Tipo = "Tecnica", DuracionHoras = 40, Instructor = "Ing. Mario Santos", FechaInicio = new DateTime(2025, 3, 1), FechaFin = new DateTime(2025, 3, 15), Activo = 1 },
            new() { IdCapacitacion = 2, NombreCapacitacion = "Primeros Auxilios", Descripcion = "Atencion de emergencias medicas basicas", Tipo = "Seguridad", DuracionHoras = 16, Instructor = "Dr. Ana Cardona", FechaInicio = new DateTime(2025, 4, 10), FechaFin = new DateTime(2025, 4, 12), Activo = 1 },
            new() { IdCapacitacion = 3, NombreCapacitacion = "Atencion al Cliente", Descripcion = "Tecnicas de servicio y manejo de quejas", Tipo = "Servicio", DuracionHoras = 8, Instructor = "Lic. Carmen Vela", FechaInicio = new DateTime(2025, 5, 5), FechaFin = new DateTime(2025, 5, 6), Activo = 1 }
        };

        public Task<List<Departamento>> GetAllDepartamentosAsync() => Task.FromResult(_departamentos);
        public Task<Departamento?> GetDepartamentoByIdAsync(int id) => Task.FromResult(_departamentos.FirstOrDefault(x => x.IdDepartamento == id));
        public Task InsertDepartamentoAsync(Departamento d) { d.IdDepartamento = _departamentos.Count > 0 ? _departamentos.Max(x => x.IdDepartamento) + 1 : 1; _departamentos.Add(d); return Task.CompletedTask; }
        public Task UpdateDepartamentoAsync(Departamento d) { var i = _departamentos.FindIndex(x => x.IdDepartamento == d.IdDepartamento); if (i >= 0) _departamentos[i] = d; return Task.CompletedTask; }
        public Task DeleteDepartamentoAsync(int id) { _departamentos.RemoveAll(x => x.IdDepartamento == id); return Task.CompletedTask; }

        public Task<List<PuestoTrabajo>> GetAllPuestosAsync() => Task.FromResult(_puestos);
        public Task<PuestoTrabajo?> GetPuestoByIdAsync(int id) => Task.FromResult(_puestos.FirstOrDefault(x => x.IdPuesto == id));
        public Task InsertPuestoAsync(PuestoTrabajo p) { p.IdPuesto = _puestos.Count > 0 ? _puestos.Max(x => x.IdPuesto) + 1 : 1; _puestos.Add(p); return Task.CompletedTask; }
        public Task UpdatePuestoAsync(PuestoTrabajo p) { var i = _puestos.FindIndex(x => x.IdPuesto == p.IdPuesto); if (i >= 0) _puestos[i] = p; return Task.CompletedTask; }
        public Task DeletePuestoAsync(int id) { _puestos.RemoveAll(x => x.IdPuesto == id); return Task.CompletedTask; }

        public Task<List<Empleado>> GetAllEmpleadosAsync() => Task.FromResult(_empleados);
        public Task<Empleado?> GetEmpleadoByIdAsync(int id) => Task.FromResult(_empleados.FirstOrDefault(x => x.IdEmpleado == id));
        public Task InsertEmpleadoAsync(Empleado e) { e.IdEmpleado = _empleados.Count > 0 ? _empleados.Max(x => x.IdEmpleado) + 1 : 1; _empleados.Add(e); return Task.CompletedTask; }
        public Task UpdateEmpleadoAsync(Empleado e) { var i = _empleados.FindIndex(x => x.IdEmpleado == e.IdEmpleado); if (i >= 0) _empleados[i] = e; return Task.CompletedTask; }
        public Task DeleteEmpleadoAsync(int id) { _empleados.RemoveAll(x => x.IdEmpleado == id); return Task.CompletedTask; }

        public Task<List<Capacitacion>> GetAllCapacitacionesAsync() => Task.FromResult(_capacitaciones);
        public Task<Capacitacion?> GetCapacitacionByIdAsync(int id) => Task.FromResult(_capacitaciones.FirstOrDefault(x => x.IdCapacitacion == id));
        public Task InsertCapacitacionAsync(Capacitacion c) { c.IdCapacitacion = _capacitaciones.Count > 0 ? _capacitaciones.Max(x => x.IdCapacitacion) + 1 : 1; _capacitaciones.Add(c); return Task.CompletedTask; }
        public Task UpdateCapacitacionAsync(Capacitacion c) { var i = _capacitaciones.FindIndex(x => x.IdCapacitacion == c.IdCapacitacion); if (i >= 0) _capacitaciones[i] = c; return Task.CompletedTask; }
        public Task DeleteCapacitacionAsync(int id) { _capacitaciones.RemoveAll(x => x.IdCapacitacion == id); return Task.CompletedTask; }
    }
}
