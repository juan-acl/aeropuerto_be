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

builder.Services.AddDbContext<ReplicaDBContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb_Replica")));

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
// SP-backed CRUD Services (Auto-generated from Oracle Stored Procedures)
// ═══════════════════════════════════════════════════════════════════════════════

// ── Módulo 1: Infraestructura ──
builder.Services.AddScoped<IAeropuertoService, AeropuertoService>();
builder.Services.AddScoped<IPistaAterrizajeService, PistaAterrizajeService>();
builder.Services.AddScoped<IPuertaEmbarqueService, PuertaEmbarqueService>();
builder.Services.AddScoped<ITerminalAeropuertoService, TerminalAeropuertoService>();
builder.Services.AddScoped<IHangarService, HangarService>();

// ── Módulo 2: Flota ──
builder.Services.AddScoped<IFabricanteAvionService, FabricanteAvionService>();
builder.Services.AddScoped<IModeloAvionService, ModeloAvionService>();
builder.Services.AddScoped<IMotorAvionService, MotorAvionService>();
builder.Services.AddScoped<IAvionService, AvionService>();
builder.Services.AddScoped<IMantenimientoAvionService, MantenimientoAvionService>();
builder.Services.AddScoped<IFranquiciaEquipajeService, FranquiciaEquipajeService>();

// ── Módulo 3: Aerolíneas ──
builder.Services.AddScoped<IAerolineaService, AerolineaService>();
builder.Services.AddScoped<IAlianzaAerolineaService, AlianzaAerolineaService>();
builder.Services.AddScoped<ITipoAerolineaService, TipoAerolineaService>();
builder.Services.AddScoped<ITipoAeropuertoService, TipoAeropuertoService>();

// ── Módulo 4: Programación de vuelos ──
builder.Services.AddScoped<ITemporadaVueloService, TemporadaVueloService>();
// builder.Services.AddScoped<IDiasOperacionService, DiasOperacionService>(); // TODO: add DIAS_OPERACION DbSet
builder.Services.AddScoped<ISeriesVueloAsignadasService, SeriesVueloAsignadasService>();
builder.Services.AddScoped<IProgramaVueloService, ProgramaVueloService>();
builder.Services.AddScoped<IFrecuenciaVueloService, FrecuenciaVueloService>();
builder.Services.AddScoped<ITarifaVueloService, TarifaVueloService>();

// ── Módulo 5: Operaciones de vuelo ──
builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<ICondicionMeteorologicaService, CondicionMeteorologicaService>();
builder.Services.AddScoped<IIncidenteVueloService, IncidenteVueloService>();
builder.Services.AddScoped<IRetrasoVueloService, RetrasoVueloService>();
builder.Services.AddScoped<ITripulacionVueloService, TripulacionVueloService>();
builder.Services.AddScoped<ICompensacionesVueloService, CompensacionesVueloService>();
// builder.Services.AddScoped<IAduanaCargaService, AduanaCargaService>(); // TODO: add ADUANA_CARGA DbSet
builder.Services.AddScoped<IEscalasTecnicasService, EscalasTecnicasService>();

// ── Módulo 6: Tripulación ──
builder.Services.AddScoped<ITripulacionService, TripulacionService>();

// ── Módulo 7: Pasajeros ──
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

// ── Módulo 8: Reservas ──
builder.Services.AddScoped<IReservasService, ReservasService>();
builder.Services.AddScoped<IReservasPagosService, ReservasPagosService>();
builder.Services.AddScoped<IReservasPromocionesService, ReservasPromocionesService>();
builder.Services.AddScoped<IHistorialReservasService, HistorialReservasService>();
builder.Services.AddScoped<IMetodosPagoService, MetodosPagoService>();
builder.Services.AddScoped<IFacturasService, FacturasService>();

// ── Módulo 9: Check-in y Embarque ──
builder.Services.AddScoped<ICheckinDigitalService, CheckinDigitalService>();
builder.Services.AddScoped<IPasesAbordajeService, PasesAbordajeService>();
builder.Services.AddScoped<IControlAbordajeService, ControlAbordajeService>();
builder.Services.AddScoped<IGruposEmbarqueService, GruposEmbarqueService>();
builder.Services.AddScoped<IPuertasEmbarqueAsignacionService, PuertasEmbarqueAsignacionService>();

