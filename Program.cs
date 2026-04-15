using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Services;
using Aeropuerto.Backend.Services.Seguridad;

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

// ── Módulo 1: Infraestructura ─────────────────────────────────────────────────
builder.Services.AddScoped<IAeropuertoService,                       AeropuertoService>();

// ── Módulo 2: Flota ───────────────────────────────────────────────────────────
builder.Services.AddScoped<IFabricanteAvionService,                  FabricanteAvionService>();
builder.Services.AddScoped<IModeloAvionService,                      ModeloAvionService>();
builder.Services.AddScoped<IMotorAvionService,                       MotorAvionService>();
builder.Services.AddScoped<IAvionService,                            AvionService>();
builder.Services.AddScoped<IMantenimientoAvionService,               MantenimientoAvionService>();
builder.Services.AddScoped<IFranquiciaEquipajeService,               FranquiciaEquipajeService>();

// ── Módulo 3: Aerolíneas ──────────────────────────────────────────────────────
builder.Services.AddScoped<IAerolineaService,                        AerolineaService>();
builder.Services.AddScoped<IAlianzaAerolineaService,                 AlianzaAerolineaService>();
builder.Services.AddScoped<ITipoAerolineaService,                    TipoAerolineaService>();
builder.Services.AddScoped<ITipoAeropuertoService,                   TipoAeropuertoService>();

// ── Módulo 1: Infraestructura ────────────────────────────────────────────────
builder.Services.AddScoped<IAeropuertoService,                       AeropuertoService>();
builder.Services.AddScoped<IPistaAterrizajeService,                  PistaAterrizajeService>();
builder.Services.AddScoped<IPuertaEmbarqueService,                   PuertaEmbarqueService>();
builder.Services.AddScoped<ITerminalAeropuertoService,               TerminalAeropuertoService>();
builder.Services.AddScoped<IHangarService,                           HangarService>();

// ── Módulo 4: Programación de vuelos ─────────────────────────────────────────
builder.Services.AddScoped<ITemporadaVueloService,                   TemporadaVueloService>();
builder.Services.AddScoped<IDiasOperacionService,                    DiasOperacionService>();
builder.Services.AddScoped<ISerieVueloAsignadaService,               SerieVueloService>();
builder.Services.AddScoped<IProgramaVueloService,                    ProgramaVueloService>();
builder.Services.AddScoped<IFrecuenciaVueloService,                  FrecuenciaVueloService>();
builder.Services.AddScoped<ITarifaVueloService,                      TarifaVueloService>();

// ── Módulo 5: Operaciones de vuelo ────────────────────────────────────────────
builder.Services.AddScoped<IVueloService,                            VueloService>();
builder.Services.AddScoped<ICondicionMeteorologicaService,           CondicionMeteorologicaService>();
builder.Services.AddScoped<IIncidenteVueloService,                   IncidenteVueloService>();
builder.Services.AddScoped<IRetrasoVueloService,                     RetrasoVueloService>();
builder.Services.AddScoped<ITripulacionVueloService,                 TripulacionVueloService>();

// ── Módulo 6: Tripulación ─────────────────────────────────────────────────────
builder.Services.AddScoped<ITripulacionService,                      TripulacionService>();

// ── Sistema de usuarios ───────────────────────────────────────────────────────
builder.Services.AddScoped<IUsuarioSistemaService,                   UsuarioSistemaService>();
builder.Services.AddScoped<IRolSistemaService,                       RolSistemaService>();
builder.Services.AddScoped<IUsuarioRolService,                       UsuarioRolService>();
builder.Services.AddScoped<IModuloSistemaService,                    ModuloSistemaService>();
builder.Services.AddScoped<IRolPermisoModuloService,                 RolPermisoModuloService>();
builder.Services.AddScoped<ISegmentoClienteService,                  SegmentoClienteService>();

