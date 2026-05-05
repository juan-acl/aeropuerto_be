using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CHECKLIST_EJECUCION")]
    public class ChecklistEjecucion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_EJECUCION")]
        public int IdEjecucion { get; set; }
        [Column("ID_ORDEN_MANT")]
        public int IdOrdenMant { get; set; }
        [Column("ID_CHECKLIST")]
        public int IdChecklist { get; set; }
        [Column("FECHA_EJECUCION")]
        public DateTime FechaEjecucion { get; set; }
        [Column("TECNICO_RESPONSABLE")]
        public string TecnicoResponsable { get; set; } = null!;
    }
}
