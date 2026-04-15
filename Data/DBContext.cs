using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        // ── Módulo 1: Infraestructura ─────────────────────────────────────────
        public DbSet<AeropuertoModel>            Aeropuertos           { get; set; } = null!;
        public DbSet<PistaAterrizajeModel>       PistasAterrizaje      { get; set; } = null!;
        public DbSet<PuertaEmbarqueModel>        PuertasEmbarque       { get; set; } = null!;
        public DbSet<TerminalAeropuertoModel>    Terminales            { get; set; } = null!;
        public DbSet<HangarModel>                Hangares              { get; set; } = null!;

        // ── Módulo 2: Flota ───────────────────────────────────────────────────
        public DbSet<FabricanteAvionModel>       FabricantesAviones    { get; set; } = null!;
        public DbSet<ModeloAvionModel>           ModelosAviones        { get; set; } = null!;
        public DbSet<MotorAvionModel>            MotoresAviones        { get; set; } = null!;
        public DbSet<AvionModel>                 Aviones               { get; set; } = null!;
        public DbSet<MantenimientoAvionModel>    MantenimientosAviones { get; set; } = null!;
        public DbSet<FranquiciaEquipajeModel>    FranquiciasEquipaje   { get; set; } = null!;

        // ── Módulo 3: Aerolíneas ──────────────────────────────────────────────
        public DbSet<AerolineaModel>             Aerolineas            { get; set; } = null!;
        public DbSet<AlianzaAerolineaModel>      AlianzasAerolineas    { get; set; } = null!;
        public DbSet<TipoAerolineaModel>         TiposAerolinea        { get; set; } = null!;
        public DbSet<TipoAeropuertoModel>        TiposAeropuerto       { get; set; } = null!;

        // ── Módulo 4: Programación ────────────────────────────────────────────
        public DbSet<TemporadaVueloModel>        TemporadasVuelo       { get; set; } = null!;
        public DbSet<DiaOperacionModel>          DiasOperacion         { get; set; } = null!;
        public DbSet<ProgramaVueloModel>         ProgramasVuelo        { get; set; } = null!;
        public DbSet<FrecuenciaVueloModel>       FrecuenciasVuelo      { get; set; } = null!;
        public DbSet<TarifaVueloModel>           TarifasVuelo          { get; set; } = null!;

        // ── Módulo 5: Operaciones de vuelo ────────────────────────────────────
        public DbSet<VueloModel>                 Vuelos                { get; set; } = null!;
        public DbSet<CondicionMeteorologicaModel> CondicionesMeteorologicas { get; set; } = null!;
        public DbSet<IncidenteVueloModel>        IncidentesVuelo       { get; set; } = null!;
        public DbSet<RetrasoVueloModel>          RetrasosVuelo         { get; set; } = null!;
        public DbSet<TripulacionVueloModel>      TripulacionVuelo      { get; set; } = null!;

        // ── Módulo 6: Tripulación ─────────────────────────────────────────────
        public DbSet<TripulacionModel>           Tripulacion           { get; set; } = null!;

        // ── Módulo 21: Tiempo Real ────────────────────────────────────────────
        public DbSet<AsignacionPistasTiempoReal> AsignacionesPistas    { get; set; } = null!;
        public DbSet<RetrasosTiempoReal>         RetrasosTiempoReal    { get; set; } = null!;
        public DbSet<SlotsAeropuerto>            SlotsAeropuerto       { get; set; } = null!;
        public DbSet<CapacidadTerminalTiempoReal> CapacidadTerminal    { get; set; } = null!;
        public DbSet<CondicionesPistaTiempoReal>  CondicionesPista     { get; set; } = null!;
        public DbSet<PosicionesRadar>            PosicionesRadar       { get; set; } = null!;
        public DbSet<TorreControlComunicaciones> TorreControl          { get; set; } = null!;
        public DbSet<HistorialFlujoTrafico>      HistorialFlujo        { get; set; } = null!;
        public DbSet<PrediccionDemanda>          PrediccionDemanda     { get; set; } = null!;

        // ── Módulo 22: Combustible ────────────────────────────────────────────
        public DbSet<PedidosCombustible>         PedidosCombustible    { get; set; } = null!;
        public DbSet<ProveedoresCombustible>     ProveedoresCombustible { get; set; } = null!;

        // ── Módulo 24: Seguridad Informática ─────────────────────────────────
        public DbSet<LogsAccesoSistema>          LogsAcceso            { get; set; } = null!;
        public DbSet<TokensAutenticacion>        Tokens                { get; set; } = null!;
        public DbSet<BitacoraCambiosDb>          BitacoraCambios       { get; set; } = null!;
        public DbSet<RespaldosSistema>           Respaldos             { get; set; } = null!;

        // ── Módulo 25: Marketing ──────────────────────────────────────────────
        public DbSet<NewsletterEnvios>           NewsletterEnvios      { get; set; } = null!;
        public DbSet<AnalisisComportamiento>     AnalisisComportamiento { get; set; } = null!;

        // ── Módulo 26: Documental ─────────────────────────────────────────────
        public DbSet<RevisionesDocumentos>       RevisionesDocumentos  { get; set; } = null!;

        // ── Módulo 29: OACI ───────────────────────────────────────────────────
        public DbSet<EstandaresInternacionales>  EstandaresInternacionales { get; set; } = null!;
        public DbSet<CodigosOaciPaises>          CodigosOaci           { get; set; } = null!;

        // ── Sistema ───────────────────────────────────────────────────────────
        public DbSet<SegmentosClientes>          SegmentosClientes     { get; set; } = null!;
        public DbSet<SeriesVueloAsignadas>       SeriesVueloAsignadas  { get; set; } = null!;
    }
}