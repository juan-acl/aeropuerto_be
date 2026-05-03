using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CHECKLIST_EJECUCION")]
    public class ChecklistEjecucion
    {
        [Key]
        [Column("ID_EJECUCION")]
        public int id_ejecucion { get; set; }

        [Column("ID_ORDEN_MP")]
        public int? id_orden_mp { get; set; }

        [Column("ID_CHECKLIST")]
        public int? id_checklist { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? fecha_inicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? fecha_fin { get; set; }

        [Column("TECNICO_EJECUTOR")]
        public int? tecnico_ejecutor { get; set; }

        [Column("SUPERVISOR")]
        public int? supervisor { get; set; }

        [Column("RESULTADO")]
        public string? resultado { get; set; } // APROBADO, APROBADO_CON_OBS, RECHAZADO

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }

        [Column("FIRMA_TECNICO")]
        public byte[]? firma_tecnico { get; set; }

        [Column("FIRMA_SUPERVISOR")]
        public byte[]? firma_supervisor { get; set; }
    }
}