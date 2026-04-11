using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class Capacitacion
    {
        [Key]
        public int IdCapacitacion { get; set; }
        public string NombreCurso { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string TipoCapacitacion { get; set; } = null!; // SEGURIDAD, TECNICA, etc.
        public int DuracionHoras { get; set; }
        public decimal Costo { get; set; }
        public string Proveedor { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Activo { get; set; } = 1;
    }
}