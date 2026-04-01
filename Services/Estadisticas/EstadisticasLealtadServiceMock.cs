using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models.Estadisticas;
using Aeropuerto.Backend.Models.Lealtad;

namespace Aeropuerto.Backend.Services.Estadisticas
{
    public class EstadisticasServiceMock : IEstadisticasService
    {
        private readonly List<EstadisticaVuelo> _estadisticas = new()
        {
            new() { IdEstadistica = 1, Periodo = "Enero 2025", FechaInicio = new DateTime(2025,1,1), FechaFin = new DateTime(2025,1,31), TotalVuelos = 620, VuelosPuntual = 541, VuelosRetrasados = 72, VuelosCancelados = 7, TotalPasajeros = 89450, OcupacionPromedio = 84.5m, Activo = 1 },
            new() { IdEstadistica = 2, Periodo = "Febrero 2025", FechaInicio = new DateTime(2025,2,1), FechaFin = new DateTime(2025,2,28), TotalVuelos = 558, VuelosPuntual = 489, VuelosRetrasados = 61, VuelosCancelados = 8, TotalPasajeros = 80600, OcupacionPromedio = 82.1m, Activo = 1 },
            new() { IdEstadistica = 3, Periodo = "Marzo 2025", FechaInicio = new DateTime(2025,3,1), FechaFin = new DateTime(2025,3,31), TotalVuelos = 690, VuelosPuntual = 612, VuelosRetrasados = 71, VuelosCancelados = 7, TotalPasajeros = 97800, OcupacionPromedio = 87.3m, Activo = 1 }
        };

        private readonly List<ReporteOperacional> _reportes = new()
        {
            new() { IdReporte = 1, NombreReporte = "Informe Mensual de Operaciones", TipoReporte = "Operacional", Descripcion = "Resumen de operaciones del mes de enero 2025", FechaGeneracion = new DateTime(2025,2,5), GeneradoPor = "Carlos Mendez", PeriodoDesde = new DateTime(2025,1,1), PeriodoHasta = new DateTime(2025,1,31), Activo = 1 },
            new() { IdReporte = 2, NombreReporte = "Reporte de Puntualidad Q1", TipoReporte = "Puntualidad", Descripcion = "Analisis de puntualidad del primer trimestre", FechaGeneracion = new DateTime(2025,4,2), GeneradoPor = "Maria Lopez", PeriodoDesde = new DateTime(2025,1,1), PeriodoHasta = new DateTime(2025,3,31), Activo = 1 }
        };

        public Task<List<EstadisticaVuelo>> GetAllEstadisticasAsync() => Task.FromResult(_estadisticas);
        public Task<EstadisticaVuelo?> GetEstadisticaByIdAsync(int id) => Task.FromResult(_estadisticas.FirstOrDefault(x => x.IdEstadistica == id));
        public Task InsertEstadisticaAsync(EstadisticaVuelo e) { e.IdEstadistica = _estadisticas.Count > 0 ? _estadisticas.Max(x => x.IdEstadistica) + 1 : 1; _estadisticas.Add(e); return Task.CompletedTask; }
        public Task UpdateEstadisticaAsync(EstadisticaVuelo e) { var i = _estadisticas.FindIndex(x => x.IdEstadistica == e.IdEstadistica); if (i >= 0) _estadisticas[i] = e; return Task.CompletedTask; }
        public Task DeleteEstadisticaAsync(int id) { _estadisticas.RemoveAll(x => x.IdEstadistica == id); return Task.CompletedTask; }

        public Task<List<ReporteOperacional>> GetAllReportesAsync() => Task.FromResult(_reportes);
        public Task<ReporteOperacional?> GetReporteByIdAsync(int id) => Task.FromResult(_reportes.FirstOrDefault(x => x.IdReporte == id));
        public Task InsertReporteAsync(ReporteOperacional r) { r.IdReporte = _reportes.Count > 0 ? _reportes.Max(x => x.IdReporte) + 1 : 1; _reportes.Add(r); return Task.CompletedTask; }
        public Task UpdateReporteAsync(ReporteOperacional r) { var i = _reportes.FindIndex(x => x.IdReporte == r.IdReporte); if (i >= 0) _reportes[i] = r; return Task.CompletedTask; }
        public Task DeleteReporteAsync(int id) { _reportes.RemoveAll(x => x.IdReporte == id); return Task.CompletedTask; }
    }
}

