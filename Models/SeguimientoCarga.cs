using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class SeguimientoCarga
    {
        [Key]
        public int IdSeguimiento { get; set; }
        public int IdEnvio { get; set; }
        public DateTime FechaEvento { get; set; }
        public string UbicacionActual { get; set; } = null!;
        public string EstadoCarga { get; set; } = "EN TRANSITO";
        public string? Comentarios { get; set; }
    }
}