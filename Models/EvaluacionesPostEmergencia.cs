using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("EVALUACIONES_POST_EMERGENCIA")]
    public class EvaluacionesPostEmergencia
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_EVALUACION_POST")]
        public int IdEvaluacionPost { get; set; }
        
        [Column("ID_ACTIVACION")]
        public decimal IdActivacion { get; set; }
        
        [Column("FECHA_EVALUACION")]
        public DateTime? FechaEvaluacion { get; set; }
        
        [Column("EVALUADOR")]
        public string Evaluador { get; set; } = null!;
        
        [Column("TIEMPO_RESPUESTA_MINUTOS")]
        public decimal? TiempoRespuestaMinutos { get; set; }
        
        [Column("EFICACIA_RESPUESTA")]
        public decimal? EficaciaRespuesta { get; set; }
        
        [Column("COORDINACION")]
        public decimal? Coordinacion { get; set; }
        
        [Column("RECURSOS_UTILIZADOS")]
        public string? RecursosUtilizados { get; set; }
        
        [Column("PUNTOS_FUERTES")]
        public string? PuntosFuertes { get; set; }
        
        [Column("AREAS_MEJORA")]
        public string? AreasMejora { get; set; }
        
        [Column("ACCIONES_RECOMENDADAS")]
        public string? AccionesRecomendadas { get; set; }
        
        [Column("RESPONSABLE_SEGUIMIENTO")]
        public string? ResponsableSeguimiento { get; set; }
        
        [Column("FECHA_SEGUIMIENTO")]
        public DateTime? FechaSeguimiento { get; set; }

    }
}
