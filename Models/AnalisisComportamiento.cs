using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ANALISIS_COMPORTAMIENTO")]
    public class AnalisisComportamiento
    {
        
        [Key]
        [Column("ID_ANALISIS_COMPORTAMIENTO")]
        public decimal IdAnalisisComportamiento { get; set; }
        
        [Column("ID_PASAJERO")]
        public decimal IdPasajero { get; set; }
        
        [Column("FECHA_ANALISIS")]
        public DateTime? FechaAnalisis { get; set; }
        
        [Column("VUELOS_ANIO")]
        public decimal? VuelosAnio { get; set; }
        
        [Column("VUELOS_MES")]
        public decimal? VuelosMes { get; set; }
        
        [Column("VUELOS_SEMANA")]
        public decimal? VuelosSemana { get; set; }
        
        [Column("DESTINOS_FRECUENTES")]
        public string? DestinosFrecuentes { get; set; }
        
        [Column("AEROLINEAS_PREFERIDAS")]
        public string? AerolineasPreferidas { get; set; }
        
        [Column("CLASE_PREFERIDA")]
        public string? ClasePreferida { get; set; }
        
        [Column("DIA_PREFERIDO_VIAJE")]
        public string? DiaPreferidoViaje { get; set; }
        
        [Column("MES_PREFERIDO_VIAJE")]
        public decimal? MesPreferidoViaje { get; set; }
        
        [Column("ANTICIPACION_PROMEDIO_RESERVA")]
        public decimal? AnticipacionPromedioReserva { get; set; }
        
        [Column("GASTO_PROMEDIO_ANUAL")]
        public decimal? GastoPromedioAnual { get; set; }
        
        [Column("GASTO_PROMEDIO_VUELO")]
        public decimal? GastoPromedioVuelo { get; set; }
        
        [Column("INGRESOS_TOTALES_GENERADOS")]
        public decimal? IngresosTotalesGenerados { get; set; }
        
        [Column("SCORE_FIDELIDAD")]
        public decimal? ScoreFidelidad { get; set; }
        
        [Column("ULTIMA_ACTUALIZACION")]
        public DateTime? UltimaActualizacion { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
