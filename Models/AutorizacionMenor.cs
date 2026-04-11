using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class AutorizacionMenor
    {
        [Key]
        public int IdAutorizacion { get; set; }
        public int IdPasajeroMenor { get; set; }
        public string NombreTutor { get; set; } = null!;
        public string DpiTutor { get; set; } = null!;
        public string TipoRelacion { get; set; } = null!;
        public string DocumentoAdjunto { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
    }
}