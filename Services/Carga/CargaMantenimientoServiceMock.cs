using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models.Carga;
using Aeropuerto.Backend.Models.Mantenimiento;

namespace Aeropuerto.Backend.Services.Carga
{
    public class CargaServiceMock : ICargaService
    {
        private readonly List<TipoCarga> _tiposCarga = new()
        {
            new() { IdTipoCarga = 1, NombreTipo = "Carga General", Descripcion = "Mercancias de uso general sin restricciones especiales", RequiereRefrigeracion = 0, EsPeligrosa = 0, Activo = 1 },
            new() { IdTipoCarga = 2, NombreTipo = "Carga Perecedera", Descripcion = "Alimentos y productos que requieren refrigeracion", RequiereRefrigeracion = 1, EsPeligrosa = 0, Activo = 1 },
            new() { IdTipoCarga = 3, NombreTipo = "Carga Peligrosa", Descripcion = "Materiales clasificados como peligrosos (IATA DGR)", RequiereRefrigeracion = 0, EsPeligrosa = 1, Activo = 1 },
            new() { IdTipoCarga = 4, NombreTipo = "Carga Valiosa", Descripcion = "Obras de arte, joyas, documentos importantes", RequiereRefrigeracion = 0, EsPeligrosa = 0, Activo = 1 },
            new() { IdTipoCarga = 5, NombreTipo = "Animales Vivos", Descripcion = "Transporte de animales con condiciones especiales", RequiereRefrigeracion = 0, EsPeligrosa = 0, Activo = 1 }
        };

        private readonly List<BodegaCarga> _bodegas = new()
        {
            new() { IdBodega = 1, NombreBodega = "Bodega Principal Norte", Ubicacion = "Terminal de Carga - Sector Norte", CapacidadKg = 50000, CapacidadM3 = 800, TieneRefrigeracion = 0, Estado = "Operativa", Activo = 1 },
            new() { IdBodega = 2, NombreBodega = "Bodega Refrigerada", Ubicacion = "Terminal de Carga - Sector Sur", CapacidadKg = 15000, CapacidadM3 = 200, TieneRefrigeracion = 1, Estado = "Operativa", Activo = 1 },
            new() { IdBodega = 3, NombreBodega = "Bodega Materiales Peligrosos", Ubicacion = "Zona de Seguridad Perimetral Este", CapacidadKg = 5000, CapacidadM3 = 80, TieneRefrigeracion = 0, Estado = "Operativa", Activo = 1 },
            new() { IdBodega = 4, NombreBodega = "Bodega Carga Valiosa", Ubicacion = "Terminal de Carga - Area Segura", CapacidadKg = 2000, CapacidadM3 = 30, TieneRefrigeracion = 0, Estado = "Operativa", Activo = 1 }
        };

        public Task<List<TipoCarga>> GetAllTiposCargaAsync() => Task.FromResult(_tiposCarga);
        public Task<TipoCarga?> GetTipoCargaByIdAsync(int id) => Task.FromResult(_tiposCarga.FirstOrDefault(x => x.IdTipoCarga == id));
        public Task InsertTipoCargaAsync(TipoCarga t) { t.IdTipoCarga = _tiposCarga.Count > 0 ? _tiposCarga.Max(x => x.IdTipoCarga) + 1 : 1; _tiposCarga.Add(t); return Task.CompletedTask; }
        public Task UpdateTipoCargaAsync(TipoCarga t) { var i = _tiposCarga.FindIndex(x => x.IdTipoCarga == t.IdTipoCarga); if (i >= 0) _tiposCarga[i] = t; return Task.CompletedTask; }
        public Task DeleteTipoCargaAsync(int id) { _tiposCarga.RemoveAll(x => x.IdTipoCarga == id); return Task.CompletedTask; }

        public Task<List<BodegaCarga>> GetAllBodegasAsync() => Task.FromResult(_bodegas);
        public Task<BodegaCarga?> GetBodegaByIdAsync(int id) => Task.FromResult(_bodegas.FirstOrDefault(x => x.IdBodega == id));
        public Task InsertBodegaAsync(BodegaCarga b) { b.IdBodega = _bodegas.Count > 0 ? _bodegas.Max(x => x.IdBodega) + 1 : 1; _bodegas.Add(b); return Task.CompletedTask; }
        public Task UpdateBodegaAsync(BodegaCarga b) { var i = _bodegas.FindIndex(x => x.IdBodega == b.IdBodega); if (i >= 0) _bodegas[i] = b; return Task.CompletedTask; }
        public Task DeleteBodegaAsync(int id) { _bodegas.RemoveAll(x => x.IdBodega == id); return Task.CompletedTask; }
    }
}

namespace Aeropuerto.Backend.Services.Mantenimiento
{
    using Aeropuerto.Backend.Interfaces;
    using Aeropuerto.Backend.Models.Mantenimiento;

    public class MantenimientoServiceMock : IMantenimientoService
    {
        private readonly List<SensorAvion> _sensores = new()
        {
            new() { IdSensor = 1, NombreSensor = "Sensor de Temperatura Motor", TipoSensor = "Temperatura", Descripcion = "Monitorea la temperatura de los motores", UnidadMedida = "°C", ValorMinimo = -40, ValorMaximo = 850, Activo = 1 },
            new() { IdSensor = 2, NombreSensor = "Sensor de Presion de Cabina", TipoSensor = "Presion", Descripcion = "Controla la presion interior de la cabina", UnidadMedida = "PSI", ValorMinimo = 8, ValorMaximo = 14, Activo = 1 },
            new() { IdSensor = 3, NombreSensor = "Sensor de Nivel de Combustible", TipoSensor = "Combustible", Descripcion = "Nivel de combustible en los tanques", UnidadMedida = "Litros", ValorMinimo = 0, ValorMaximo = 50000, Activo = 1 },
            new() { IdSensor = 4, NombreSensor = "Sensor de Vibracion Motor", TipoSensor = "Vibracion", Descripcion = "Detecta vibraciones anormales en motores", UnidadMedida = "Hz", ValorMinimo = 0, ValorMaximo = 200, Activo = 1 }
        };

