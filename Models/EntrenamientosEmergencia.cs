using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ENTRENAMIENTOS_EMERGENCIA")]
    public class EntrenamientosEmergencia
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ENTRENAMIENTO")]
        public int IdEntrenamiento { get; set; }
        
        [Column("NOMBRE_ENTRENAMIENTO")]
        public string NombreEntrenamiento { get; set; } = null!;
        
        [Column("TIPO_ENTRENAMIENTO")]
        public string? TipoEntrenamiento { get; set; }
        
        [Column("FECHA_REALIZACION")]
        public DateTime FechaRealizacion { get; set; }
        
        [Column("DURACION_HORAS")]
        public decimal? DuracionHoras { get; set; }
        
        [Column("INSTRUCTOR")]
        public string? Instructor { get; set; }
        
        [Column("PARTICIPANTES")]
        public decimal? Participantes { get; set; }
        
        [Column("CONTENIDO")]
        public string? Contenido { get; set; }
        
        [Column("EVALUACION")]
        public string? Evaluacion { get; set; }
        
        [Column("CERTIFICACIONES_ENTREGADAS")]
        public decimal? CertificacionesEntregadas { get; set; }
        
        [Column("FECHA_PROXIMO_ENTRENAMIENTO")]
        public DateTime? FechaProximoEntrenamiento { get; set; }
    }
}