// ── Módulo 10-11: Seguridad e Incidentes ──
builder.Services.AddScoped<IIncidentesService, IncidentesService>();
builder.Services.AddScoped<IIncidentesEvidenciaService, IncidentesEvidenciaService>();
builder.Services.AddScoped<IIncidentesInvolucradosService, IncidentesInvolucradosService>();
builder.Services.AddScoped<IIncidentesMedidasService, IncidentesMedidasService>();
builder.Services.AddScoped<ITiposIncidentesService, TiposIncidentesService>();
builder.Services.AddScoped<IAlertasSeguridadService, AlertasSeguridadService>();
builder.Services.AddScoped<ISeguridadControlesService, SeguridadControlesService>();
builder.Services.AddScoped<IVisitasSeguridadService, VisitasSeguridadService>();
builder.Services.AddScoped<IAccesosAreasRestringidasService, AccesosAreasRestringidasService>();

// ── Módulo 12: Objetos Perdidos ──
builder.Services.AddScoped<IObjetosPerdidosService, ObjetosPerdidosService>();
builder.Services.AddScoped<IObjetosDecomisadosService, ObjetosDecomisadosService>();
builder.Services.AddScoped<IObjetosEntregadosService, ObjetosEntregadosService>();
builder.Services.AddScoped<IObjetosSeguimientoService, ObjetosSeguimientoService>();
builder.Services.AddScoped<ICategoriasObjetosService, CategoriasObjetosService>();
builder.Services.AddScoped<IReclamacionesObjetosService, ReclamacionesObjetosService>();

// ── Módulo 13: Comercial ──
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

// ── Módulo 14: Servicios al Pasajero ──
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

// ── Módulo 15: RRHH ──
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IPuestoTrabajoService, PuestoTrabajoService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IVacacionesPermisoService, VacacionesPermisoService>();
builder.Services.AddScoped<IEvaluacionDesempenoService, EvaluacionDesempenoService>();
builder.Services.AddScoped<ICapacitacionService, CapacitacionService>();
builder.Services.AddScoped<IUniformeEquipamientoService, UniformeEquipamientoService>();

// ── Módulo 16: Finanzas y Contabilidad ──
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();
builder.Services.AddScoped<IIngresoService, IngresoService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<IOrdenDetalleService, OrdenDetalleService>();
builder.Services.AddScoped<ITasaAeroportuariaService, TasaAeroportuariaService>();
builder.Services.AddScoped<ITasaAplicadaService, TasaAplicadaService>();
builder.Services.AddScoped<ICuentaBancariaService, CuentaBancariaService>();
builder.Services.AddScoped<IMovimientoBancarioService, MovimientoBancarioService>();

// ── Módulo 17-18: Pasajeros Menores y Grupos Especiales ──
builder.Services.AddScoped<IPasajeroMenorService, PasajeroMenorService>();
builder.Services.AddScoped<IAutorizacionMenorService, AutorizacionMenorService>();
builder.Services.AddScoped<IMenorNoAcompanadoService, MenorNoAcompanadoService>();
builder.Services.AddScoped<IPasajeroMascotaService, PasajeroMascotaService>();

// ── Módulo 19: Gestión de Carga ──
builder.Services.AddScoped<IEnvioCargaService, EnvioCargaService>();
builder.Services.AddScoped<IManifiestoCargaService, ManifiestoCargaService>();
builder.Services.AddScoped<IManifiestoDetalleService, ManifiestoDetalleService>();
builder.Services.AddScoped<ISeguimientoCargaService, SeguimientoCargaService>();
// AduanaCarga registered above
builder.Services.AddScoped<IInspectorAduanaService, InspectorAduanaService>();
builder.Services.AddScoped<IBodegaCargaService, BodegaCargaService>();
builder.Services.AddScoped<ICargaUbicacionService, CargaUbicacionService>();

// ── Módulo 20: Mantenimiento Predictivo ──
builder.Services.AddScoped<IPiezaReemplazoService, PiezaReemplazoService>();
builder.Services.AddScoped<IOrdenMantenimientoPredictivoService, OrdenMantenimientoPredictivoService>();
builder.Services.AddScoped<IChecklistMantenimientoService, ChecklistMantenimientoService>();
builder.Services.AddScoped<IChecklistEjecucionService, ChecklistEjecucionService>();
builder.Services.AddScoped<ITareaEjecutadaService, TareaEjecutadaService>();
builder.Services.AddScoped<IProveedorRepuestoService, ProveedorRepuestoService>();