        private readonly List<ChecklistMantenimiento> _checklists = new()
        {
            new() { IdChecklist = 1, NombreChecklist = "Check A - Revision Basica", TipoMantenimiento = "Preventivo", Descripcion = "Revision rutinaria cada 600 horas de vuelo", Periodicidad = "Cada 600 horas", DuracionEstimadaHoras = 8, Activo = 1 },
            new() { IdChecklist = 2, NombreChecklist = "Check B - Revision Intermedia", TipoMantenimiento = "Preventivo", Descripcion = "Revision de sistemas criticos cada 3000 horas", Periodicidad = "Cada 3000 horas", DuracionEstimadaHoras = 24, Activo = 1 },
            new() { IdChecklist = 3, NombreChecklist = "Check C - Revision Mayor", TipoMantenimiento = "Mayor", Descripcion = "Revision completa de la aeronave cada 2 años", Periodicidad = "Cada 2 años", DuracionEstimadaHoras = 120, Activo = 1 },
            new() { IdChecklist = 4, NombreChecklist = "Inspeccion Pre-Vuelo", TipoMantenimiento = "Operacional", Descripcion = "Revision obligatoria antes de cada vuelo", Periodicidad = "Cada vuelo", DuracionEstimadaHoras = 1, Activo = 1 }
        };

        private readonly List<PiezaReemplazo> _piezas = new()
        {
            new() { IdPieza = 1, CodigoPieza = "FLT-001", NombrePieza = "Filtro de Aceite Motor CFM56", Descripcion = "Filtro para motor CFM56-7B", Fabricante = "CFM International", StockActual = 24, StockMinimo = 10, PrecioUnitario = 450, Activo = 1 },
            new() { IdPieza = 2, CodigoPieza = "NMT-005", NombrePieza = "Neumatico Principal 46x16", Descripcion = "Neumatico para tren de aterrizaje principal", Fabricante = "Michelin Aviation", StockActual = 8, StockMinimo = 4, PrecioUnitario = 3200, Activo = 1 },
            new() { IdPieza = 3, CodigoPieza = "SEN-012", NombrePieza = "Sensor de Presion Hidraulica", Descripcion = "Sensor para sistema hidraulico principal", Fabricante = "Parker Hannifin", StockActual = 15, StockMinimo = 6, PrecioUnitario = 1800, Activo = 1 },
            new() { IdPieza = 4, CodigoPieza = "BRK-003", NombrePieza = "Pastillas de Freno Carbon", Descripcion = "Pastillas de freno para ruedas principales", Fabricante = "Honeywell", StockActual = 32, StockMinimo = 16, PrecioUnitario = 2400, Activo = 1 }
        };

        public Task<List<SensorAvion>> GetAllSensoresAsync() => Task.FromResult(_sensores);
        public Task<SensorAvion?> GetSensorByIdAsync(int id) => Task.FromResult(_sensores.FirstOrDefault(x => x.IdSensor == id));
        public Task InsertSensorAsync(SensorAvion s) { s.IdSensor = _sensores.Count > 0 ? _sensores.Max(x => x.IdSensor) + 1 : 1; _sensores.Add(s); return Task.CompletedTask; }
        public Task UpdateSensorAsync(SensorAvion s) { var i = _sensores.FindIndex(x => x.IdSensor == s.IdSensor); if (i >= 0) _sensores[i] = s; return Task.CompletedTask; }
        public Task DeleteSensorAsync(int id) { _sensores.RemoveAll(x => x.IdSensor == id); return Task.CompletedTask; }

        public Task<List<ChecklistMantenimiento>> GetAllChecklistsAsync() => Task.FromResult(_checklists);
        public Task<ChecklistMantenimiento?> GetChecklistByIdAsync(int id) => Task.FromResult(_checklists.FirstOrDefault(x => x.IdChecklist == id));
        public Task InsertChecklistAsync(ChecklistMantenimiento c) { c.IdChecklist = _checklists.Count > 0 ? _checklists.Max(x => x.IdChecklist) + 1 : 1; _checklists.Add(c); return Task.CompletedTask; }
        public Task UpdateChecklistAsync(ChecklistMantenimiento c) { var i = _checklists.FindIndex(x => x.IdChecklist == c.IdChecklist); if (i >= 0) _checklists[i] = c; return Task.CompletedTask; }
        public Task DeleteChecklistAsync(int id) { _checklists.RemoveAll(x => x.IdChecklist == id); return Task.CompletedTask; }

        public Task<List<PiezaReemplazo>> GetAllPiezasAsync() => Task.FromResult(_piezas);
        public Task<PiezaReemplazo?> GetPiezaByIdAsync(int id) => Task.FromResult(_piezas.FirstOrDefault(x => x.IdPieza == id));
        public Task InsertPiezaAsync(PiezaReemplazo p) { p.IdPieza = _piezas.Count > 0 ? _piezas.Max(x => x.IdPieza) + 1 : 1; _piezas.Add(p); return Task.CompletedTask; }
        public Task UpdatePiezaAsync(PiezaReemplazo p) { var i = _piezas.FindIndex(x => x.IdPieza == p.IdPieza); if (i >= 0) _piezas[i] = p; return Task.CompletedTask; }
        public Task DeletePiezaAsync(int id) { _piezas.RemoveAll(x => x.IdPieza == id); return Task.CompletedTask; }
    }
}
