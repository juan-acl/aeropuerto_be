using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TAREAS_EJECUTADAS")]
    public class TareaEjecutada
    {
        [Key]
        [Column("ID_TAREA_EJECUTADA")]
        public int id_tarea_ejecutada { get; set; }

        [Column("ID_EJECUCION")]
        public int? id_ejecucion { get; set; }

        [Column("ID_TAREA")]
        public int? id_tarea { get; set; }

        [Column("FECHA_EJECUCION")]
        public DateTime? fecha_ejecucion { get; set; }

        [Column("TIEMPO_REAL_MINUTOS")]
        public int? tiempo_real_minutos { get; set; }

        [Column("RESULTADOS_MEDICION")]
        public string? resultados_medicion { get; set; }

        [Column("CONFORME")]
        public int? conforme { get; set; }

        [Column("OBSERVACIONES_TAREA")]
        public string? observaciones_tarea { get; set; }
    }
}