// ── Módulo 21: Tiempo Real ────────────────────────────────────────────────────
builder.Services.AddScoped<IAsigPistasTiempoRealService,             AsignacionPistasTiempoRealService>();
builder.Services.AddScoped<IRetrasosTiempoRealService,               RetrasosTiempoRealService>();
builder.Services.AddScoped<ISlotAeropuertoService,                   SlotsAeropuertoService>();
builder.Services.AddScoped<ICapacidadTerminalTiempoRealService,      CapacidadTerminalTiempoRealService>();
builder.Services.AddScoped<ICondicionPistaTiempoRealService,         CondicionPistaTiempoRealService>();
builder.Services.AddScoped<IPosicionRadarService,                    PosicionRadarService>();
builder.Services.AddScoped<ITorreControlComunicacionService,         TorreControlComunicacionService>();
builder.Services.AddScoped<IHistorialFlujoTraficoService,            HistorialFlujoTraficoService>();
builder.Services.AddScoped<IPrediccionDemandaService,                PrediccionDemandaService>();

// ── Módulo 22: Combustible ────────────────────────────────────────────────────
builder.Services.AddScoped<ICargaCombustibleService,                 CargaCombustibleService>();
builder.Services.AddScoped<IControlCalidadCombustibleService,        ControlCalidadCombustibleService>();
builder.Services.AddScoped<IFacturacionCombustibleService,           FacturacionCombustibleService>();
builder.Services.AddScoped<IHistorialPrecioCombustibleService,       HistorialPreciosCombustibleService>();
builder.Services.AddScoped<IInventarioCombustibleService,            InventarioCombustibleService>();
builder.Services.AddScoped<IProveedorCombustibleService,             ProveedorCombustibleService>();
builder.Services.AddScoped<ISurtidorCombustibleService,              SurtidorCombustibleService>();
builder.Services.AddScoped<ITanqueCombustible,                       TanqueCombustibleService>();
builder.Services.AddScoped<IPedidosCombustibleService,               PedidoCombustibleService>();
builder.Services.AddScoped<IRecepcionCombustibleService,             RecepcionCombustibleService>();

// ── Módulo 23: Ambiental ──────────────────────────────────────────────────────
builder.Services.AddScoped<IMonitoreoAireService,                    MonitoreoAireService>();
builder.Services.AddScoped<IMonitoreoRuidoService,                   MonitoreoRuidoService>();
builder.Services.AddScoped<IHuellaCarbonoVueloService,               HuellaCarbonoVueloService>();
builder.Services.AddScoped<IGestionResiduosService,                  GestionResiduosService>();
builder.Services.AddScoped<IIndicadoresDesempenoAmbientalService,    IndicadoresDesempenoAmbientalService>();
builder.Services.AddScoped<IProgramasCompensacionAmbientalService,   ProgramaCompensacionService>();
builder.Services.AddScoped<ICertificacionesAmbientalesAeropuertoService, CertificacionAmbientalService>();

// ── Módulo 24: Seguridad Informática ─────────────────────────────────────────
builder.Services.AddScoped<IAuditoriaSeguridadService,               AuditoriaSeguridadService>();
builder.Services.AddScoped<IAuditoriaInternaService,                 AuditoriaInternaService>();
builder.Services.AddScoped<IAuditoriaInternacionalService,           AuditoriaInternacionalService>();
builder.Services.AddScoped<IIncidenteSeguridadInformaticaService,    IncidenteSeguridadService>();
builder.Services.AddScoped<IPoliticaSeguridadService,                PoliticaSeguridadService>();
builder.Services.AddScoped<ILogAccesoSistemaService,                 LogAccesoSistemaService>();
builder.Services.AddScoped<ITokenAutenticacionService,               TokenAutenticacionService>();
builder.Services.AddScoped<IBitacoraCambiosDbService,                BitacoraCambiosDbService>();
builder.Services.AddScoped<IRespaldoSistemaService,                  RespaldoSistemaService>();

// ── Módulo 25: Marketing ──────────────────────────────────────────────────────
builder.Services.AddScoped<ICampanaMarketingService,                 CampanaMarketingService>();
builder.Services.AddScoped<IOfertaPersonalizadaService,              OfertaPersonalizadaService>();
builder.Services.AddScoped<ICanjePuntoService,                       CanjePuntoService>();
builder.Services.AddScoped<INewsletterSuscripcionService,            NewsletterSuscripcionService>();
builder.Services.AddScoped<IEncuestaPostVueloService,                EncuestaPostVueloService>();
builder.Services.AddScoped<IPasajeroSegmentoService,                 PasajeroSegmentoService>();
builder.Services.AddScoped<IReaccionPromocionService,                ReaccionPromocionService>();
builder.Services.AddScoped<INewsletterEnvioService,                  NewsletterEnvioService>();
builder.Services.AddScoped<IAnalisisComportamientoService,           AnalisisComportamientoService>();