// ── Módulo 21: Tiempo Real ──
builder.Services.AddScoped<IAsignacionPistasTiempoRealService, AsignacionPistasTiempoRealService>();
builder.Services.AddScoped<IRetrasosTiempoRealService, RetrasosTiempoRealService>();
builder.Services.AddScoped<ISlotsAeropuertoService, SlotsAeropuertoService>();
builder.Services.AddScoped<ICapacidadTerminalTiempoRealService, CapacidadTerminalTiempoRealService>();
builder.Services.AddScoped<ICondicionesPistaTiempoRealService, CondicionesPistaTiempoRealService>();
builder.Services.AddScoped<IPosicionesRadarService, PosicionesRadarService>();
builder.Services.AddScoped<ITorreControlComunicacionesService, TorreControlComunicacionesService>();
builder.Services.AddScoped<IHistorialFlujoTraficoService, HistorialFlujoTraficoService>();
builder.Services.AddScoped<IPrediccionDemandaService, PrediccionDemandaService>();

// ── Módulo 22: Combustible ──
builder.Services.AddScoped<ICargasCombustibleService, CargasCombustibleService>();
builder.Services.AddScoped<IControlCalidadCombustibleService, ControlCalidadCombustibleService>();
builder.Services.AddScoped<IFacturacionCombustibleService, FacturacionCombustibleService>();
builder.Services.AddScoped<IHistorialPreciosCombustibleService, HistorialPreciosCombustibleService>();
builder.Services.AddScoped<IInventarioCombustibleService, InventarioCombustibleService>();
builder.Services.AddScoped<IProveedoresCombustibleService, ProveedoresCombustibleService>();
builder.Services.AddScoped<ISurtidoresCombustibleService, SurtidoresCombustibleService>();
builder.Services.AddScoped<ITanquesCombustibleService, TanquesCombustibleService>();
builder.Services.AddScoped<IPedidosCombustibleService, PedidosCombustibleService>();
builder.Services.AddScoped<IRecepcionesCombustibleService, RecepcionesCombustibleService>();

// ── Módulo 23: Ambiental ──
builder.Services.AddScoped<IMonitoreoAireService, MonitoreoAireService>();
builder.Services.AddScoped<IMonitoreoRuidoService, MonitoreoRuidoService>();
builder.Services.AddScoped<IHuellaCarbonoVueloService, HuellaCarbonoVueloService>();
builder.Services.AddScoped<IGestionResiduosService, GestionResiduosService>();
builder.Services.AddScoped<IIndicadoresDesempenoAmbientalService, IndicadoresDesempenoAmbientalService>();
builder.Services.AddScoped<IProgramasCompensacionAmbientalService, ProgramasCompensacionAmbientalService>();
builder.Services.AddScoped<ICertificacionesAmbientalesAeropuertoService, CertificacionesAmbientalesAeropuertoService>();

// ── Módulo 24: Seguridad Informática ──
builder.Services.AddScoped<IAuditoriasSeguridadService, AuditoriasSeguridadService>();
builder.Services.AddScoped<IAuditoriasInternasService, AuditoriasInternasService>();
builder.Services.AddScoped<IAuditoriasInternacionalesService, AuditoriasInternacionalesService>();
builder.Services.AddScoped<IIncidentesSeguridadInformaticaService, IncidentesSeguridadInformaticaService>();
builder.Services.AddScoped<IPoliticasSeguridadService, PoliticasSeguridadService>();
builder.Services.AddScoped<ILogsAccesoSistemaService, LogsAccesoSistemaService>();
builder.Services.AddScoped<ITokensAutenticacionService, TokensAutenticacionService>();
builder.Services.AddScoped<IBitacoraCambiosDbService, BitacoraCambiosDbService>();
builder.Services.AddScoped<IRespaldosSistemaService, RespaldosSistemaService>();

// ── Módulo 25: Marketing ──
builder.Services.AddScoped<ICampanasMarketingService, CampanasMarketingService>();
builder.Services.AddScoped<IOfertasPersonalizadasService, OfertasPersonalizadasService>();
builder.Services.AddScoped<ICanjesPuntosService, CanjesPuntosService>();
builder.Services.AddScoped<INewsletterSuscripcionesService, NewsletterSuscripcionesService>();
builder.Services.AddScoped<IEncuestasPostVueloService, EncuestasPostVueloService>();
builder.Services.AddScoped<IPasajerosSegmentosService, PasajerosSegmentosService>();
builder.Services.AddScoped<IReaccionesPromocionesService, ReaccionesPromocionesService>();
builder.Services.AddScoped<INewsletterEnviosService, NewsletterEnviosService>();
builder.Services.AddScoped<IAnalisisComportamientoService, AnalisisComportamientoService>();

