using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("EVALUACION_DESEMPENO")]
    public class EvaluacionDesempeno
    {
        [Key]
        [Column("ID_EVALUACION")]
        public int IdEvaluacion { get; set; }
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("FECHA_EVALUACION")]
        public DateTime FechaEvaluacion { get; set; }
        [Column("EVALUADOR_ID")]
        public int EvaluadorId { get; set; }
        [Column("PERIODO_EVALUADO")]
        public string PeriodoEvaluado { get; set; } = null!;
        [Column("PUNTUACION_TOTAL")]
        public decimal PuntuacionTotal { get; set; }
        [Column("PUNTUACION_PRODUCTIVIDAD")]
        public decimal PuntuacionProductividad { get; set; }
        [Column("PUNTUACION_CALIDAD")]
        public decimal PuntuacionCalidad { get; set; }
        [Column("PUNTUACION_ASISTENCIA")]
        public decimal PuntuacionAsistencia { get; set; }
        [Column("PUNTUACION_TRABAJO_EQUIPO")]
        public decimal PuntuacionTrabajoEquipo { get; set; }
        [Column("COMENTARIOS")]
        public string Comentarios { get; set; } = null!;
        [Column("METAS_FUTURAS")]
        public string MetasFuturas { get; set; } = null!;
    }
}