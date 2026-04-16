using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class ChecklistEjecucion
    {
        [Key]
        public int IdEjecucion { get; set; }
        public int IdOrdenMant { get; set; }
        public int IdChecklist { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public string TecnicoResponsable { get; set; } = null!;
    }
}