// ── Módulo 26: Documental ─────────────────────────────────────────────────────
builder.Services.AddScoped<INormativaAplicableService,               NormativaAplicableService>();
builder.Services.AddScoped<ILicenciaOperativaAeropuertoService,      LicenciaOperativaService>();
builder.Services.AddScoped<ICumplimientoNormativoService,            CumplimientoNormativoService>();
builder.Services.AddScoped<IContratoService,                         ContratoService>();
builder.Services.AddScoped<IClausulaContratoService,                 ClausulaContratoService>();
builder.Services.AddScoped<INotificacionLegalService,                NotificacionLegalService>();
builder.Services.AddScoped<IDocumentosImportantesService,            DocumentoImportanteService>();
builder.Services.AddScoped<IDocumentoRequeridoOperacionService,      DocumentoRequeridoService>();
builder.Services.AddScoped<ICertificacionInternacionalService,       CertificacionInternacionalService>();
builder.Services.AddScoped<IProyectosEficienciaEnergeticaService,    ProyectoEficienciaService>();

// ── Módulo 27: Transporte Terrestre ──────────────────────────────────────────
builder.Services.AddScoped<IAsignacionServicioTransporteService,     AsignacionServicioService>();
builder.Services.AddScoped<IAsignacionVehiculoRutaService,           AsignacionVehiculoRutaService>();
builder.Services.AddScoped<IChoferTransporteService,                 ChoferTransporteService>();
builder.Services.AddScoped<IEmpresaTransporteService,                EmpresaTransporteService>();
builder.Services.AddScoped<IRutaTransporteTerrestreService,          RutaTransporteService>();
builder.Services.AddScoped<IReservaTransporteTerrestreService,       ReservaTransporteService>();
builder.Services.AddScoped<ITarifaTransporteTerrestreService,        TarifaTransporteTerrestreService>();
builder.Services.AddScoped<IVehiculoTransporteService,               VehiculoTransporteService>();
builder.Services.AddScoped<IQuejaTransporteTerrestreService,         QuejaTransporteService>();
builder.Services.AddScoped<IConveniosHotelesService,                 ConvenioHotelService>();

// ── Módulo 28: Emergencias ────────────────────────────────────────────────────
builder.Services.AddScoped<IActivacionEmergenciaService,             ActivacionEmergenciaService>();
builder.Services.AddScoped<IEntrenamientoEmergenciaService,          EntrenamientoEmergenciaService>();
builder.Services.AddScoped<IEquipoEmergenciaService,                 EquipoEmergenciaService>();
builder.Services.AddScoped<IEvaluacionPostEmergenciaService,         EvaluacionPostService>();
builder.Services.AddScoped<IPersonalEmergenciaService,               PersonalEmergenciaService>();
builder.Services.AddScoped<IPlanEmergenciaService,                   PlanEmergenciaService>();
builder.Services.AddScoped<IPuntoEncuentroService,                   PuntoEncuentroService>();
builder.Services.AddScoped<IRecursoEmergenciaService,                RecursoEmergenciaService>();
builder.Services.AddScoped<ISimulacroService,                        SimulacroService>();

// ── Módulo 29: OACI ───────────────────────────────────────────────────────────
builder.Services.AddScoped<INotificacionOaciService,                 NotificacionOaciService>();
builder.Services.AddScoped<IReporteOaciService,                      ReporteOaciService>();
builder.Services.AddScoped<IEstandarInternacionalService,            EstandarInternacionalService>();
builder.Services.AddScoped<ICodigoOaciPaisService,                   CodigoOaciPaisService>();
builder.Services.AddScoped<IRevisionDocumentoService,                RevisionDocumentoService>();

// ═══════════════════════════════════════════════════════════════════════════════
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MiAppReact);
app.UseAuthorization();
app.MapControllers();
app.Run();

