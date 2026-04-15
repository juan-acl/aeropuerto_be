using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("HISTORIAL_FLUJO_TRAFICO")]
    public class HistorialFlujoTrafico
    {
        
        [Key]
        [Column("ID_FLUJO")]
        public decimal IdFlujo { get; set; }
        
        [Column("FECHA_HORA_INICIO")]
        public DateTime FechaHoraInicio { get; set; }
        
        [Column("FECHA_HORA_FIN")]
        public DateTime? FechaHoraFin { get; set; }
        
        [Column("TIPO_MEDICION")]
        public string? TipoMedicion { get; set; }
        
        [Column("DESPEGUES_HORA")]
        public decimal? DespeguesHora { get; set; }
        
        [Column("ATERRIZAJES_HORA")]
        public decimal? AterrizajesHora { get; set; }
        
        [Column("TOTAL_OPERACIONES_HORA")]
        public decimal? TotalOperacionesHora { get; set; }
        
        [Column("PASAJEROS_SALIDA_HORA")]
        public decimal? PasajerosSalidaHora { get; set; }
        
        [Column("PASAJEROS_LLEGADA_HORA")]
        public decimal? PasajerosLlegadaHora { get; set; }
        
        [Column("TOTAL_PASAJEROS_HORA")]
        public decimal? TotalPasajerosHora { get; set; }
        
        [Column("PICO_OPERACIONES")]
        public decimal? PicoOperaciones { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
