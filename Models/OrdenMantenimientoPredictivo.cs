using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class OrdenMantenimientoPredictivo
    {
        [Key]
        public int IdOrdenMant { get; set; }
        public int IdAeronave { get; set; }
        public DateTime FechaProgramada { get; set; }
        public string TipoMantenimiento { get; set; } = null!; // PREDICTIVO, PREVENTIVO
        public string Estado { get; set; } = "PROGRAMADA";
        public string? Observaciones { get; set; }
    }
}