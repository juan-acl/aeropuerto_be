using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class ChecklistMantenimiento
    {
        [Key]
        public int IdChecklist { get; set; }
        public string NombreChecklist { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Activo { get; set; } = 1;
    }
}