using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class Presupuesto
    {
        [Key]
        public int IdPresupuesto { get; set; }
        public int IdDepartamento { get; set; }
        public decimal MontoAsignado { get; set; }
        public decimal MontoEjecutado { get; set; } = 0;
        public int AnioPresupuestario { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, APROBADO, AGOTADO
        public string? Notas { get; set; }
    }
}