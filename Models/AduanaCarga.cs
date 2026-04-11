using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class AduanaCarga
    {
        [Key]
        public int IdRevision { get; set; }
        public int IdEnvio { get; set; }
        public int IdInspector { get; set; }
        public DateTime FechaRevision { get; set; }
        public string EstadoAduanero { get; set; } = null!; // LIBERADO, RETENIDO, RECHAZADO
        public string? Observaciones { get; set; }
        public decimal ImpuestosPagados { get; set; }
    }
}