// ── Módulo 26: Documental ──
builder.Services.AddScoped<INormativasAplicablesService, NormativasAplicablesService>();
builder.Services.AddScoped<ILicenciasOperativasAeropuertoService, LicenciasOperativasAeropuertoService>();
builder.Services.AddScoped<ICumplimientoNormativoService, CumplimientoNormativoService>();
builder.Services.AddScoped<IContratosService, ContratosService>();
builder.Services.AddScoped<IClausulasContratoService, ClausulasContratoService>();
builder.Services.AddScoped<INotificacionesLegalesService, NotificacionesLegalesService>();
builder.Services.AddScoped<IDocumentosImportantesService, DocumentosImportantesService>();
builder.Services.AddScoped<IDocumentosRequeridosOperacionService, DocumentosRequeridosOperacionService>();
builder.Services.AddScoped<ICertificacionesInternacionalesService, CertificacionesInternacionalesService>();
builder.Services.AddScoped<IProyectosEficienciaEnergeticaService, ProyectosEficienciaEnergeticaService>();

// ── Módulo 27: Transporte Terrestre ──
builder.Services.AddScoped<IAsignacionServiciosTransporteService, AsignacionServiciosTransporteService>();
builder.Services.AddScoped<IAsignacionVehiculosRutasService, AsignacionVehiculosRutasService>();
builder.Services.AddScoped<IChoferesTransporteService, ChoferesTransporteService>();
builder.Services.AddScoped<IEmpresasTransporteService, EmpresasTransporteService>();
builder.Services.AddScoped<IRutasTransporteTerrestreService, RutasTransporteTerrestreService>();
builder.Services.AddScoped<IReservasTransporteTerrestreService, ReservasTransporteTerrestreService>();
builder.Services.AddScoped<ITarifasTransporteTerrestreService, TarifasTransporteTerrestreService>();
builder.Services.AddScoped<IVehiculosTransporteService, VehiculosTransporteService>();
builder.Services.AddScoped<IQuejasTransporteTerrestreService, QuejasTransporteTerrestreService>();
builder.Services.AddScoped<IConveniosHotelesTransporteService, ConveniosHotelesTransporteService>();

// ── Módulo 28: Emergencias ──
builder.Services.AddScoped<IActivacionesEmergenciaService, ActivacionesEmergenciaService>();
builder.Services.AddScoped<IEntrenamientosEmergenciaService, EntrenamientosEmergenciaService>();
builder.Services.AddScoped<IEquiposEmergenciaService, EquiposEmergenciaService>();
builder.Services.AddScoped<IEvaluacionesPostEmergenciaService, EvaluacionesPostEmergenciaService>();
builder.Services.AddScoped<IPersonalEmergenciaService, PersonalEmergenciaService>();
builder.Services.AddScoped<IPlanesEmergenciaService, PlanesEmergenciaService>();
builder.Services.AddScoped<IPuntosEncuentroService, PuntosEncuentroService>();
builder.Services.AddScoped<IRecursosEmergenciaService, RecursosEmergenciaService>();
builder.Services.AddScoped<ISimulacrosService, SimulacrosService>();

// ── Módulo 29: OACI ──
builder.Services.AddScoped<INotificacionesOaciService, NotificacionesOaciService>();
builder.Services.AddScoped<IReportesOaciService, ReportesOaciService>();
builder.Services.AddScoped<IEstandaresInternacionalesService, EstandaresInternacionalesService>();
builder.Services.AddScoped<ICodigosOaciPaisesService, CodigosOaciPaisesService>();
builder.Services.AddScoped<IRevisionesDocumentosService, RevisionesDocumentosService>();

// ── Sistema de Usuarios ──
builder.Services.AddScoped<IUsuariosSistemaService, UsuariosSistemaService>();
builder.Services.AddScoped<IRolesSistemaService, RolesSistemaService>();
builder.Services.AddScoped<IUsuariosRolesService, UsuariosRolesService>();
builder.Services.AddScoped<IModulosSistemaService, ModulosSistemaService>();
builder.Services.AddScoped<IRolesPermisosModulosService, RolesPermisosModulosService>();
builder.Services.AddScoped<ISegmentosClientesService, SegmentosClientesService>();

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
