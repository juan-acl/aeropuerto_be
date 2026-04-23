using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 1: Infraestructura
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<AeropuertoModel>            Aeropuertos           { get; set; } = null!;
        public DbSet<PistaAterrizajeModel>       PistasAterrizaje      { get; set; } = null!;
        public DbSet<PuertaEmbarqueModel>        PuertasEmbarque       { get; set; } = null!;
        public DbSet<TerminalAeropuertoModel>    Terminales            { get; set; } = null!;
        public DbSet<HangarModel>                Hangares              { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 2: Flota
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<FabricanteAvionModel>       FabricantesAviones    { get; set; } = null!;
        public DbSet<ModeloAvionModel>           ModelosAviones        { get; set; } = null!;
        public DbSet<MotorAvionModel>            MotoresAviones        { get; set; } = null!;
        public DbSet<AvionModel>                 Aviones               { get; set; } = null!;
        public DbSet<MantenimientoAvionModel>    MantenimientosAviones { get; set; } = null!;
        public DbSet<FranquiciaEquipajeModel>    FranquiciasEquipaje   { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 3: Aerolíneas
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<AerolineaModel>             Aerolineas            { get; set; } = null!;
        public DbSet<AlianzaAerolineaModel>      AlianzasAerolineas    { get; set; } = null!;
        public DbSet<TipoAerolineaModel>         TiposAerolinea        { get; set; } = null!;
        public DbSet<TipoAeropuertoModel>        TiposAeropuerto       { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 4: Programación de vuelos
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<TemporadaVueloModel>        TemporadasVuelo       { get; set; } = null!;
        public DbSet<DiaOperacionModel>          DiasOperacion         { get; set; } = null!;
        public DbSet<ProgramaVueloModel>         ProgramasVuelo        { get; set; } = null!;
        public DbSet<FrecuenciaVueloModel>       FrecuenciasVuelo      { get; set; } = null!;
        public DbSet<TarifaVueloModel>           TarifasVuelo          { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 5: Operaciones de vuelo
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<VueloModel>                 Vuelos                { get; set; } = null!;
        public DbSet<CondicionMeteorologicaModel> CondicionesMeteorologicas { get; set; } = null!;
        public DbSet<IncidenteVueloModel>        IncidentesVuelo       { get; set; } = null!;
        public DbSet<RetrasoVueloModel>          RetrasosVuelo         { get; set; } = null!;
        public DbSet<TripulacionVueloModel>      TripulacionVuelo      { get; set; } = null!;
        public DbSet<EscalasTecnicasModel>       EscalasTecnicas       { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 6: Tripulación
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<TripulacionModel>           Tripulacion           { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 7: Pasajeros
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<PasajeroModel>              Pasajeros             { get; set; } = null!;
        public DbSet<PasajeroHistorialMedicoModel> PasajerosHistorialMedico { get; set; } = null!;
        public DbSet<PasajeroPreferenciaModel>   PasajerosPreferencias { get; set; } = null!;
        public DbSet<PasajerosDocumentosModel>   PasajerosDocumentos   { get; set; } = null!;
        public DbSet<PasajerosRedesSocialesModel> PasajerosRedesSociales { get; set; } = null!;
        public DbSet<PerfilViajeroModel>         PerfilesViajero       { get; set; } = null!;
        public DbSet<PreferenciaIdiomaModel>     PreferenciasIdiomas   { get; set; } = null!;
        public DbSet<ProhibicionesVueloModel>    ProhibicionesVuelo    { get; set; } = null!;
        public DbSet<AcompanantesViajeModel>     AcompanantesViaje     { get; set; } = null!;
        public DbSet<GruposViajeModel>           GruposViaje           { get; set; } = null!;
        public DbSet<GruposPasajerosModel>       GruposPasajeros       { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 8: Reservas
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<ReservasModel>              Reservas              { get; set; } = null!;
        public DbSet<ReservasPagosModel>         ReservasPagos         { get; set; } = null!;
        public DbSet<ReservasPromocionesModel>   ReservasPromociones   { get; set; } = null!;
        public DbSet<HistorialReservasModel>     HistorialReservas     { get; set; } = null!;
        public DbSet<MetodosPagoModel>           MetodosPago           { get; set; } = null!;
        public DbSet<FacturasModel>              Facturas              { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 9: Check-in y embarque
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<CheckinDigitalModel>        CheckinDigital        { get; set; } = null!;
        public DbSet<PasesAbordajeModel>         PasesAbordaje         { get; set; } = null!;
        public DbSet<ControlAbordajeModel>       ControlAbordaje       { get; set; } = null!;
        public DbSet<GruposEmbarqueModel>        GruposEmbarque        { get; set; } = null!;
        public DbSet<PuertasEmbarqueAsignacionModel> PuertasEmbarqueAsignacion { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 10-11: Seguridad
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<IncidentesModel>            Incidentes            { get; set; } = null!;
        public DbSet<IncidentesEvidenciaModel>   IncidentesEvidencia   { get; set; } = null!;
        public DbSet<IncidentesInvolucradosModel> IncidentesInvolucrados { get; set; } = null!;
        public DbSet<IncidentesMedidasModel>     IncidentesMedidas     { get; set; } = null!;
        public DbSet<TiposIncidentesModel>       TiposIncidentes       { get; set; } = null!;
        public DbSet<AlertasSeguridadModel>      AlertasSeguridad      { get; set; } = null!;
        public DbSet<SeguridadControlesModel>    SeguridadControles    { get; set; } = null!;
        public DbSet<VisitasSeguridadModel>      VisitasSeguridad      { get; set; } = null!;
        public DbSet<AccesosAreasRestringidasModel> AccesosAreasRestringidas { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 12: Objetos Perdidos
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<ObjetosPerdidosModel>       ObjetosPerdidos       { get; set; } = null!;
        public DbSet<ObjetosDecomisadosModel>    ObjetosDecomisados    { get; set; } = null!;
        public DbSet<ObjetosEntregadosModel>     ObjetosEntregados     { get; set; } = null!;
        public DbSet<ObjetosSeguimientoModel>    ObjetosSeguimiento    { get; set; } = null!;
        public DbSet<CategoriasObjetosModel>     CategoriasObjetos     { get; set; } = null!;
        public DbSet<ReclamacionesObjetosModel>  ReclamacionesObjetos  { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 13: Comercial
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<ConcesionesComercialesModel> ConcesionesComerciales { get; set; } = null!;
        public DbSet<TiendasProductosModel>      TiendasProductos      { get; set; } = null!;
        public DbSet<TiendasVentasModel>         TiendasVentas         { get; set; } = null!;
        public DbSet<VentasDetalleModel>         VentasDetalle         { get; set; } = null!;
        public DbSet<RestaurantesMenusModel>     RestaurantesMenus     { get; set; } = null!;
        public DbSet<SalonesVipModel>            SalonesVip            { get; set; } = null!;
        public DbSet<SalonesAccesosModel>        SalonesAccesos        { get; set; } = null!;
        public DbSet<EstacionamientoModel>       Estacionamiento       { get; set; } = null!;
        public DbSet<EstacionamientoRegistroModel> EstacionamientoRegistro { get; set; } = null!;
        public DbSet<PublicidadModel>            Publicidad            { get; set; } = null!;
        public DbSet<PromocionesModel>           Promociones           { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 14: Servicios al pasajero
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<SolicitudesEspecialesModel> SolicitudesEspeciales { get; set; } = null!;
        public DbSet<AtencionEspecialModel>      AtencionEspecial      { get; set; } = null!;
        public DbSet<EquipajeEspecialModel>      EquipajeEspecial      { get; set; } = null!;
        public DbSet<EmergenciasMedicasModel>    EmergenciasMedicas    { get; set; } = null!;
        public DbSet<EncuestasSatisfaccionModel> EncuestasSatisfaccion { get; set; } = null!;
        public DbSet<QuejasSugerenciasModel>     QuejasSugerencias     { get; set; } = null!;
        public DbSet<TransporteTerrestreModel>   TransporteTerrestre   { get; set; } = null!;
        public DbSet<HotelesCercanosModel>       HotelesCercanos       { get; set; } = null!;
        public DbSet<ProgramaLealtadModel>       ProgramaLealtad       { get; set; } = null!;
        public DbSet<BotiquinesVueloModel>       BotiquinesVuelo       { get; set; } = null!;
        public DbSet<HistorialComunicacionModel> HistorialComunicacion { get; set; } = null!;
        public DbSet<TarifasEspecialesModel>     TarifasEspeciales     { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 15: RRHH
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<Departamento>               DEPARTAMENTOS         { get; set; } = null!;
        public DbSet<Empleado>                   EMPLEADOS             { get; set; } = null!;
        public DbSet<PuestoTrabajo>              PUESTOS_TRABAJO       { get; set; } = null!;
        public DbSet<Asistencia>                 ASISTENCIAS           { get; set; } = null!;
        public DbSet<VacacionesPermiso>          VACACIONES_PERMISOS   { get; set; } = null!;
        public DbSet<EvaluacionDesempeno>        EVALUACIONES_DESEMPENO { get; set; } = null!;
        public DbSet<Capacitacion>               CAPACITACIONES        { get; set; } = null!;
        public DbSet<EmpleadoCapacitacion>       EMPLEADOS_CAPACITACION { get; set; } = null!;
        public DbSet<UniformeEquipamiento>       UNIFORMES_EQUIPAMIENTO { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 16: Finanzas y Contabilidad
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<Presupuesto>                PRESUPUESTOS          { get; set; } = null!;
        public DbSet<Ingreso>                    INGRESOS              { get; set; } = null!;
        public DbSet<Gasto>                      GASTOS                { get; set; } = null!;
        public DbSet<Proveedor>                  PROVEEDORES           { get; set; } = null!;
        public DbSet<OrdenCompra>                ORDENES_COMPRA        { get; set; } = null!;
        public DbSet<OrdenDetalle>               ORDENES_DETALLE       { get; set; } = null!;
        public DbSet<TasaAeroportuaria>          TASAS_AEROPORTUARIAS  { get; set; } = null!;
        public DbSet<TasaAplicada>               TASAS_APLICADAS       { get; set; } = null!;
        public DbSet<CuentaBancaria>             CUENTAS_BANCARIAS     { get; set; } = null!;
        public DbSet<MovimientoBancario>         MOVIMIENTOS_BANCARIOS { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 18: Pasajeros menores y grupos especiales
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<PasajeroMenor>              PASAJEROS_MENORES     { get; set; } = null!;
        public DbSet<AutorizacionMenor>          AUTORIZACIONES_MENORES { get; set; } = null!;
        public DbSet<MenorNoAcompanado>          MENORES_NO_ACOMPANADOS { get; set; } = null!;
        public DbSet<PasajeroMascota>            PASAJEROS_MASCOTAS    { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 19: Gestión de carga
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<EnvioCarga>                 ENVIOS_CARGA          { get; set; } = null!;
        public DbSet<ManifiestoCarga>            MANIFIESTOS_CARGA     { get; set; } = null!;
        public DbSet<ManifiestoDetalle>          MANIFIESTOS_DETALLE   { get; set; } = null!;
        public DbSet<SeguimientoCarga>           SEGUIMIENTO_CARGA     { get; set; } = null!;
        public DbSet<AduanaCarga>                ADUANAS_CARGA         { get; set; } = null!;
        public DbSet<InspectorAduana>            INSPECTORES_ADUANAS   { get; set; } = null!;
        public DbSet<BodegaCarga>                BODEGAS_CARGA         { get; set; } = null!;
        public DbSet<CargaUbicacion>             CARGA_UBICACION       { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 20: Mantenimiento Predictivo
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<PiezaReemplazo>             PIEZAS_REEMPLAZO      { get; set; } = null!;
        public DbSet<OrdenMantenimientoPredictivo> ORDENES_MANTENIMIENTO_PRED { get; set; } = null!;
        public DbSet<ChecklistMantenimiento>     CHECKLISTS_MANTENIMIENTO { get; set; } = null!;
        public DbSet<ChecklistEjecucion>         CHECKLIST_EJECUCION   { get; set; } = null!;
        public DbSet<TareaEjecutada>             TAREAS_EJECUTADAS     { get; set; } = null!;
        public DbSet<ProveedorRepuesto>          PROVEEDORES_REPUESTOS { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 21: Tiempo Real
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<AsignacionPistasTiempoReal> AsignacionesPistas    { get; set; } = null!;
        public DbSet<RetrasosTiempoReal>         RetrasosTiempoReal    { get; set; } = null!;
        public DbSet<SlotsAeropuerto>            SlotsAeropuerto       { get; set; } = null!;
        public DbSet<CapacidadTerminalTiempoReal> CapacidadTerminal    { get; set; } = null!;
        public DbSet<CondicionesPistaTiempoReal>  CondicionesPista     { get; set; } = null!;
        public DbSet<PosicionesRadar>            PosicionesRadar       { get; set; } = null!;
        public DbSet<TorreControlComunicaciones> TorreControl          { get; set; } = null!;
        public DbSet<HistorialFlujoTrafico>      HistorialFlujo        { get; set; } = null!;
        public DbSet<PrediccionDemanda>          PrediccionDemanda     { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 22: Combustible
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<CargasCombustible>          CargasCombustible     { get; set; } = null!;
        public DbSet<ControlCalidadCombustible>  ControlCalidadCombustible { get; set; } = null!;
        public DbSet<FacturacionCombustible>     FacturacionCombustible { get; set; } = null!;
        public DbSet<HistorialPreciosCombustible> HistorialPreciosCombustible { get; set; } = null!;
        public DbSet<InventarioCombustible>      InventarioCombustible { get; set; } = null!;
        public DbSet<ProveedoresCombustible>     ProveedoresCombustible { get; set; } = null!;
        public DbSet<SurtidoresCombustible>      SurtidoresCombustible { get; set; } = null!;
        public DbSet<TanquesCombustible>         TanquesCombustible    { get; set; } = null!;
        public DbSet<PedidosCombustible>         PedidosCombustible    { get; set; } = null!;
        public DbSet<RecepcionesCombustible>     RecepcionesCombustible { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 23: Ambiental
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<MonitoreoAire>              MonitoreoAire         { get; set; } = null!;
        public DbSet<MonitoreoRuido>             MonitoreoRuido        { get; set; } = null!;
        public DbSet<HuellaCarbonoVuelo>         HuellaCarbonoVuelo    { get; set; } = null!;
        public DbSet<GestionResiduos>            GestionResiduos       { get; set; } = null!;
        public DbSet<IndicadoresDesempenoAmbiental> IndicadoresDesempenoAmbiental { get; set; } = null!;
        public DbSet<ProgramasCompensacionAmbiental> ProgramasCompensacionAmbiental { get; set; } = null!;
        public DbSet<CertificacionesAmbientalesAeropuerto> CertificacionesAmbientales { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 24: Seguridad Informática
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<AuditoriasSeguridad>        AuditoriasSeguridad   { get; set; } = null!;
        public DbSet<AuditoriasInternas>         AuditoriasInternas    { get; set; } = null!;
        public DbSet<AuditoriasInternacionales>  AuditoriasInternacionales { get; set; } = null!;
        public DbSet<IncidentesSeguridadInformatica> IncidentesSeguridadInformatica { get; set; } = null!;
        public DbSet<PoliticasSeguridad>         PoliticasSeguridad    { get; set; } = null!;
        public DbSet<LogsAccesoSistema>          LogsAcceso            { get; set; } = null!;
        public DbSet<TokensAutenticacion>        Tokens                { get; set; } = null!;
        public DbSet<BitacoraCambiosDb>          BitacoraCambios       { get; set; } = null!;
        public DbSet<RespaldosSistema>           Respaldos             { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 25: Marketing
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<CampanasMarketing>          CampanasMarketing     { get; set; } = null!;
        public DbSet<OfertasPersonalizadas>      OfertasPersonalizadas { get; set; } = null!;
        public DbSet<CanjesPuntos>               CanjesPuntos          { get; set; } = null!;
        public DbSet<NewsletterSuscripciones>    NewsletterSuscripciones { get; set; } = null!;
        public DbSet<EncuestasPostVuelo>         EncuestasPostVuelo    { get; set; } = null!;
        public DbSet<PasajerosSegmentos>         PasajerosSegmentos    { get; set; } = null!;
        public DbSet<ReaccionesPromociones>      ReaccionesPromociones { get; set; } = null!;
        public DbSet<NewsletterEnvios>           NewsletterEnvios      { get; set; } = null!;
        public DbSet<AnalisisComportamiento>     AnalisisComportamiento { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 26: Documental
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<NormativasAplicables>       NormativasAplicables  { get; set; } = null!;
        public DbSet<LicenciasOperativasAeropuerto> LicenciasOperativas { get; set; } = null!;
        public DbSet<CumplimientoNormativo>      CumplimientoNormativo { get; set; } = null!;
        public DbSet<Contratos>                  Contratos             { get; set; } = null!;
        public DbSet<ClausulasContrato>          ClausulasContrato     { get; set; } = null!;
        public DbSet<NotificacionesLegales>      NotificacionesLegales { get; set; } = null!;
        public DbSet<DocumentosImportantes>      DocumentosImportantes { get; set; } = null!;
        public DbSet<DocumentosRequeridosOperacion> DocumentosRequeridos { get; set; } = null!;
        public DbSet<CertificacionesInternacionales> CertificacionesInternacionales { get; set; } = null!;
        public DbSet<ProyectosEficienciaEnergetica> ProyectosEficiencia { get; set; } = null!;
        public DbSet<RevisionesDocumentos>       RevisionesDocumentos  { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 27: Transporte Terrestre
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<AsignacionServiciosTransporte> AsignacionesServiciosTransporte { get; set; } = null!;
        public DbSet<AsignacionVehiculosRutas>   AsignacionesVehiculosRutas { get; set; } = null!;
        public DbSet<ChoferesTransporte>         ChoferesTransporte    { get; set; } = null!;
        public DbSet<EmpresasTransporte>         EmpresasTransporte    { get; set; } = null!;
        public DbSet<RutasTransporteTerrestre>   RutasTransporte       { get; set; } = null!;
        public DbSet<ReservasTransporteTerrestre> ReservasTransporte   { get; set; } = null!;
        public DbSet<TarifasTransporteTerrestre> TarifasTransporte     { get; set; } = null!;
        public DbSet<VehiculosTransporte>        VehiculosTransporte   { get; set; } = null!;
        public DbSet<QuejasTransporteTerrestre>  QuejasTransporte      { get; set; } = null!;
        public DbSet<ConveniosHotelesTransporte> ConveniosHoteles      { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 28: Emergencias
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<ActivacionesEmergencia>     ActivacionesEmergencia { get; set; } = null!;
        public DbSet<EntrenamientosEmergencia>   EntrenamientosEmergencia { get; set; } = null!;
        public DbSet<EquiposEmergencia>          EquiposEmergencia     { get; set; } = null!;
        public DbSet<EvaluacionesPostEmergencia> EvaluacionesPostEmergencia { get; set; } = null!;
        public DbSet<PersonalEmergencia>         PersonalEmergencia    { get; set; } = null!;
        public DbSet<PlanesEmergencia>           PlanesEmergencia      { get; set; } = null!;
        public DbSet<PuntosEncuentro>            PuntosEncuentro       { get; set; } = null!;
        public DbSet<RecursosEmergencia>         RecursosEmergencia    { get; set; } = null!;
        public DbSet<Simulacros>                 Simulacros            { get; set; } = null!;
        public DbSet<ComunicacionesEmergencia>   ComunicacionesEmergencia { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Módulo 29: OACI
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<NotificacionesOaci>         NotificacionesOaci    { get; set; } = null!;
        public DbSet<ReportesOaci>               ReportesOaci          { get; set; } = null!;
        public DbSet<EstandaresInternacionales>  EstandaresInternacionales { get; set; } = null!;
        public DbSet<CodigosOaciPaises>          CodigosOaci           { get; set; } = null!;
        public DbSet<CompensacionesVuelo>        CompensacionesVuelo   { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // Sistema de usuarios y otros
        // ══════════════════════════════════════════════════════════════════════
        public DbSet<UsuariosSistema>            UsuariosSistema       { get; set; } = null!;
        public DbSet<RolesSistema>               RolesSistema          { get; set; } = null!;
        public DbSet<UsuariosRoles>              UsuariosRoles         { get; set; } = null!;
        public DbSet<ModulosSistema>             ModulosSistema        { get; set; } = null!;
        public DbSet<RolesPermisosModulos>       RolesPermisosModulos  { get; set; } = null!;
        public DbSet<SegmentosClientes>          SegmentosClientes     { get; set; } = null!;
        public DbSet<SeriesVueloAsignadas>       SeriesVueloAsignadas  { get; set; } = null!;
        public DbSet<AlertasOperacionales>       AlertasOperacionales  { get; set; } = null!;

        // ══════════════════════════════════════════════════════════════════════
        // OnModelCreating
        // ══════════════════════════════════════════════════════════════════════
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clave compuesta para EmpleadoCapacitacion (Módulo 15)
            modelBuilder.Entity<EmpleadoCapacitacion>()
                .HasKey(ec => new { ec.IdEmpleado, ec.IdCapacitacion });

            base.OnModelCreating(modelBuilder);
        }
    }
}