using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class UniformeEquipamiento
    {
        [Key]
        public int IdAsignacion { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoEquipo { get; set; } = null!; // UNIFORME, RADIO, COMPUTADORA, etc.
        public string Descripcion { get; set; } = null!;
        public string Talla { get; set; } = null!;
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } = "NUEVO";
        public string? Observaciones { get; set; }
    }
}