namespace Aeropuerto.Backend.Services.Lealtad
{
    using Aeropuerto.Backend.Interfaces;
    using Aeropuerto.Backend.Models.Lealtad;

    public class LealtadServiceMock : ILealtadService
    {
        private readonly List<ProgramaLealtad> _programas = new()
        {
            new() { IdPrograma = 1, NombrePrograma = "Aurora Miles", Descripcion = "Programa de viajero frecuente del aeropuerto", PuntosPorVuelo = 100, PuntosCanjeMinimo = 5000, Vigente = 1 },
            new() { IdPrograma = 2, NombrePrograma = "Aurora Business", Descripcion = "Programa premium para viajeros de negocios", PuntosPorVuelo = 200, PuntosCanjeMinimo = 3000, Vigente = 1 }
        };

        private readonly List<MiembroLealtad> _miembros = new()
        {
            new() { IdMiembro = 1, NombreMiembro = "Jose Pablo Ramirez", Email = "jpramirez@email.com", Nivel = "Oro", PuntosAcumulados = 25400, PuntosCanjeados = 5000, FechaIngreso = new DateTime(2022, 3, 10), IdPrograma = 1, NombrePrograma = "Aurora Miles", Activo = 1 },
            new() { IdMiembro = 2, NombreMiembro = "Maria Elena Vasquez", Email = "mevasquez@email.com", Nivel = "Plata", PuntosAcumulados = 12800, PuntosCanjeados = 2000, FechaIngreso = new DateTime(2023, 7, 5), IdPrograma = 1, NombrePrograma = "Aurora Miles", Activo = 1 },
            new() { IdMiembro = 3, NombreMiembro = "Andres Corporacion SA", Email = "viajes@andrescorp.gt", Nivel = "Platino", PuntosAcumulados = 87500, PuntosCanjeados = 15000, FechaIngreso = new DateTime(2021, 1, 15), IdPrograma = 2, NombrePrograma = "Aurora Business", Activo = 1 }
        };

        public Task<List<ProgramaLealtad>> GetAllProgramasAsync() => Task.FromResult(_programas);
        public Task<ProgramaLealtad?> GetProgramaByIdAsync(int id) => Task.FromResult(_programas.FirstOrDefault(x => x.IdPrograma == id));
        public Task InsertProgramaAsync(ProgramaLealtad p) { p.IdPrograma = _programas.Count > 0 ? _programas.Max(x => x.IdPrograma) + 1 : 1; _programas.Add(p); return Task.CompletedTask; }
        public Task UpdateProgramaAsync(ProgramaLealtad p) { var i = _programas.FindIndex(x => x.IdPrograma == p.IdPrograma); if (i >= 0) _programas[i] = p; return Task.CompletedTask; }
        public Task DeleteProgramaAsync(int id) { _programas.RemoveAll(x => x.IdPrograma == id); return Task.CompletedTask; }

        public Task<List<MiembroLealtad>> GetAllMiembrosAsync() => Task.FromResult(_miembros);
        public Task<MiembroLealtad?> GetMiembroByIdAsync(int id) => Task.FromResult(_miembros.FirstOrDefault(x => x.IdMiembro == id));
        public Task InsertMiembroAsync(MiembroLealtad m) { m.IdMiembro = _miembros.Count > 0 ? _miembros.Max(x => x.IdMiembro) + 1 : 1; _miembros.Add(m); return Task.CompletedTask; }
        public Task UpdateMiembroAsync(MiembroLealtad m) { var i = _miembros.FindIndex(x => x.IdMiembro == m.IdMiembro); if (i >= 0) _miembros[i] = m; return Task.CompletedTask; }
        public Task DeleteMiembroAsync(int id) { _miembros.RemoveAll(x => x.IdMiembro == id); return Task.CompletedTask; }
    }
}
