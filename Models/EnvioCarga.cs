using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class EnvioCarga
    {
        [Key]
        public int IdEnvio { get; set; }
        public string NumeroGuia { get; set; } = null!; // AWB (Air Waybill)
        public string Remitente { get; set; } = null!;
        public string Destinatario { get; set; } = null!;
        public decimal Peso { get; set; }
        public decimal Volumen { get; set; }
        public string Contenido { get; set; } = null!;
        public DateTime FechaEnvio { get; set; }
    }
}