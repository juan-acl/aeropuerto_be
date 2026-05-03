using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("EVALUACIONES_DESEMPENO")]
    public class EvaluacionDesempeno
    {
        [Key]
        [Column("ID_EVALUACION")]
        public int id_evaluacion { get; set; }

        [Column("ID_EMPLEADO")]
        public int? id_empleado { get; set; }

        [Column("FECHA_EVALUACION")]
        public DateTime? fecha_evaluacion { get; set; }

        [Column("EVALUADOR_ID")]
        public int? evaluador_id { get; set; }

        [Column("PERIODO_EVALUADO")]
        public string? periodo_evaluado { get; set; }

        [Column("PUNTUACION_TOTAL")]
        public decimal? puntuacion_total { get; set; }

        [Column("PUNTUACION_PRODUCTIVIDAD")]
        public decimal? puntuacion_productividad { get; set; }

        [Column("PUNTUACION_CALIDAD")]
        public decimal? puntuacion_calidad { get; set; }

        [Column("PUNTUACION_ASISTENCIA")]
        public decimal? puntuacion_asistencia { get; set; }

        [Column("PUNTUACION_TRABAJO_EQUIPO")]
        public decimal? puntuacion_trabajo_equipo { get; set; }

        [Column("COMENTARIOS")]
        public string? comentarios { get; set; }

        [Column("METAS_FUTURAS")]
        public string? metas_futuras { get; set; }
    }
}