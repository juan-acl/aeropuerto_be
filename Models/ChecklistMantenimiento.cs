using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CHECKLIST_MANTENIMIENTO")]
    public class ChecklistMantenimiento
    {
        [Key]
        [Column("ID_CHECKLIST")]
        public int IdChecklist { get; set; }
        [Column("NOMBRE_CHECKLIST")]
        public string NombreChecklist { get; set; } = null!;
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}