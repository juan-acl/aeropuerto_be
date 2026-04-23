using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TAREA_EJECUTADA")]
    public class TareaEjecutada
    {
        [Key]
        [Column("ID_TAREA_EJECUTADA")]
        public int IdTareaEjecutada { get; set; }
        [Column("ID_EJECUCION")]
        public int IdEjecucion { get; set; }
        [Column("DESCRIPCION_TAREA")]
        public string DescripcionTarea { get; set; } = null!;
        [Column("RESULTADO")]
        public string Resultado { get; set; } = null!; // OK, FALLO, REPARADO
        [Column("HALLAZGOS")]
        public string? Hallazgos { get; set; }
    }
}