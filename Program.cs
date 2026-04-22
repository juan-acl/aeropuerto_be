using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Services;
using Aeropuerto.Backend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(o => { o.JsonSerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── Oracle DB ─────────────────────────────────────────────────────────────────
builder.Services.AddDbContext<DBContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// ── CORS: allow React/Expo dev + any local IP (for mobile testing) ────────────
const string MiAppReact = "AllowReactApp";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MiAppReact, policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 1 ─ Infraestructura
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IAeropuertoService, AeropuertoService>();
builder.Services.AddScoped<IPistaAterrizajeService, PistaAterrizajeService>();
builder.Services.AddScoped<IPuertaEmbarqueService, PuertaEmbarqueService>();
builder.Services.AddScoped<ITerminalAeropuertoService, TerminalAeropuertoService>();
builder.Services.AddScoped<IHangarService, HangarService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 2 ─ Flota
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IFabricanteAvionService, FabricanteAvionService>();
builder.Services.AddScoped<IModeloAvionService, ModeloAvionService>();
builder.Services.AddScoped<IMotorAvionService, MotorAvionService>();
builder.Services.AddScoped<IAvionService, AvionService>();
builder.Services.AddScoped<IMantenimientoAvionService, MantenimientoAvionService>();
builder.Services.AddScoped<IFranquiciaEquipajeService, FranquiciaEquipajeService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 3 ─ Aerolíneas
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IAerolineaService, AerolineaService>();
builder.Services.AddScoped<IAlianzaAerolineaService, AlianzaAerolineaService>();
builder.Services.AddScoped<ITipoAerolineaService, TipoAerolineaService>();
builder.Services.AddScoped<ITipoAeropuertoService, TipoAeropuertoService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 4 ─ Programación de vuelos
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<ITemporadaVueloService, TemporadaVueloService>();
builder.Services.AddScoped<IDiasOperacionService, DiasOperacionService>();
builder.Services.AddScoped<ISerieVueloService, SerieVueloService>();
builder.Services.AddScoped<IProgramaVueloService, ProgramaVueloService>();
builder.Services.AddScoped<IFrecuenciaVueloService, FrecuenciaVueloService>();
builder.Services.AddScoped<ITarifaVueloService, TarifaVueloService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 5 ─ Operaciones de vuelo
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<ICondicionMeteorologicaService, CondicionMeteorologicaService>();
builder.Services.AddScoped<IIncidenteVueloService, IncidenteVueloService>();
builder.Services.AddScoped<IRetrasoVueloService, RetrasoVueloService>();
builder.Services.AddScoped<ITripulacionVueloService, TripulacionVueloService>();
builder.Services.AddScoped<ICompensacionVueloService, CompensacionVueloService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 6 ─ Tripulación
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<ITripulacionService, TripulacionService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 7 ─ Pasajeros
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IPasajeroService, PasajeroService>();
builder.Services.AddScoped<IPasajeroHistorialMedicoService, PasajeroHistorialMedicoService>();
builder.Services.AddScoped<IPasajeroPreferenciaService, PasajeroPreferenciaService>();
builder.Services.AddScoped<IPasajerosDocumentosService, PasajerosDocumentosService>();
builder.Services.AddScoped<IPasajerosRedesSocialesService, PasajerosRedesSocialesService>();
builder.Services.AddScoped<IPerfilViajeroService, PerfilViajeroService>();
builder.Services.AddScoped<IPreferenciaIdiomaService, PreferenciaIdiomaService>();
builder.Services.AddScoped<IProhibicionesVueloService, ProhibicionesVueloService>();
builder.Services.AddScoped<IAcompanantesViajeService, AcompanantesViajeService>();
builder.Services.AddScoped<IGruposViajeService, GruposViajeService>();
builder.Services.AddScoped<IGruposPasajerosService, GruposPasajerosService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 8 ─ Reservas
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IReservasService, ReservasService>();
builder.Services.AddScoped<IReservasPagosService, ReservasPagosService>();
builder.Services.AddScoped<IReservasPromocionesService, ReservasPromocionesService>();
builder.Services.AddScoped<IHistorialReservasService, HistorialReservasService>();
builder.Services.AddScoped<IMetodosPagoService, MetodosPagoService>();
builder.Services.AddScoped<IFacturasService, FacturasService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 9 ─ Check-in y embarque
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<ICheckinDigitalService, CheckinDigitalService>();
builder.Services.AddScoped<IPasesAbordajeService, PasesAbordajeService>();
builder.Services.AddScoped<IControlAbordajeService, ControlAbordajeService>();
builder.Services.AddScoped<IGruposEmbarqueService, GruposEmbarqueService>();
builder.Services.AddScoped<IPuertasEmbarqueAsignacionService, PuertasEmbarqueAsignacionService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 10-11 ─ Seguridad e incidentes
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IIncidentesService, IncidentesService>();
builder.Services.AddScoped<IIncidentesEvidenciaService, IncidentesEvidenciaService>();
builder.Services.AddScoped<IIncidentesInvolucradosService, IncidentesInvolucradosService>();
builder.Services.AddScoped<IIncidentesMedidasService, IncidentesMedidasService>();
builder.Services.AddScoped<ITiposIncidentesService, TiposIncidentesService>();
builder.Services.AddScoped<IAlertasSeguridadService, AlertasSeguridadService>();
builder.Services.AddScoped<ISeguridadControlesService, SeguridadControlesService>();
builder.Services.AddScoped<IVisitasSeguridadService, VisitasSeguridadService>();
builder.Services.AddScoped<IAccesosAreasRestringidasService, AccesosAreasRestringidasService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 12 ─ Objetos Perdidos
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IObjetosPerdidosService, ObjetosPerdidosService>();
builder.Services.AddScoped<IObjetosDecomisadosService, ObjetosDecomisadosService>();
builder.Services.AddScoped<IObjetosEntregadosService, ObjetosEntregadosService>();
builder.Services.AddScoped<IObjetosSeguimientoService, ObjetosSeguimientoService>();
builder.Services.AddScoped<ICategoriasObjetosService, CategoriasObjetosService>();
builder.Services.AddScoped<IReclamacionesObjetosService, ReclamacionesObjetosService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 13 ─ Comercial
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IConcesionesComercialesService, ConcesionesComercialesService>();
builder.Services.AddScoped<ITiendasProductosService, TiendasProductosService>();
builder.Services.AddScoped<ITiendasVentasService, TiendasVentasService>();
builder.Services.AddScoped<IVentasDetalleService, VentasDetalleService>();
builder.Services.AddScoped<IRestaurantesMenusService, RestaurantesMenusService>();
builder.Services.AddScoped<ISalonesVipService, SalonesVipService>();
builder.Services.AddScoped<ISalonesAccesosService, SalonesAccesosService>();
builder.Services.AddScoped<IEstacionamientoService, EstacionamientoService>();
builder.Services.AddScoped<IEstacionamientoRegistroService, EstacionamientoRegistroService>();
builder.Services.AddScoped<IPublicidadService, PublicidadService>();
builder.Services.AddScoped<IPromocionesService, PromocionesService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 14 ─ Servicios al pasajero
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<ISolicitudesEspecialesService, SolicitudesEspecialesService>();
builder.Services.AddScoped<IAtencionEspecialService, AtencionEspecialService>();
builder.Services.AddScoped<IEquipajeEspecialService, EquipajeEspecialService>();
builder.Services.AddScoped<IEmergenciasMedicasService, EmergenciasMedicasService>();
builder.Services.AddScoped<IEncuestasSatisfaccionService, EncuestasSatisfaccionService>();
builder.Services.AddScoped<IQuejasSugerenciasService, QuejasSugerenciasService>();
builder.Services.AddScoped<ITransporteTerrestreService, TransporteTerrestreService>();
builder.Services.AddScoped<IHotelesCercanosService, HotelesCercanosService>();
builder.Services.AddScoped<IProgramaLealtadService, ProgramaLealtadService>();
builder.Services.AddScoped<IBotiquinesVueloService, BotiquinesVueloService>();
builder.Services.AddScoped<IHistorialComunicacionService, HistorialComunicacionService>();
builder.Services.AddScoped<ITarifasEspecialesService, TarifasEspecialesService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 15 ─ RRHH
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IPuestoService, PuestoService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IVacacionesService, VacacionesService>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();
builder.Services.AddScoped<ICapacitacionService, CapacitacionService>();
builder.Services.AddScoped<IEmpCapaService, EmpCapaService>();
builder.Services.AddScoped<IUniformeService, UniformeService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 16 ─ Finanzas y Contabilidad
// ═══════════════════════════════════════════════════════════════════════════════
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

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 17-18 ─ Pasajeros menores y grupos especiales
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IPasajeroMenorService, PasajeroMenorService>();
builder.Services.AddScoped<IAutorizacionMenorService, AutorizacionMenorService>();
builder.Services.AddScoped<IMenorNoAcompanadoService, MenorNoAcompanadoService>();
builder.Services.AddScoped<IPasajeroMascotaService, PasajeroMascotaService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 19 ─ Gestión de carga
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IEnvioCargaService, EnvioCargaService>();
builder.Services.AddScoped<IManifiestoCargaService, ManifiestoCargaService>();
builder.Services.AddScoped<IManifiestoDetalleService, ManifiestoDetalleService>();
builder.Services.AddScoped<ISeguimientoCargaService, SeguimientoCargaService>();
builder.Services.AddScoped<IAduanaCargaService, AduanaCargaService>();
builder.Services.AddScoped<IInspectorAduanaService, InspectorAduanaService>();
builder.Services.AddScoped<IBodegaCargaService, BodegaCargaService>();
builder.Services.AddScoped<ICargaUbicacionService, CargaUbicacionService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 20 ─ Mantenimiento predictivo
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IPiezaReemplazoService, PiezaReemplazoService>();
builder.Services.AddScoped<IOrdenMantenimientoPredictivoService, OrdenMantenimientoPredictivoService>();
builder.Services.AddScoped<IChecklistMantenimientoService, ChecklistMantenimientoService>();
builder.Services.AddScoped<IChecklistEjecucionService, ChecklistEjecucionService>();
builder.Services.AddScoped<ITareaEjecutadaService, TareaEjecutadaService>();
builder.Services.AddScoped<IProveedorRepuestoService, ProveedorRepuestoService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 21 ─ Tiempo Real
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IAsignacionPistasTiempoRealService, AsignacionPistasTiempoRealService>();
builder.Services.AddScoped<IRetrasosTiempoRealService, RetrasosTiempoRealService>();
builder.Services.AddScoped<ISlotsAeropuertoService, SlotsAeropuertoService>();
builder.Services.AddScoped<ICapacidadTerminalTiempoRealService, CapacidadTerminalTiempoRealService>();
builder.Services.AddScoped<ICondicionPistaTiempoRealService, CondicionPistaTiempoRealService>();
builder.Services.AddScoped<IPosicionRadarService, PosicionRadarService>();
builder.Services.AddScoped<ITorreControlComunicacionService, TorreControlComunicacionService>();
builder.Services.AddScoped<IHistorialFlujoTraficoService, HistorialFlujoTraficoService>();
builder.Services.AddScoped<IPrediccionDemandaService, PrediccionDemandaService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 22 ─ Combustible
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<ICargaCombustibleService, CargaCombustibleService>();
builder.Services.AddScoped<IControlCalidadCombustibleService, ControlCalidadCombustibleService>();
builder.Services.AddScoped<IFacturacionCombustibleService, FacturacionCombustibleService>();
builder.Services.AddScoped<IHistorialPreciosCombustibleService, HistorialPreciosCombustibleService>();
builder.Services.AddScoped<IInventarioCombustibleService, InventarioCombustibleService>();
builder.Services.AddScoped<IProveedorCombustibleService, ProveedorCombustibleService>();
builder.Services.AddScoped<ISurtidorCombustibleService, SurtidorCombustibleService>();
builder.Services.AddScoped<ITanqueCombustibleService,                       TanqueCombustibleService>();
builder.Services.AddScoped<IPedidoCombustibleService, PedidoCombustibleService>();
builder.Services.AddScoped<IRecepcionCombustibleService, RecepcionCombustibleService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 23 ─ Ambiental
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IMonitoreoAireService, MonitoreoAireService>();
builder.Services.AddScoped<IMonitoreoRuidoService, MonitoreoRuidoService>();
builder.Services.AddScoped<IHuellaCarbonoVueloService, HuellaCarbonoVueloService>();
builder.Services.AddScoped<IGestionResiduosService, GestionResiduosService>();
builder.Services.AddScoped<IIndicadoresDesempenoAmbientalService, IndicadoresDesempenoAmbientalService>();
builder.Services.AddScoped<IProgramaCompensacionService, ProgramaCompensacionService>();
builder.Services.AddScoped<ICertificacionAmbientalService, CertificacionAmbientalService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 24 ─ Seguridad Informática
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IAuditoriaSeguridadService, AuditoriaSeguridadService>();
builder.Services.AddScoped<IAuditoriaInternaService, AuditoriaInternaService>();
builder.Services.AddScoped<IAuditoriaInternacionalService, AuditoriaInternacionalService>();
builder.Services.AddScoped<IIncidenteSeguridadService, IncidenteSeguridadService>();
builder.Services.AddScoped<IPoliticaSeguridadService, PoliticaSeguridadService>();
builder.Services.AddScoped<ILogAccesoSistemaService, LogAccesoSistemaService>();
builder.Services.AddScoped<ITokenAutenticacionService, TokenAutenticacionService>();
builder.Services.AddScoped<IBitacoraCambiosDbService, BitacoraCambiosDbService>();
builder.Services.AddScoped<IRespaldoSistemaService, RespaldoSistemaService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 25 ─ Marketing
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<ICampanaMarketingService, CampanaMarketingService>();
builder.Services.AddScoped<IOfertaPersonalizadaService, OfertaPersonalizadaService>();
builder.Services.AddScoped<ICanjePuntoService, CanjePuntoService>();
builder.Services.AddScoped<INewsletterSuscripcionService, NewsletterSuscripcionService>();
builder.Services.AddScoped<IEncuestaPostVueloService, EncuestaPostVueloService>();
builder.Services.AddScoped<IPasajeroSegmentoService, PasajeroSegmentoService>();
builder.Services.AddScoped<IReaccionPromocionService, ReaccionPromocionService>();
builder.Services.AddScoped<INewsletterEnvioService, NewsletterEnvioService>();
builder.Services.AddScoped<IAnalisisComportamientoService, AnalisisComportamientoService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 26 ─ Documental
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<INormativaAplicableService, NormativaAplicableService>();
builder.Services.AddScoped<ILicenciaOperativaService, LicenciaOperativaService>();
builder.Services.AddScoped<ICumplimientoNormativoService, CumplimientoNormativoService>();
builder.Services.AddScoped<IContratoService, ContratoService>();
builder.Services.AddScoped<IClausulaContratoService, ClausulaContratoService>();
builder.Services.AddScoped<INotificacionLegalService, NotificacionLegalService>();
builder.Services.AddScoped<IDocumentoImportanteService, DocumentoImportanteService>();
builder.Services.AddScoped<IDocumentoRequeridoService, DocumentoRequeridoService>();
builder.Services.AddScoped<ICertificacionInternacionalService, CertificacionInternacionalService>();
builder.Services.AddScoped<IProyectoEficienciaService, ProyectoEficienciaService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 27 ─ Transporte Terrestre
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IAsignacionServicioService, AsignacionServicioService>();
builder.Services.AddScoped<IAsignacionVehiculoRutaService, AsignacionVehiculoRutaService>();
builder.Services.AddScoped<IChoferTransporteService, ChoferTransporteService>();
builder.Services.AddScoped<IEmpresaTransporteService, EmpresaTransporteService>();
builder.Services.AddScoped<IRutaTransporteService, RutaTransporteService>();
builder.Services.AddScoped<IReservaTransporteService, ReservaTransporteService>();
builder.Services.AddScoped<ITarifaTransporteTerrestreService, TarifaTransporteTerrestreService>();
builder.Services.AddScoped<IVehiculoTransporteService, VehiculoTransporteService>();
builder.Services.AddScoped<IQuejaTransporteService, QuejaTransporteService>();
builder.Services.AddScoped<IConvenioHotelService, ConvenioHotelService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 28 ─ Emergencias
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IActivacionEmergenciaService, ActivacionEmergenciaService>();
builder.Services.AddScoped<IEntrenamientoEmergenciaService, EntrenamientoEmergenciaService>();
builder.Services.AddScoped<IEquipoEmergenciaService, EquipoEmergenciaService>();
builder.Services.AddScoped<IEvaluacionPostService, EvaluacionPostService>();
builder.Services.AddScoped<IPersonalEmergenciaService, PersonalEmergenciaService>();
builder.Services.AddScoped<IPlanEmergenciaService, PlanEmergenciaService>();
builder.Services.AddScoped<IPuntoEncuentroService, PuntoEncuentroService>();
builder.Services.AddScoped<IRecursoEmergenciaService, RecursoEmergenciaService>();
builder.Services.AddScoped<ISimulacroService, SimulacroService>();

// ═══════════════════════════════════════════════════════════════════════════════
// MÓDULO 29 ─ OACI
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<INotificacionOaciService, NotificacionOaciService>();
builder.Services.AddScoped<IReporteOaciService, ReporteOaciService>();
builder.Services.AddScoped<IEstandarInternacionalService, EstandarInternacionalService>();
builder.Services.AddScoped<ICodigoOaciPaisService, CodigoOaciPaisService>();
builder.Services.AddScoped<IRevisionDocumentoService, RevisionDocumentoService>();

// ═══════════════════════════════════════════════════════════════════════════════
// Sistema de usuarios
// ═══════════════════════════════════════════════════════════════════════════════
builder.Services.AddScoped<IUsuarioSistemaService, UsuarioSistemaService>();
builder.Services.AddScoped<IRolSistemaService, RolSistemaService>();
builder.Services.AddScoped<IUsuarioRolService, UsuarioRolService>();
builder.Services.AddScoped<IModuloSistemaService, ModuloSistemaService>();
builder.Services.AddScoped<IRolPermisoModuloService, RolPermisoModuloService>();
builder.Services.AddScoped<ISegmentoClienteService, SegmentoClienteService>();

// ═══════════════════════════════════════════════════════════════════════════════
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();  // Deshabilitado: causa fallo de CORS preflight
app.UseCors(MiAppReact);
app.UseAuthorization();
app.MapControllers();
app.Run();

